using System;
using System.Collections.Generic;
using System.Data;

namespace NetCoders.MicroErp.Common.Interfaces.Dal
{
    public interface IConexao<TDto> where TDto : class
    {
        #region Property

        string CommandText { get; set; }

        int CommandTimeout { get; set; }

        CommandType CommandType { get; set; }

        #endregion

        #region Conection

        void Open();

        void Close();

        T ExecuteScalar<T>() where T : struct;

        int ExecuteNonQuery();

        IDataReader ExecuteReader();

        void Clear();

        void AddWithValue(string name, object value);

        void AddWithValue(string name, object value, DbType type);

        #endregion

        #region CRUD

        TDto GetById(int id);

        T GetById<T>(int id) where T : class;

        IEnumerable<TDto> GetAll();

        IEnumerable<T> GetAll<T>() where T : class;

        void Add(TDto dto);

        void Update(TDto dto);

        void Delete(int id);

        void AddParamId(TDto dto);

        void AddParamId(int id);

        void AddParams(TDto dto);


        T Get<T>(Func<IDataRecord, T> make, int id) where T: class; // O Func<> é um tipo de Delegate que tem uma retorno, e nesse caso é retorno é o TDto tem um parâmetro de entrada IDataRecord

        IEnumerable<T> GetAll<T>(Func<IDataRecord, T> make) where T : class;

        #endregion
    }
}
