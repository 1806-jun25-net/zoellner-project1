//Anthony Zoellner
//Project 1

using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStoreApplicationLibrary
{
    public class Pizza
    {
        enum Size { Small=1, Medium, Large};
        double SizeModifier;


        private void SizeModifierSet(int PizzaSize)
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

        public void CheesePizza()
        {
            
        }

        public void PepperoniPizza()
        {

        }

        public void VeggieAndPepperoniPizza()
        {

        }

        public void MeatPizza()
        {

        }
    }
}
