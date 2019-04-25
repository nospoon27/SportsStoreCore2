using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using static SportsStore.Models.Cart;

namespace SportsStore.Tests
{
    public class CartTests
    {
        [Fact]
        public void Can_Add_New_Lines()
        {
            // Организация - создание нескольких тестовых товаров
            Product p1 = new Product { ProductID = 1, Name = "P1" };
            Product p2 = new Product { ProductID = 2, Name = "P2" };
            // Организация - создание новой корзины
            Cart target = new Cart();

            // Действия
            target.AddItem(p1, 1);
            target.AddItem(p2, 1);
            CartLine[] result = target.Lines.ToArray();

            // Утверждение
            Assert.Equal(2, result.Length);
            Assert.Equal(p1, result[0].Product);
            Assert.Equal(p2, result[1].Product);
        }

        [Fact]
        public void Can_Add_Quantity_Existing_Lines()
        {
            // Организация - создание нескольких тестовых товаров
            Product p1 = new Product { ProductID = 1, Name = "P1" };
            Product p2 = new Product { ProductID = 2, Name = "P2" };
            Product p3 = new Product { ProductID = 3, Name = "P3" };
            // Организация - создание новой корзины
            Cart target = new Cart();

            //Организация - добавление некоторых товаров в корзину
            target.AddItem(p1, 1);
            target.AddItem(p2, 3);
            target.AddItem(p3, 5);
            target.AddItem(p2, 1);

            //Действие
            target.RemoveLine(p2);

            //Утверждение
            var count = target.Lines.Where(c => c.Product == p2).Count();
            Assert.Equal(0, count);
            Assert.Equal(2, target.Lines.Count());
        }

        [Fact]
        public void Calculate_Cart_Total()
        {
            Product p1 = new Product { ProductID = 1, Name = "P1", Price = 100M };
            Product p2 = new Product { ProductID = 2, Name = "P2", Price = 50M };

            //Оганизация - создание корзины
            Cart target = new Cart();
            //Действие
            target.AddItem(p1, 1);
            target.AddItem(p2, 1);
            target.AddItem(p1, 3);
            decimal result = target.ComputeTotalValue();

            // Утверждение
            Assert.Equal(450M, result);
        }

        [Fact]
        public void Can_Clear_Contents()
        {
            Product p1 = new Product { ProductID = 1, Name = "P1", Price = 100M };
            Product p2 = new Product { ProductID = 2, Name = "P2", Price = 50M };

            // Организация - создание новой корзины
            Cart target = new Cart();

            //Организация - добавление нескольких элементов в корзину
            target.AddItem(p1, 1);
            target.AddItem(p2, 1);

            //Действие - очистка корзины
            target.Clear();

            // Утверждение
            var count = target.Lines.Count();
            Assert.Equal(0, count);
        }
    }
}
