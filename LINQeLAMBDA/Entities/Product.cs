using System;
using System.Collections.Generic;
using System.Text;

namespace LINQeLAMBDA.Entities
{
    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        // Associação Category
        public Category Category { get; set; }
        public Product()
        {

        }
        public Product(int id, string name, double price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return Id
                + ", "
                + Name
                + ", "
                + Price.ToString("F2")
                + ", "
                + Category.Name
                + ", "
                + Category.Tier;
        }
    }
}
