using PizzaStoreApplicationLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PizzaStoreApplicationTest
{
    public class UserTest
    {
        [Fact]
        public void UserFavoritePizzaShouldBePepperoniIfPepperoniIsMostOrderedPizza()
        {
            string expected = "Pepperoni";

            User CurrentUser = new User();
            CurrentUser.CheeseOrdered = 100;
            CurrentUser.PepperoniOrdered = 100;
            CurrentUser.MeatOrdered = 100;
            CurrentUser.VeggieOrdered = 100;

            List<int> size = new List<int>();
            List<int> type = new List<int>();
            size.Add(1);
            type.Add(2);

            Order NewOrder = new Order(CurrentUser, "Reston", 1, size, type, 8.00);

            CurrentUser.UserFavoritePizza(NewOrder);
            string actual = CurrentUser.FavoritePizza;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void UserFavoritePizzaShouldBeCheeseIfCheeseIsMostOrderedPizza()
        {
            string expected = "Cheese";

            User CurrentUser = new User();
            CurrentUser.CheeseOrdered = 100;
            CurrentUser.PepperoniOrdered = 100;
            CurrentUser.MeatOrdered = 100;
            CurrentUser.VeggieOrdered = 100;

            List<int> size = new List<int>();
            List<int> type = new List<int>();
            size.Add(1);
            type.Add(1);

            Order NewOrder = new Order(CurrentUser, "Reston", 1, size, type, 8.00);

            CurrentUser.UserFavoritePizza(NewOrder);
            string actual = CurrentUser.FavoritePizza;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void UserFavoritePizzaShouldBeMeatIfMeatIsMostOrderedPizza()
        {
            string expected = "Meat";

            User CurrentUser = new User();
            CurrentUser.CheeseOrdered = 100;
            CurrentUser.PepperoniOrdered = 100;
            CurrentUser.MeatOrdered = 100;
            CurrentUser.VeggieOrdered = 100;

            List<int> size = new List<int>();
            List<int> type = new List<int>();
            size.Add(1);
            type.Add(3);

            Order NewOrder = new Order(CurrentUser, "Reston", 1, size, type, 8.00);

            CurrentUser.UserFavoritePizza(NewOrder);
            string actual = CurrentUser.FavoritePizza;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void UserFavoritePizzaShouldBeVeggieIfVeggieIsMostOrderedPizza()
        {
            string expected = "Veggie";

            User CurrentUser = new User();
            CurrentUser.CheeseOrdered = 100;
            CurrentUser.PepperoniOrdered = 100;
            CurrentUser.MeatOrdered = 100;
            CurrentUser.VeggieOrdered = 100;

            List<int> size = new List<int>();
            List<int> type = new List<int>();
            size.Add(1);
            type.Add(4);

            Order NewOrder = new Order(CurrentUser, "Reston", 1, size, type, 8.00);

            CurrentUser.UserFavoritePizza(NewOrder);
            string actual = CurrentUser.FavoritePizza;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void UserFavoritePizzaShouldIncrementCheeseByNumberOfCheesePizzasOrdered()
        {
            string expected = "101";

            User CurrentUser = new User();
            CurrentUser.CheeseOrdered = 100;
            CurrentUser.PepperoniOrdered = 100;
            CurrentUser.MeatOrdered = 100;
            CurrentUser.VeggieOrdered = 100;

            List<int> size = new List<int>();
            List<int> type = new List<int>();
            size.Add(1);
            type.Add(1);

            size.Add(1);
            type.Add(2);
            size.Add(1);
            type.Add(2);

            size.Add(1);
            type.Add(3);

            size.Add(1);
            type.Add(4);
            size.Add(1);
            type.Add(4);
            size.Add(1);
            type.Add(4);

            Order NewOrder = new Order(CurrentUser, "Reston", 1, size, type, 8.00);

            CurrentUser.UserFavoritePizza(NewOrder);
            string actual = CurrentUser.CheeseOrdered.ToString();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void UserFavoritePizzaShouldIncrementPepperoniByNumberOfPepperoniPizzasOrdered()
        {
            string expected = "102";

            User CurrentUser = new User();
            CurrentUser.CheeseOrdered = 100;
            CurrentUser.PepperoniOrdered = 100;
            CurrentUser.MeatOrdered = 100;
            CurrentUser.VeggieOrdered = 100;

            List<int> size = new List<int>();
            List<int> type = new List<int>();
            size.Add(1);
            type.Add(1);

            size.Add(1);
            type.Add(2);
            size.Add(1);
            type.Add(2);

            size.Add(1);
            type.Add(3);

            size.Add(1);
            type.Add(4);
            size.Add(1);
            type.Add(4);
            size.Add(1);
            type.Add(4);

            Order NewOrder = new Order(CurrentUser, "Reston", 1, size, type, 8.00);

            CurrentUser.UserFavoritePizza(NewOrder);
            string actual = CurrentUser.PepperoniOrdered.ToString();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void UserFavoritePizzaShouldIncrementMeatByNumberOfMeatPizzasOrdered()
        {
            string expected = "101";

            User CurrentUser = new User();
            CurrentUser.CheeseOrdered = 100;
            CurrentUser.PepperoniOrdered = 100;
            CurrentUser.MeatOrdered = 100;
            CurrentUser.VeggieOrdered = 100;

            List<int> size = new List<int>();
            List<int> type = new List<int>();
            size.Add(1);
            type.Add(1);

            size.Add(1);
            type.Add(2);
            size.Add(1);
            type.Add(2);

            size.Add(1);
            type.Add(3);

            size.Add(1);
            type.Add(4);
            size.Add(1);
            type.Add(4);
            size.Add(1);
            type.Add(4);

            Order NewOrder = new Order(CurrentUser, "Reston", 1, size, type, 8.00);

            CurrentUser.UserFavoritePizza(NewOrder);
            string actual = CurrentUser.MeatOrdered.ToString();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void UserFavoritePizzaShouldIncrementVeggieByNumberOfVeggiePizzasOrdered()
        {
            string expected = "103";

            User CurrentUser = new User();
            CurrentUser.CheeseOrdered = 100;
            CurrentUser.PepperoniOrdered = 100;
            CurrentUser.MeatOrdered = 100;
            CurrentUser.VeggieOrdered = 100;

            List<int> size = new List<int>();
            List<int> type = new List<int>();
            size.Add(1);
            type.Add(1);

            size.Add(1);
            type.Add(2);
            size.Add(1);
            type.Add(2);

            size.Add(1);
            type.Add(3);

            size.Add(1);
            type.Add(4);
            size.Add(1);
            type.Add(4);
            size.Add(1);
            type.Add(4);

            Order NewOrder = new Order(CurrentUser, "Reston", 1, size, type, 8.00);

            CurrentUser.UserFavoritePizza(NewOrder);
            string actual = CurrentUser.VeggieOrdered.ToString();

            Assert.Equal(expected, actual);
        }
    }
}
