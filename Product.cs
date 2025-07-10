using System.Data.Common;

namespace ProdReg;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public DateTime RegistrationDate { get; set; }
}