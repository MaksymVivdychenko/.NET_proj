using NET_proj.Data;
using NET_proj.Factory;
using NET_proj.Decorator;
using NET_proj.Observer;
using NET_proj.File_Loaders;
using System.Globalization;
class Program
{
    static readonly Cart cart = new();
    static readonly NotificationService notificationService = new();

    static void Main() {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

        var exit = false;
        var is_registered = false;

        var init_msg = " - 1. Створити користувача\n" +
                       " - 0. Вийти";
        var auth_msg = " - 1. Додати товар\n" +
                       " - 2. Переглянути кошик\n" +
                       " - 3. Зберегти замовлення\n" +
                       " - 4. Отримати новини\n" +
                       " - 0. Вийти";
        while (!exit)
        {
            Console.WriteLine("Перелік дій:");
            if (!is_registered) 
            {
                Console.WriteLine($"{init_msg}\n");
                Console.Write("Оберіть дію: ");
                var option = Console.ReadLine();
                Console.Clear();
                switch (option) 
                {
                    case "1": notificationService.Subscribe(CreateCustomer()); is_registered = true; break;
                    case "0": exit = true; break;
                    default: Console.WriteLine("Невідома опція\n"); break;
                }
            }
            else 
            {
                Console.WriteLine($"{auth_msg}\n");
                Console.Write("Оберіть дію: ");
                var option = Console.ReadLine();
                Console.Clear();
                switch (option)
                {
                    case "1": AddProductMenu(); break;
                    case "2": cart.DisplayCart(); break;
                    case "3": SaveOrder(); break;
                    case "4": NotifyCustomer(); break;
                    case "0": exit = true; break;
                    default: Console.WriteLine("Невідома опція\n"); break;
                }
            }
        }
    }
    static Customer CreateCustomer() 
    {
        string? name = null;
        while (name is null)
        {
            Console.WriteLine("Введіть ім'я користувача:");
            name = Console.ReadLine();
            Console.Clear();
        }
        return new Customer(name);
    }

    static void AddProductMenu()
    {
        Console.WriteLine("\n-- Категорії --\n1. Одяг\n2. Електроніка\n3. Їжа");
        Console.Write("Оберіть категорію: ");
        string? CategoryChoice = Console.ReadLine();
        ProductFactory factory;
        switch(CategoryChoice)
        { 
            case "1":
                factory = new ClothingFactory();
                break;
            case "2":
                factory = new ElectronicsFactory();
                break;
            case "3":
                factory = new FoodFactory();
                break;
            default:
                throw new Exception("Невідома категорія");
        }
        List<Product> products =  LoadProducts(factory);
        for (int i = 0; i < products.Count; i++)
        {
            Console.Write($" {i}. ");
            Console.WriteLine(products[i].GetDetails());
        }
        Console.WriteLine("Виберіть товар для придбання:");
        int value = int.Parse(Console.ReadLine()!);
        Console.WriteLine("Чи бажаєте додати подарункову обгортку(+3 грн)?(так/ні)");
        string wrappingOption = Console.ReadLine()!;
        if (wrappingOption == "так")
        {
            products[value] = new GiftWrapDecorator(products[value]);
        }
        cart.AddProduct(products[value]);
        Console.WriteLine("Товар успішно додано!");
        return;
    }

    static List<Product> LoadProducts(ProductFactory factory)
    {
        FileLoader loader = GetLoader.GetFileLoaderTxt(factory);
        return loader.LoadProducts();
    }

    static void SaveOrder()
    {
        cart.SaveToFile("order.txt");
        Console.WriteLine("Замовлення збережено у 'order.txt'\n");
    }

    static void NotifyCustomer()
    {
        var r = new Random();
        var prob = 70;
        var curr = r.Next(0, 100) + 1;

        var ids = cart.GetCartProducts().ToList();

        if (!ids.Any()) 
        {
            notificationService.Notify($"У кошишку нема товарів!\n");
        }
        else 
        {
            var discount_product = ids[r.Next(0, ids.Count())];

            var msg = curr < prob ? $"Є нова знижка на товар {discount_product.Name}! Ціна: {discount_product.Price * 0.8m:F3}" : "Нових знижок нема.";
            notificationService.Notify($"{msg}\n");
        }     
    }
}

