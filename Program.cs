new one
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;


namespace SimplePizza
{
    class Program
    {
        static void Main(string[] args)
        {
            PizzaStore nyStore = new NYPizzaStore();
            PizzaStore chicagoStore = new ChicagoPizzaStore();

            Pizza pizza = nyStore.OrderPizza("cheese");
            Console.WriteLine("Alice ordered a " + pizza.GetName() + "\n");

            pizza = chicagoStore.OrderPizza("cheese");
            Console.WriteLine("Henry ordered a " + pizza.GetName() + "\n");
            }

    }
    public abstract class Pizza
    {
        protected string name;
        protected string dough;
        protected string sauce;
        protected ArrayList toppings = new ArrayList();

        public Pizza()
        { }

        public void Prepare()
        {
           
            Console.WriteLine("Preparing " + name + "\n");
            Console.WriteLine("Tossing " + dough + "\n");
            Console.WriteLine("Adding " + sauce + "\n");
            Console.WriteLine("Adding toppings:" + "\n");

            foreach (string topping in toppings)
            {
                Console.WriteLine("\t" + topping + "\n");
            }

           // return sb.ToString();
        }

        public void Bake()
        {
            Console.WriteLine("Bake for 25 minutes at 350 \n");
        }

        public void  Cut()
        {
            Console.WriteLine("Cutting the pizza into diagonal slices \n");
        }

        public void Box()
        {
            Console.WriteLine("Place pizza in official PizzaStore box \n");
        }

        public string GetName()
        {
            return name;
        }
    }

    public class ChicagoStyleCheesePizza : Pizza
    {
        public ChicagoStyleCheesePizza()
        {
            name = "Chicago Style Deep Dish Cheese Pizza";
            dough = "Extra Thick Crust Dough";
            sauce = "Plum Tomato Sauce";

            toppings.Add("Shredded Mozzarella Cheese");
        }


    }
    public abstract class PizzaStore
    {
        public PizzaStore()
        { }

        public Pizza OrderPizza(string type)
        {
            Pizza pizza;

            pizza = CreatePizza(type);

            pizza.Prepare();
            pizza.Bake();
            pizza.Cut();
            pizza.Box();

            return pizza;
        }

        protected abstract Pizza CreatePizza(string type);
    }

    public class NYStyleCheesePizza : Pizza
    {
        public NYStyleCheesePizza()
        {
            name = "NY Style Sauce and Cheese Pizza";
            dough = "Thin Crust Dough";
            sauce = "Martinara Sauce";

            toppings.Add("Greated Reggiano Cheese");
        }
    }
    public class NYPizzaStore : PizzaStore
    {
        public NYPizzaStore()
        { }

        protected override Pizza CreatePizza(string type)
        {
            if (type.Equals("cheese"))
            {
                return new NYStyleCheesePizza();
            }
            else return null;
        }

    }
    public class ChicagoPizzaStore : PizzaStore
    {
  
        public ChicagoPizzaStore()
        { }

        protected override Pizza CreatePizza(string type)
        {
            if (type.Equals("cheese"))
            {
                return new ChicagoStyleCheesePizza();
            }
            else return null;
        }
    }

}
