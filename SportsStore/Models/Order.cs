﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static SportsStore.Models.Cart;

namespace SportsStore.Models
{
    public class Order
    {
        [BindNever]
        public int OrderID { get; set; }

        [BindNever]
        public ICollection<CartLine> Lines { get; set; }

        [BindNever]
        public bool Shipped { get; set; }

        [Required (ErrorMessage = "Введите имя")]
        public string Name { get; set; }

        [Required (ErrorMessage = "Введите первую строку адреса")]
        public string Line1 { get; set; }

        public string Line2 { get; set; }
        public string Line3 { get; set; }

        [Required (ErrorMessage = "Введите название города")]
        public string City { get; set; }

        [Required (ErrorMessage = "Введите название штата")]
        public string State { get; set; }
        public string Zip { get; set; }

        [Required (ErrorMessage = "Введите название страны")]
        public string Counrty { get; set; }
        public bool GiftWrap { get; set; }
    }
}
