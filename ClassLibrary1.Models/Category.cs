using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary1.Models
{
    public class Category
    {
        public int ID { get; set; }
        [Required, DisplayName("Category Name"), MaxLength(40)]
        public string Name { get; set; }
        [DisplayName("Display Order"), Range(1, 100)]
        public int DisplayOrder { get; set; }

    }
}
