using ProdReg;

namespace ProdRep;

public class ProductRepository
{
    public List<Product> products = new List<Product>();


    public void DataSave()
    {
        var json = System.Text.Json.JsonSerializer.Serialize(products);

        File.WriteAllText("Products.txt", json);
    }

    public void GetData()
    {
        if (File.Exists("Products.txt"))
        {
            var dados = File.ReadAllText("Products.txt");

            var arquive = System.Text.Json.JsonSerializer.Deserialize<List<Product>>(dados);
            products.AddRange(arquive);
        }
    }

    public void ProductPrint(Product product)
    {
        Console.WriteLine("ID.............   " + product.Id);
        Console.WriteLine("Nome...........   " + product.Name);
        Console.WriteLine("Preço..........   " + product.Price);
        Console.WriteLine("Data Cadastro..   " + product.RegistrationDate);
    }
    public void GetProduct()
    {

        Console.Clear();
        Console.WriteLine("Produtos cadastrados: ");
        Console.Write(Environment.NewLine);
        products?.ForEach(p => ProductPrint(p));
        Console.WriteLine("Menu [Enter]");
    }
    public void ProductRegister()
    {
        Console.Clear();

        Console.Write("Nome do produto: ");
        var name = Console.ReadLine();
        Console.Write(Environment.NewLine);

        Console.Write("Preço do produto: ");
        var price = Console.ReadLine();

        var id = products.Count + 1;
        var registration = DateTime.Now;

        var produto = new Product();

        produto.Id = id;
        produto.Name = name;
        produto.Price = int.Parse(price);
        produto.RegistrationDate = registration;


        products.Add(produto);
        Console.Clear();
        ProductPrint(produto);
        Console.Write(Environment.NewLine);
        Console.WriteLine("Produto Cadastrado! [Enter]");
    }

    public void ProductEdit()
    {
        Console.Clear();
        Console.Write("Digite o ID do produto: ");
        var number = Console.ReadLine();
        var produto = products.FirstOrDefault(y => y.Id == int.Parse(number));

        ProductPrint(produto);
        Console.Write(Environment.NewLine);


        Console.Write("Nome do produto: ");
        var name = Console.ReadLine();
        Console.Write(Environment.NewLine);

        Console.Write("Preço do produto: ");
        var price = Console.ReadLine();
        Console.Write(Environment.NewLine);

        produto.Name = name;
        produto.Price = int.Parse(price);

        ProductPrint(produto);
        Console.Write("Produto Alterado! [Enter]");
    }

    public void ProductDelete()
    {
        Console.Clear();
        Console.Write("Digite o ID do produto: ");
        var number = Console.ReadLine();
        var produto = products.FirstOrDefault(y => y.Id == int.Parse(number));
        products.Remove(produto);
        Console.WriteLine("Produco removido com sucesso! [Enter]"); 
    }
}