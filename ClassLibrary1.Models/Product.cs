using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ClassLibrary1.Models
{
    public class Product
    {
        [ValidateNever]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string ISBN { get; set; }
        public string Author { get; set; }
   
        public double Price { get; set; }
        [Display(Name = "List price")]
        public double ListPrice { get; set; }
        public double Price50 { get; set; }
        public double Price100 { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))][ValidateNever]    
        public Category Category { get; set; }
        [ValidateNever]
        public String ImageUrl { get; set; }


    }
}
