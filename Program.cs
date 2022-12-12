using JalasoftDevLevel1.ItalianRestaurant;
using System;
using System.Collections.Generic;

//Define a struct to represent a dish
struct Dish
{

    public int IdDish { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }   
}

//Define a struct to represent a beverage
struct Beverage
{
    public int IdBeverage{ get; set; }
    public string Name { get; set; }        
    public decimal Price{ get; set; }       
}



struct Order
{

    public int OrderNumber;
    public string CustomerName { get; set; }

    public Dictionary<Dish, int> Dishes { get; set; }
    public Dictionary<Beverage, int> Beverages { get; set; }
   
    public decimal TotalCost;

    public PaymentMethod Payment;

}
class Program
{
    static void Main(string[] args)
    {

        // Create a list of dishes
        var dishes = new List<Dish>
        {
            new Dish { IdDish = 1 ,Name = "Spaghetti", Price = 10.99m },
            new Dish { IdDish = 2, Name = "Lasagna", Price = 12.99m },
            new Dish { IdDish = 3 ,Name = "Pizza", Price = 8.00m },
            new Dish { IdDish = 4, Name = "Calzone", Price = 6.00m },
        };

        // Create a list of beverages
        var beverages = new List<Beverage>
        {
            new Beverage { IdBeverage = 1 , Name = "Soda", Price = 6.50m },
            new Beverage { IdBeverage = 2 ,Name = "Wine", Price = 9.00m },
            new Beverage { IdBeverage = 3 ,Name = "Beer", Price = 7.50m },
        };
        //create a list of orders
        //var orders = new List<Tuple<string, Dictionary<Dish, int>, Dictionary<Beverage, int>, PaymentMethod>>();


        int orderNumber = 1;


        while (true)
        {
            List<Order> orders = new List<Order>();
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine("Receiving order " + i);
                Console.Write("Enter the customer's name: ");
                string customerName = Console.ReadLine();

                Order order = new Order();
                order.CustomerName = customerName;
                order.OrderNumber = orderNumber;



                Console.WriteLine("Select your dishes and quantity: ");

                while (true)
                {
                    Console.Write("The dishes menu is :");
                    foreach (var item in dishes)
                    {
                        
                        Console.Write($"{item.IdDish} {item.Name} {item.Price}, ");
                    }
                    Console.WriteLine("0 Exit");
                    int dishSelected = Convert.ToInt32(Console.ReadLine());

                    if (dishSelected == 0)
                    {
                    
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Quantity: ");
                        int quantity = Convert.ToInt32(Console.ReadLine());
                        Dish dish = new Dish();
                        dish = dishes.Find(x => x.IdDish == dishSelected);
                        Dictionary<Dish, int> keyValuePairs = new Dictionary<Dish, int>();
                        keyValuePairs.Add(dish, quantity);
                        order.Dishes = keyValuePairs;
                        order.TotalCost += (dish.Price * quantity);
                        Console.Clear();
                    }
                }




                while (true)
                {
                    Console.WriteLine("Select your beverages and quantity: ");
                    Console.Write("The beverages menu is :");
                    foreach (var item in beverages)
                    {
                        Console.Write($"{item.IdBeverage} {item.Name} {item.Price}, ");
                    }
                    Console.WriteLine("0 Exit");
                    int beverageSelected = Convert.ToInt32(Console.ReadLine());

                    if (beverageSelected == 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Quantity");
                        int quantity = Convert.ToInt32(Console.ReadLine());
                        Beverage beverage = new Beverage();
                        beverage = beverages.Find(y => y.IdBeverage == beverageSelected);
                        Dictionary<Beverage, int> keyValuePairs = new Dictionary<Beverage, int>();
                        keyValuePairs.Add(beverage, quantity);
                        order.Beverages = keyValuePairs;
                        order.TotalCost += (beverage.Price * quantity);
                        Console.Clear();
                    }
                }

                Console.WriteLine("Select your paymend method: ");
                Console.WriteLine("1 Cash");
                Console.WriteLine("2 Card");
                int paymentSelected = Convert.ToInt32(Console.ReadLine());
                PaymentMethod paymentMethod = (PaymentMethod)paymentSelected;
                order.Payment = paymentMethod;
                orders.Add(order);
                
            }
            orderNumber++;

            foreach (var item in orders)
            {
                Console.WriteLine($"Delivering order {item.OrderNumber} - Customer {item.CustomerName}:");
                foreach (var d in item.Dishes)
                {
                    Console.Write(d.Value  +" "+ d.Key.Name+ "(s) "+" ");
                }
                foreach (var b in item.Beverages)
                {
                    Console.Write(b.Value +" " +b.Key.Name +"(s) "+" ");
                }
                Console.WriteLine($"total cost: {item.TotalCost} / payment method {item.Payment}");
            }
            orders.Clear();
        }
    }
}