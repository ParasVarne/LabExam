using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LabExam.Models
{
    public class Product
    {
        [Key]
        [DataType(DataType.Text)]
        [Required(ErrorMessage ="Please enter Product Id")]
        [Display(Name ="Product Id")]
        public int ProductId { set; get; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter Product Name")]
        [Display(Name = "Product Name")]
        public string ProductName { set; get; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter Rate")]
        [Display(Name = "Rate")]
        public int Rate { set; get; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter Product Description")]
        [Display(Name = "Description")]
        public string Description { set; get; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter Product Category")]
        [Display(Name = "Category")]
        public string Category { set; get; }



    }
}