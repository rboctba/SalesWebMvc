using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalesWebMvc.Models
{

    public class Department
    {

        [Display(Name = "#")] public int Id { get; set; }
        [Display(Name = "Departamento")] public string Name { get; set; } = string.Empty;

        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public Department()
        {
            
        }

        
        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AddSellers(Seller seller)
        {
            Sellers.Add(seller);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sellers.Sum(seller => seller.TotalSales(initial, final));
         }

    }
}
