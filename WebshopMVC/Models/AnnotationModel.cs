using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebshopMVC.Models
{
    [MetadataType(typeof(CategoryMetaData))]
    public partial class Category
    {

    }
    public class CategoryMetaData
    {
        [Display(Name ="Category")]
        public string Name { get; set; }
        [Display(Name ="Category")]
        public int ID { get; set; }
    }
}