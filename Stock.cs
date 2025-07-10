using System.Globalization;
using ProdReg;
using ProdRep;

namespace StockReg;

public class Stock : Product
{

    public List<Stock> stock;

    //public int Id { get; set; }
    //public string Name { get; set; }
    public int Quantidade { get; set; }
    public int Store { get; set; }

    

}