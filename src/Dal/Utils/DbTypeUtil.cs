using System;
using System.Collections;
using System.Data;

namespace NetCoders.MicroErp.Dal.Utils
{
    public static class DbTypeUtil
    {
        private static Hashtable _dbTypeTables;

        public static DbType ToDbType(this Type type)
        {
            lock (_dbTypeTables)
            {
                if (_dbTypeTables == null)
                {
                    _dbTypeTables = new Hashtable
                    {
                        {typeof(Boolean), DbType.Boolean},
                        {typeof(Int16), DbType.Int16},
                        {typeof(Int32), DbType.Int32},
                        {typeof(Int64), DbType.Int64},
                        {typeof(Double), DbType.Double},
                        {typeof(Decimal), DbType.Decimal},
                        {typeof(String), DbType.String},
                        {typeof(DateTime), DbType.DateTime},
                        {typeof(Byte[]), DbType.Byte},
                        {typeof(Guid), DbType.Guid}
                    };
                }
            }

            return (DbType)_dbTypeTables[type];
        }
    }
}
