using System.Diagnostics.CodeAnalysis;

namespace SalesWebMvc.Models.ViewModels
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }
        [AllowNull]public string Message { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}