using System.ComponentModel.DataAnnotations;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        [Display(Name = "#")] public int Id { get; set; }
        [Display(Name = "Nome")] public string Name { get; set; } = string.Empty;
        [Display(Name = "e-Mail")] public string Email { get; set; } = string.Empty;
        [Display(Name = "Data Aviversário")] public DateTime BirthDate { get; set; }
        [Display(Name = "Salário base")]  public double BaseSalary { get; set; }
        [Display(Name = "Departamento")] public Department Department { get; set; } = new Department();
        [Display(Name = "Vendas")] public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();


        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public Seller() { }

        public void AddSales(SalesRecord sales)
        {
            Sales.Add(sales);
        }

        public void RemoveSales(SalesRecord sales)
        {
            Sales.Remove(sales);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}
