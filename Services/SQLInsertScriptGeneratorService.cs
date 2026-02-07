using SQL_InsertScriptGenerator_In1Click.Data;
using SQL_InsertScriptGenerator_In1Click.Interfaces;
using System.Data;
namespace SQL_InsertScriptGenerator_In1Click.Services
{


    public class SQLInsertScriptGeneratorService:ISQLInsertScriptGeneratorService
    {
        private readonly SQLInsertScriptGeneratorDbContext _dbcontext;
        public SQLInsertScriptGeneratorService(SQLInsertScriptGeneratorDbContext dbcontext)
        {
                _dbcontext= dbcontext;
        }

        public async Task<string> GenerateInsertScriptAsync(DataTable ds, int count, bool PopulateIdentityColumn, bool GenerateSingleInsertPerRow, bool GenerateProjectInfo, bool GenerateGoStatment, bool FormatCode)
        {
            return   await _dbcontext.GenerateChangesAsync(ds, count, PopulateIdentityColumn, GenerateSingleInsertPerRow, GenerateProjectInfo,
             GenerateGoStatment, FormatCode);
        }
    }

}
