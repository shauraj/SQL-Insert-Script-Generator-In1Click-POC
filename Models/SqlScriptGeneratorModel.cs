using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace SQL_InsertScriptGenerator_In1Click.Models
{
    public class SqlScriptGeneratorModel
    {
        [Required(ErrorMessage = "TableCount is required and it will only take Input as Number.")]
        [Range(1, 50, ErrorMessage = "The Number of Table Count should be between 1 and 50.")]
        public int TableCount { get; set; }
    
        [Required(ErrorMessage = "Enter the Table Name with Schema.")]
        public List<string>? TN { get; set; }

        [Required(ErrorMessage = "Enter the Table Filter Criteria.")]
        public List<string>? TF { get; set; }
     
        public IReadOnlyList<ConfigurationCheckboxModel>? chk {  get; set; }

        [ValidateNever]
        public String? GeneratedScript { get; set; }
    }
    public class ConfigurationCheckboxModel
    {
        public int Id { get; set; }
        public string? ConfigurationName { get; set; }
        public bool IsChecked { get; set; }
    }
     
    }

