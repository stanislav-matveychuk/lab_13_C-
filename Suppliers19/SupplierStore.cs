namespace Suppliers19;

public class SupplierStore
{
    public List<Supplier> Suppliers { get; } = new List<Supplier>
    {
        new Supplier
        {
            Id = 1,
            CompanyName = "Офіс Плюс",
            ContactEmail = "office@example.com",
            ContactPhone = "+380501234567",
            StartDate = new DateTime(2025, 9, 1)
        },
        new Supplier
        {
            Id = 2,
            CompanyName = "ТехноСвіт",
            ContactEmail = "tech@example.com",
            ContactPhone = "+380671234567",
            StartDate = new DateTime(2026, 2, 15)
        }
    };

    public object SyncRoot { get; } = new object();
    public int NextId { get; set; } = 3;
}
