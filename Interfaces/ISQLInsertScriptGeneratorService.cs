using System.Data;

namespace SQL_InsertScriptGenerator_In1Click.Interfaces
{
    public interface ISQLInsertScriptGeneratorService
    {
        Task<String> GenerateInsertScriptAsync(DataTable ds, int count, bool PopulateIdentityColumn, bool GenerateSingleInsertPerRow, bool GenerateProjectInfo,
           bool GenerateGoStatment, bool FormatCode);
    }
}
