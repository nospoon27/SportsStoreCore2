using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        [Required (ErrorMessage = "Введите наименование товара")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Введите описание товара")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Введите положительное значение для цены")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Введите категорию товара")]
        public string Category { get; set; }
    }
}
