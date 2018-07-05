//Anthony Zoellner
//Project 1

using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStoreApplicationLibrary
{
    public class Pizza
    {
        public double SizeModifier = 1.0;
        public double DoughUsage { get; set; } = 0;
        public double SauceUsage { get; set; } = 0;
        public double CheeseUsage { get; set; } = 0;
        public double PepperoniUsage { get; set; } = 0;
        public double HamAndMeatballUsage { get; set; } = 0;
        public double PepperAndOnionUsage { get; set; } = 0;


        public Pizza(int size, int type)
        {
            SizeModifierSet(size);
            switch (type)
            {
                case 1:
                    CheesePizza(SizeModifier);
                    break;
                case 2:
                    PepperoniPizza(SizeModifier);
                    break;
                case 3:
                    MeatPizza(SizeModifier);
                    break;
                case 4:
                    VeggieAndPepperoniPizza(SizeModifier);
                    break;
                default:
                    break;
            }
        }

        public void SizeModifierSet(int PizzaSize)
        {
            int SwitchCase = PizzaSize;
            switch (SwitchCase)
            {
                case 1:
                    SizeModifier = 1;
                    break;
                
                case 2:
                    SizeModifier = 1.5;
                    break;

                case 3:
                    SizeModifier = 2;
                    break;
            }
        }

        public void CheesePizza(double sizeModifier)
        {
            DoughUsage = sizeModifier * 1;
            SauceUsage = sizeModifier * 1;
            CheeseUsage = sizeModifier * 1;
        }

        public void PepperoniPizza(double sizeModifier)
        {
            DoughUsage = sizeModifier * 1;
            SauceUsage = sizeModifier * 1;
            CheeseUsage = sizeModifier * 1;
            PepperoniUsage = sizeModifier * 1;
        }

        public void VeggieAndPepperoniPizza(double sizeModifier)
        {
            DoughUsage = sizeModifier * 1;
            SauceUsage = sizeModifier * 1;
            CheeseUsage = sizeModifier * 1;
            PepperoniUsage = sizeModifier * 1;
            PepperAndOnionUsage = sizeModifier * 1;
        }

        public void MeatPizza(double sizeModifier)
        {
            DoughUsage = sizeModifier * 1;
            SauceUsage = sizeModifier * 1;
            CheeseUsage = sizeModifier * 1;
            PepperoniUsage = sizeModifier * 1;
            HamAndMeatballUsage = sizeModifier * 1;
        }
    }
}
