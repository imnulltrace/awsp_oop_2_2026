using System;
using System.Collections.Generic;

public class Topping
{
    public string Name { get; set; }
    public double ExtraCost { get; set; }

    public Topping(string name, double extraCost)
    {
        Name = name;
        ExtraCost = extraCost;
    }
}

public class Pizza
{
    public string Size { get; set; }
    public double BasePrice { get; set; }
    public List<Topping> Toppings { get; private set; }

    public Pizza(string size, double basePrice)
    {
        Size = size;
        BasePrice = basePrice;
        Toppings = new List<Topping>();
    }

    public void AddTopping(Topping topping)
    {
        Toppings.Add(topping);
    }

    public double GetPrice()
    {
        double total = BasePrice;
        foreach (var t in Toppings)
            total += t.ExtraCost;
        return total;
    }

    public string Describe()
    {
        var names = new List<string>();
        foreach (var t in Toppings) names.Add(t.Name);
        string tops = names.Count > 0
            ? string.Join(", ", names) : "brak dodatków";
        return $"Pizza {Size} ({tops}) – {GetPrice():F2} zł";
    }
}

public class Order
{
    public string CustomerName { get; set; }
    public List<Pizza> Pizzas { get; private set; }

    public Order(string customerName)
    {
        CustomerName = customerName;
        Pizzas = new List<Pizza>();
    }

    public void AddItem(Pizza pizza)
    {
        Pizzas.Add(pizza);
    }

    public double CalculateTotal()
    {
        double total = 0;
        foreach (var p in Pizzas)
            total += p.GetPrice();
        return total;
    }

    public void PrintSummary()
    {
        Console.WriteLine($"===== Zamówienie: {CustomerName} =====");
        foreach (var p in Pizzas)
            Console.WriteLine($"  {p.Describe()}");
        Console.WriteLine($"Razem: {CalculateTotal():F2} zł");
    }
}

class Program
{
    static void Main()
    {
        var cheese = new Topping("Ser", 2.0);
        var pepperoni = new Topping("Pepperoni", 3.5);
        var mushrooms = new Topping("Pieczarki", 1.5);

        var pizza1 = new Pizza("duża", 25.0);
        pizza1.AddTopping(cheese);
        pizza1.AddTopping(pepperoni);

        var pizza2 = new Pizza("średnia", 20.0);
        pizza2.AddTopping(cheese);
        pizza2.AddTopping(mushrooms);

        var order = new Order("Jan Kowalski");
        order.AddItem(pizza1);
        order.AddItem(pizza2);
        order.PrintSummary();
    }
}