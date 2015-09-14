using NetCoders.MicroErp.Common.Interfaces.Dal;
using NetCoders.MicroErp.Dal.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;

namespace NetCoders.MicroErp.Dal
{
    public sealed class Conexao<TDto> : IConexao<TDto> where TDto : class
    {
        #region Property

        private IDbConnection _connection;

        private IDbCommand _command;

        // Essa factory é um Provider mais leve que tem no Framework (segundo o Bruno)
        private DbProviderFactory _factory;

        private readonly string _connectionString;

        #endregion

        #region Conection

        public Conexao(string nameOfConnection)
        {
            var connectionStringSettings = ConfigurationManager.ConnectionStrings[nameOfConnection];
            if (connectionStringSettings == null
                || string.IsNullOrEmpty(connectionStringSettings.ConnectionString)
                || connectionStringSettings.ConnectionString.Trim() == string.Empty)
                throw new Exception("String de conexão não configurada!");

            if (string.IsNullOrEmpty(connectionStringSettings.ProviderName)
                || connectionStringSettings.ProviderName.Trim() == string.Empty)
                throw new Exception("Provider name não informado!");

            _connectionString = connectionStringSettings.ConnectionString;
            _factory = DbProviderFactories.GetFactory(connectionStringSettings.ProviderName);
            Initialize();
        }
        private void Initialize()
        {
            _connection = _factory.CreateConnection();
            if (_connection == null) throw new Exception("Erro ao criar a conexão!");

            _connection.ConnectionString = _connectionString;
            _command = _connection.CreateCommand();
        }

        //public Conexao()
        //{
        //    ConfigurationInicialize();
        //}

        //public Conexao(string dataBase)
        //{
        //    ConfigurationInicialize();

        //    _connection.ChangeDatabase(dataBase);
        //}

        //private void ConfigurationInicialize()
        //{
        //    _command = _factory.CreateCommand();
        //    _connection = _factory.CreateConnection();
        //    _command.Connection = _connection;
        //    _connection.ConnectionString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
        //}

        public string CommandText
        {
            get
            {
                return _command.CommandText;
            }
            set
            {
                _command.CommandText = value;
            }
        }

        public int CommandTimeout
        {
            get
            {
                return _command.CommandTimeout;
            }
            set
            {
                _command.CommandTimeout = value;
            }
        }

        public CommandType CommandType
        {
            get
            {
                return _command.CommandType;
            }
            set
            {
                _command.CommandType = value;
            }
        }

        public void Open()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }

        public void Close()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }

        public T ExecuteScalar<T>() where T : struct
        {
            try
            {
                this.Open();
                return (T)_command.ExecuteScalar();
            }
            finally
            {
                this.Clear();
                this.Close();
            }
        }

        public int ExecuteNonQuery()
        {
            try
            {
                this.Open();
                return _command.ExecuteNonQuery();
            }
            finally
            {
                this.Clear();
                this.Close();
            }
        }

        public IDataReader ExecuteReader()
        {
            Open();
            // CommandBehavior.CloseConnection, quando o command estiver com a Conexão Fechado, ele para o processo da execução
            return _command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public void Clear()
        {
            this.CommandText = string.Empty;
            this.CommandType = CommandType.StoredProcedure;
            this.CommandTimeout = 30; // 30 Segundos
            _command.Parameters.Clear();
        }

        public void AddWithValue(string name, object value)
        {
            var type = value.GetType().ToDbType();
            this.AddWithValue(name, value, type);
        }

        public void AddWithValue(string name, object value, DbType type)
        {
            var param = _factory.CreateParameter();
            param.ParameterName = name;
            param.Value = value;
            param.DbType = type;
            _command.Parameters.Add(param);
        }

        #endregion

        #region CRUD

        // IDataRecord é mais leve que o IDataReader
        private T Make<T>(IDataRecord dataRecord) where T : class
        {
            // Versão "Antiga"
            //var t = default(TDto);

            // Activator ele Cria uma instância do TDto com uma Refletion
            var tipo = Activator.CreateInstance<T>();

            // Percorre todas as propriedades da Classe (TDto)
            foreach (var propertyInfo in typeof(TDto).GetProperties().Where(x => x.IsBind()))
            {
                SetValueProperty<T>(tipo, dataRecord, propertyInfo);
            }

            // Retorna o Objeto Preenchido
            return tipo;
        }

        private void SetValueProperty<T>(T tObj, IDataRecord dataRecord, PropertyInfo propertyInfo) where T : class
        {
            try
            {
                //if (propertyInfo.IsBind())
                //{
                var nome = propertyInfo.GetNameOfProperty();
                var value = dataRecord[nome];
                propertyInfo.SetValue(tObj, value);
                //}
            }
            catch (Exception ex)
            {

                throw new Exception(string.Format("Não foi encontrado a propriedade {0} no Reader (DataRecord)! InnerException: {1}", propertyInfo.Name, ex.Message), ex);
            }
        }

        public T GetById<T>(int id) where T : class
        {
            try
            {
                this.AddParamId(id);
                var reader = this.ExecuteReader();
                if (reader.Read())
                {
                    return this.Make<T>(reader);
                }
                else
                {
                    return null;
                }
            }
            finally
            {
                this.Close();
                this.Clear();
            }
        }

        public TDto GetById(int id)
        {
            return GetById<TDto>(id);
        }

        public IEnumerable<T> GetAll<T>() where T : class
        {
            try
            {
                // Cria a lista do Objeto Genérico
                var listOfDto = new List<T>();

                // Executa o Reader e pega ele
                var reader = this.ExecuteReader();

                // Percorre o Reader
                while (reader.Read())
                {
                    // Para cada Reader, pega o objeto por Refletion e adiciona na lista
                    listOfDto.Add(Make<T>(reader));
                }

                // Retorna a lista
                return listOfDto;
            }
            finally
            {
                this.Clear();
                this.Close();
            }
        }

        public IEnumerable<TDto> GetAll()
        {
            return GetAll<TDto>();
        }

        public void Add(TDto dto)
        {
            // Adiciona os parâmetros do Objeto
            AddParams(dto);
            // Recupera a propriedade Id do objeto
            var propertyInfo = dto.GetType().GetProperties().Single(x => x.IsId());
            // Executa o comamndo no banco, retornando o Id através de um Select Convert(int, SCOPE_IDENTITY())
            var id = ExecuteScalar<int>();
            // Seta o valor na propriedade
            propertyInfo.SetValue(dto, id);
        }

        public void Update(TDto dto)
        {
            // Adiciona parâmetro Id (para Where Id)
            AddParamId(dto);
            // Adiciona os parâmetros do Objeto
            AddParams(dto);
            // Realiza o update no banco
            ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            this.AddParamId(id);
            this.ExecuteNonQuery();
        }

        public void AddParamId(TDto dto)
        {
            // Pegar a propriedade que tenha a attribute IsId
            var propertyInfo = dto.GetType().GetProperties().Single(x => x.IsId());
            // Pega o nome da propriedade
            var name = propertyInfo.GetNameOfProperty();
            // Adiciona a valor da propriedade command
            AddWithValue(string.Format(@"{0}", name), propertyInfo.GetValue(dto), propertyInfo.PropertyType.ToDbType());
        }

        public void AddParamId(int id)
        {
            // Pegar a propriedade que tenha a attribute IsId
            var propertyInfo = typeof(TDto).GetProperties().Single(x => x.IsId());
            // Pega o nome da propriedade
            var name = propertyInfo.GetNameOfProperty();
            // Adiciona a valor da propriedade command
            AddWithValue(string.Format(@"{0}", name), id, DbType.UInt32);
        }

        public void AddParams(TDto dto)
        {
            // Percorre as propriedades que não são IsId e que são IsBind
            foreach (var propertyInfo in dto.GetType().GetProperties().Where(x => x.IsId() && x.IsBind()))
            {
                // Pega o nome da propriedade
                var name = propertyInfo.GetNameOfProperty();
                // Adicionar o valor da propriedade no command
                AddWithValue(string.Format(@"{0}", name), propertyInfo.GetValue(dto), propertyInfo.PropertyType.ToDbType());
            }
        }

        #endregion


        public T Get<T>(Func<IDataRecord, T> make, int id) where T : class
        {
            try
            {
                this.AddParamId(id);
                var reader = this.ExecuteReader();
                if (reader.Read())
                {
                    return make(reader);
                }
                else
                {
                    return null;
                }
            }
            finally
            {
                this.Close();
                this.Clear();
            }
        }

        public IEnumerable<T> GetAll<T>(Func<IDataRecord, T> make) where T : class
        {
            try
            {
                // Cria a lista do Objeto Genérico
                var listOfDto = new List<T>();

                // Executa o Reader e pega ele
                var reader = this.ExecuteReader();

                // Percorre o Reader
                while (reader.Read())
                {
                    // Para cada Reader, pega o objeto por Refletion e adiciona na lista
                    listOfDto.Add(make(reader));
                }

                // Retorna a lista
                return listOfDto;
            }
            finally
            {
                this.Clear();
                this.Close();
            }
        }
    }
}
