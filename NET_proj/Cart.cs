﻿using NET_proj.Data;

class Cart
{
    private List<Product> _items = new();
    public void AddProduct(Product product) => _items.Add(product);
    public void DisplayCart()
    {
        Console.WriteLine("\n-- Ваш кошик --");
        if (_items.Count == 0) Console.WriteLine("(порожній)");
        foreach (var item in _items)
            Console.WriteLine(item.GetDetails());
        Console.WriteLine("----------------\n");
    }
    public void SaveToFile(string path)
    {
        using StreamWriter writer = new(path);
        foreach (var item in _items)
            writer.WriteLine(item.GetDetails());
    }
}

