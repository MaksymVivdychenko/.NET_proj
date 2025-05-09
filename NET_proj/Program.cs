using System;
using System.Collections.Generic;
using System.IO;
using NET_proj.Data;
using NET_proj.Factory;
using NET_proj.Decorator;
using NET_proj.Observer;

class Program
{
    static Cart cart = new();
    static NotificationService notificationService = new();
    static Customer customer = new() { Name = "Клієнт" };

    static void Main()
    {
        notificationService.Register(customer);

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("1. Додати товар\n2. Переглянути кошик\n3. Зберегти замовлення\n4. Отримати новини\n0. Вихід");
            Console.Write("Оберіть дію: ");
            switch (Console.ReadLine())
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

    static void AddProductMenu()
    {
        Console.WriteLine("\n-- Категорії --\n1. Електроніка\n2. Одяг\n3. Їжа");
        Console.Write("Оберіть категорію: ");
        string choice = Console.ReadLine();

        ProductFactory factory = choice switch
        {
            "1" => new ElectronicsFactory(),
            "2" => new ClothingFactory(),
            "3" => new FoodFactory(),
            _ => null
        };

        if (factory == null)
        {
            Console.WriteLine("Невірна категорія\n");
            return;
        }

        Console.Write("Назва товару: ");
        string name = Console.ReadLine();
        Console.Write("Ціна: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal price))
        {
            Console.WriteLine("Невірна ціна\n");
            return;
        }

        Product product = factory.CreateProduct(name, price);

        Console.Write("Додати подарункову упаковку? (y/n): ");
        if (Console.ReadLine()?.ToLower() == "y")
            product = new GiftWrapDecorator(product);

        cart.AddProduct(product);
        Console.WriteLine("Товар додано!\n");
    }

    static void SaveOrder()
    {
        cart.SaveToFile("order.txt");
        Console.WriteLine("Замовлення збережено у 'order.txt'\n");
    }

    static void NotifyCustomer()
    {
        notificationService.Notify("Дякуємо за замовлення! Нові знижки до -30%!\n");
    }
}

