using System.Diagnostics.CodeAnalysis;

namespace SalesWebMvc.Models.ViewModels
{
    public class SellerFormViewModel
    {
        [AllowNull] public Seller Seller { get; set; }
        [AllowNull] public ICollection<Department> Departments { get; set; } 
    }
}
