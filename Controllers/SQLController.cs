using Microsoft.AspNetCore.Mvc;
using SQL_InsertScriptGenerator_In1Click.Data;
using SQL_InsertScriptGenerator_In1Click.Interfaces;
using SQL_InsertScriptGenerator_In1Click.Models;
using System.Data;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SQL_InsertScriptGenerator_In1Click.Controllers
{
    public class SQLController : Controller
    {
        private readonly ISQLInsertScriptGeneratorService _repository;
        public SQLController(ISQLInsertScriptGeneratorService repository)
        {
                _repository = repository;
        }
        public IActionResult Index()
        {
            SqlScriptGeneratorModel model = new SqlScriptGeneratorModel
            {
                TN = new List<string>(),
                TF  =   new List<string>(),
                chk= ConfigurationData.GetCourses(),
                 GeneratedScript = string.Empty
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index(SqlScriptGeneratorModel model)
        {
            if (ModelState.IsValid)
            {
                var ds = new DataTable();

                ds.Columns.Add("TableCount", typeof(int));
                ds.Columns.Add("TableName", typeof(System.String));
                ds.Columns.Add("SearchCondition", typeof(System.String));

                for (int i = 0; i < model.TableCount; i++)
                {
                    ds.Rows.Add(model.TableCount, model.TN[i].Trim(), model.TF[i].Trim());
                }

                model.GeneratedScript =await _repository.GenerateInsertScriptAsync(ds, model.TableCount, 
                    model.chk[0].IsChecked,
                    model.chk[1].IsChecked,
                    model.chk[2].IsChecked,
                    model.chk[3].IsChecked,
                    model.chk[4].IsChecked
                  );
            }

            return View(model);
        }
       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }

}
