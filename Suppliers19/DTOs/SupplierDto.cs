using System.ComponentModel.DataAnnotations;

namespace Suppliers19;

public class SupplierDto
{
    [Required]
    public string CompanyName { get; set; } = "";

    [Required, EmailAddress]
    public string ContactEmail { get; set; } = "";

    [Required, Phone]
    public string ContactPhone { get; set; } = "";

    public DateTime StartDate { get; set; }
}
