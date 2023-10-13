using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        [Display(Name = "#")] public int Id { get; set; }
        [AllowNull][Display(Name = "Nome")] public string Name { get; set; }
        [Display(Name = "e-Mail")][DataType(DataType.EmailAddress)] public string? Email { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Data Aviversário")]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }
        [Display(Name = "Salário base")]
        [DataType(DataType.Currency)]
        //[DisplayFormat(DataFormatString = "{0:F2}")] 
        public double BaseSalary { get; set; }
        [AllowNull] public Department Department { get; set; }
        [Display(Name = "Departamento")] public int DepartmentId { get; set; }
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

        public Seller()
        {
        }

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
