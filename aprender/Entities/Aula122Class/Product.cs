﻿using System;
using System.Collections.Generic;
using System.Text;

namespace aprender.Entities.Aula122Class
{
    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Product()
        {
        }

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }
    }
}
