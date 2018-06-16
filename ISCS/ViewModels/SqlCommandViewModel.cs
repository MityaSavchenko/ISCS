using System;
using System.Collections.Generic;

namespace ISCS.ViewModels
{
    public class SqlCommandViewModel
    {
        private const string addColumnQueryFormat = "ALTER TABLE [{0}] ADD [{1}] {2}";
        private const string dropColumnQueryFormat = "ALTER TABLE [{0}] DROP COLUMN [{1}]";

        public string TableName { get; set; }

        public string DataType { get; set; }

        public string NewColumnName { get; set; }

        public string ColumnName { get; set; }

        public SqlCommands SqlCommand { get; set; }

        public string ToSqlCommand()
        {
            switch (SqlCommand)
            {
                case SqlCommands.AddColumn:
                {
                    return string.Format(addColumnQueryFormat, TableName, NewColumnName, DataType);
                }

                case SqlCommands.DropColumn:
                {
                    return string.Format(dropColumnQueryFormat, TableName, ColumnName);
                }

                default:
                {
                    return String.Empty;
                }
            }
        }

        #region Collections

        public IEnumerable<string> TableNames { get; set; }

        #endregion
    }
}
