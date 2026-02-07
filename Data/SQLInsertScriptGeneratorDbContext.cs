using Microsoft.Data.SqlClient;
using System.Data;
using System.Text;

namespace SQL_InsertScriptGenerator_In1Click.Data
{
    public class SQLInsertScriptGeneratorDbContext
    {
        private readonly string _connectionString;

        public SQLInsertScriptGeneratorDbContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("LocalConnection");
        }

        // MODIFIED: async version recommended
        public async Task<string> GenerateChangesAsync(
            DataTable ds,
            int count,
            bool PopulateIdentityColumn,
            bool GenerateSingleInsertPerRow,
            bool GenerateProjectInfo,
            bool GenerateGoStatment,
            bool FormatCode)
        {
            var stringBuilder = new StringBuilder();
            string generatedOP = string.Empty;

            using var sqlConnection = new SqlConnection(_connectionString);
            await sqlConnection.OpenAsync(); // MODIFIED

            using var sqlCommand = new SqlCommand("dbo.sp_InsertScriptGenerator", sqlConnection)
            {
                CommandType = CommandType.StoredProcedure
            };

            sqlCommand.Parameters.Add("@PopulateIdentityColumn", SqlDbType.Bit).Value = PopulateIdentityColumn;
            sqlCommand.Parameters.Add("@GenerateSingleInsertPerRow", SqlDbType.Bit).Value = GenerateSingleInsertPerRow;
            sqlCommand.Parameters.Add("@GenerateProjectInfo", SqlDbType.Bit).Value = GenerateProjectInfo;
            sqlCommand.Parameters.Add("@GenerateGo", SqlDbType.Bit).Value = GenerateGoStatment;
            sqlCommand.Parameters.Add("@FormatCode", SqlDbType.Bit).Value = FormatCode;
            sqlCommand.Parameters.Add("@tblCount", SqlDbType.Int).Value = count;
            sqlCommand.Parameters.Add("@UniqueId", SqlDbType.NVarChar).Value = Guid.NewGuid().ToString().ToUpper();

            // TVP
            sqlCommand.Parameters.Add(new SqlParameter("@SqlScriptGeneratorDatas", SqlDbType.Structured)
            {
                TypeName = "dbo.SqlScriptGeneratorData",
                Value = ds
            });

            var op = new SqlParameter("@Result", SqlDbType.NVarChar, -1)
            {
                Direction = ParameterDirection.Output
            };

            sqlCommand.Parameters.Add(op);


            using var da = new SqlDataAdapter(sqlCommand);
            var dsdt = new DataSet(); 
            da.Fill(dsdt);

            if (op.Value != DBNull.Value)
            {
                generatedOP = op.Value?.ToString();
            }

            if (string.IsNullOrWhiteSpace(generatedOP) && dsdt.Tables.Count > 0)
            {
                var table = dsdt.Tables[0];

                stringBuilder.AppendLine(string.Join("\t",
                    table.Columns.Cast<DataColumn>().Select(c => c.ColumnName)));

                foreach (DataRow row in table.Rows)
                {
                    stringBuilder.AppendLine(string.Join("\t",
                        row.ItemArray.Select(c => c?.ToString())));
                }

                generatedOP = stringBuilder.ToString();
            }

            return generatedOP;
        }
    }
}
