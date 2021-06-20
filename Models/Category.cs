using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EmployeeCoreApp.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(1, 100, ErrorMessage = "Display order for category must be greater than zero ")]
        [System.ComponentModel.DisplayName("Display Order")]
        public string DisplayCategory { get; set; }


    }
}
