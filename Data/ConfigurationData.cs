using SQL_InsertScriptGenerator_In1Click.Models;

namespace SQL_InsertScriptGenerator_In1Click.Data
{
    public class ConfigurationData
    {
        public static IReadOnlyList<ConfigurationCheckboxModel> GetCourses()
        {
            return new List<ConfigurationCheckboxModel>
    {
        new ConfigurationCheckboxModel
        {
            Id = 1,
            ConfigurationName = "Populate Identity Column",
            IsChecked = true
        },
        new ConfigurationCheckboxModel
        {
            Id = 2,
            ConfigurationName = "Generate Single Insert Per Row",
            IsChecked = false
        },
        new ConfigurationCheckboxModel
        {
            Id = 3,
            ConfigurationName = "Generate Project Info",
            IsChecked = false
        },
        new ConfigurationCheckboxModel
        {
            Id = 4,
            ConfigurationName = "Generate Go Statment",
            IsChecked = false
        },
         new ConfigurationCheckboxModel
        {
            Id = 5,
            ConfigurationName = "Format Code",
            IsChecked = false
        },
    };
        }
    }
}
