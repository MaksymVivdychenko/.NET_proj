using System;
using System.Collections.Generic;
using System.IO;
using NET_proj.Data;
using NET_proj.Factory;
using NET_proj.Decorator;
using NET_proj.Observer;
using NET_proj.File_Loaders;

class Program
{
    static Cart cart = new();
    static NotificationService notificationService = new();
    static Customer customer = new() { Name = "Клієнт" };

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;
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
        notificationService.Notify("Дякуємо за замовлення! Нові знижки до -30%!\n");
    }
}

