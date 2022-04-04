using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        ICollection<Seller> Seller { get; set; } = new List<Seller>();   
        

        public Department() { 
        }

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public double TotalSales(DateTime initian, DateTime final)
        {
            return Seller.Sum(seller => seller.TotalSales(initian, final));
        }
    }
}
