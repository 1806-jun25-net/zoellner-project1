using PizzaStoreApplicationLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PizzaStoreApplicationTest
{
    public class LocationTest
    {
        //Resupply method tests
        [Fact]
        public void ResupplyShouldFillDoughTo1000()
        {
            double expected = 1000;

            Location TestLocation = new Location("Test");
            TestLocation.Dough = 0;

            TestLocation.Resupply();
            double actual = TestLocation.Dough;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ResupplyShouldFillSauceTo1000()
        {
            double expected = 1000;

            Location TestLocation = new Location("Test");
            TestLocation.Sauce = 0;

            TestLocation.Resupply();
            double actual = TestLocation.Sauce;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ResupplyShouldFillCheeseTo1000()
        {
            double expected = 1000;

            Location TestLocation = new Location("Test");
            TestLocation.Cheese = 0;

            TestLocation.Resupply();
            double actual = TestLocation.Cheese;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ResupplyShouldFillPepperoniTo1000()
        {
            double expected = 1000;

            Location TestLocation = new Location("Test");
            TestLocation.Pepperoni = 0;

            TestLocation.Resupply();
            double actual = TestLocation.Pepperoni;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ResupplyShouldFillPeppersAndOnionsTo1000()
        {
            double expected = 1000;

            Location TestLocation = new Location("Test");
            TestLocation.PeppersAndOnions = 0;

            TestLocation.Resupply();
            double actual = TestLocation.PeppersAndOnions;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ResupplyShouldFillHamandMeatballTo1000()
        {
            double expected = 1000;

            Location TestLocation = new Location("Test");
            TestLocation.HamAndMeatball = 0;

            TestLocation.Resupply();
            double actual = TestLocation.HamAndMeatball;

            Assert.Equal(expected, actual);
        }

        //CanMakePizza tests
        public static IEnumerable<object[]> GetTestData()
        {
            yield return new object[] { new int[] { 1, 1 } };
            yield return new object[] { new int[] { 1, 2 } };
            yield return new object[] { new int[] { 1, 3 } };
            yield return new object[] { new int[] { 1, 4 } };
            yield return new object[] { new int[] { 2, 1 } };
            yield return new object[] { new int[] { 2, 2 } };
            yield return new object[] { new int[] { 2, 3 } };
            yield return new object[] { new int[] { 2, 4 } };
            yield return new object[] { new int[] { 3, 1 } };
            yield return new object[] { new int[] { 3, 2 } };
            yield return new object[] { new int[] { 3, 3 } };
            yield return new object[] { new int[] { 3, 4 } };

        }

        public static IEnumerable<object[]> GetTestData2()
        {
            yield return new object[] { new int[] { 1, 2 } };
            yield return new object[] { new int[] { 1, 3 } };
            yield return new object[] { new int[] { 1, 4 } };
            yield return new object[] { new int[] { 2, 2 } };
            yield return new object[] { new int[] { 2, 3 } };
            yield return new object[] { new int[] { 2, 4 } };
            yield return new object[] { new int[] { 3, 2 } };
            yield return new object[] { new int[] { 3, 3 } };
            yield return new object[] { new int[] { 3, 4 } };

        }

        [Theory]
        [MemberData(nameof(GetTestData))]
        public void CanMakePizzaShouldBeAbleToMakePizza(int[] data)
        {
            Location TestLocation = new Location("Test");
            int size = data[0];
            int type = data[1];

            bool actual = TestLocation.CanMakePizza(size, type);

            Assert.True(actual);
        }

        [Theory]
        [MemberData(nameof(GetTestData))]
        public void CanMakePizzaShouldNotMakePizzaWithLowCheese(int[] data)
        {
            Location TestLocation = new Location("Test");
            TestLocation.Cheese = 0;
            int size = data[0];
            int type = data[1];

            bool actual = TestLocation.CanMakePizza(size, type);

            Assert.False(actual);
        }

        [Theory]
        [MemberData(nameof(GetTestData))]
        public void CanMakePizzaShouldNotMakePizzaWithLowSauce(int[] data)
        {
            Location TestLocation = new Location("Test");
            TestLocation.Sauce = 0;
            int size = data[0];
            int type = data[1];

            bool actual = TestLocation.CanMakePizza(size, type);

            Assert.False(actual);
        }

        [Theory]
        [MemberData(nameof(GetTestData2))]
        public void CanMakePizzaShouldNotMakePizzaWithLowPepperoni(int[] data)
        {
            Location TestLocation = new Location("Test");
            TestLocation.Pepperoni = 0;
            int size = data[0];
            int type = data[1];

            bool actual = TestLocation.CanMakePizza(size, type);

            Assert.False(actual);
        }

        [Theory]
        [InlineData(false, new int[] { 1, 4 })]
        [InlineData(false, new int[] { 2, 4 })]
        [InlineData(false, new int[] { 3, 4 })]
        public void CanMakePizzaShouldNotMakePizzaWithLowVeggies(bool expected, int[] data)
        {
            Location TestLocation = new Location("Test");
            TestLocation.PeppersAndOnions = 0;
            int size = data[0];
            int type = data[1];

            bool actual = TestLocation.CanMakePizza(size, type);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData (false, new int[] {1,3})]
        [InlineData (false, new int[] {2,3})]
        [InlineData (false, new int[] {3,3})]
        public void CanMakePizzaShouldNotMakePizzaWithLowMeat(bool expected, int[] data)
        {
            Location TestLocation = new Location("Test");
            TestLocation.HamAndMeatball = 0;
            int size = data[0];
            int type = data[1];

            bool actual = TestLocation.CanMakePizza(size, type);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(GetTestData))]
        public void CanMakePizzaShouldNotMakePizzaWithLowDough(int[] data)
        {
            Location TestLocation = new Location("Test");
            TestLocation.Dough = 0;
            int size = data[0];
            int type = data[1];

            bool actual = TestLocation.CanMakePizza(size, type);

            Assert.False(actual);
        }

        //DecreaseInventory tests

        [Theory]
        [InlineData(1,1)]
        [InlineData(1,2)]
        [InlineData(1,3)]
        [InlineData(1,4)]
        [InlineData(2,1)]
        [InlineData(2,2)]
        [InlineData(2,3)]
        [InlineData(2,4)]
        [InlineData(3,1)]
        [InlineData(3,2)]
        [InlineData(3,3)]
        [InlineData(3,4)]
        public void DecreaseInventoryShouldDecreaseDough(int size, int type)
        {
            Order TestOrder = new Order();
            TestOrder.DesiredSizes = new List<int>();
            TestOrder.DesiredTypes = new List<int>();
            TestOrder.DesiredSizes.Add(size);
            TestOrder.DesiredTypes.Add(type);

            Location TestLocation = new Location();
            TestLocation.DecreaseInventory(TestOrder);

            double actual = TestLocation.Dough;

            bool smaller = false;
            if (actual < 1000)
            {
                smaller = true;
            }

            Assert.True(smaller);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(1, 2)]
        [InlineData(1, 3)]
        [InlineData(1, 4)]
        [InlineData(2, 1)]
        [InlineData(2, 2)]
        [InlineData(2, 3)]
        [InlineData(2, 4)]
        [InlineData(3, 1)]
        [InlineData(3, 2)]
        [InlineData(3, 3)]
        [InlineData(3, 4)]
        public void DecreaseInventoryShouldDecreaseSauce(int size, int type)
        {
            Order TestOrder = new Order();
            TestOrder.DesiredSizes = new List<int>();
            TestOrder.DesiredTypes = new List<int>();
            TestOrder.DesiredSizes.Add(size);
            TestOrder.DesiredTypes.Add(type);

            Location TestLocation = new Location();
            TestLocation.DecreaseInventory(TestOrder);

            double actual = TestLocation.Sauce;

            bool smaller = false;
            if (actual < 1000)
            {
                smaller = true;
            }

            Assert.True(smaller);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(1, 2)]
        [InlineData(1, 3)]
        [InlineData(1, 4)]
        [InlineData(2, 1)]
        [InlineData(2, 2)]
        [InlineData(2, 3)]
        [InlineData(2, 4)]
        [InlineData(3, 1)]
        [InlineData(3, 2)]
        [InlineData(3, 3)]
        [InlineData(3, 4)]
        public void DecreaseInventoryShouldDecreaseCheese(int size, int type)
        {
            Order TestOrder = new Order();
            TestOrder.DesiredSizes = new List<int>();
            TestOrder.DesiredTypes = new List<int>();
            TestOrder.DesiredSizes.Add(size);
            TestOrder.DesiredTypes.Add(type);

            Location TestLocation = new Location();
            TestLocation.DecreaseInventory(TestOrder);

            double actual = TestLocation.Cheese;

            bool smaller = false;
            if (actual < 1000)
            {
                smaller = true;
            }

            Assert.True(smaller);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(1, 3)]
        [InlineData(1, 4)]
        [InlineData(2, 2)]
        [InlineData(2, 3)]
        [InlineData(2, 4)]
        [InlineData(3, 2)]
        [InlineData(3, 3)]
        [InlineData(3, 4)]
        public void DecreaseInventoryShouldDecreasePepperoni(int size, int type)
        {
            Order TestOrder = new Order();
            TestOrder.DesiredSizes = new List<int>();
            TestOrder.DesiredTypes = new List<int>();
            TestOrder.DesiredSizes.Add(size);
            TestOrder.DesiredTypes.Add(type);

            Location TestLocation = new Location();
            TestLocation.DecreaseInventory(TestOrder);

            double actual = TestLocation.Pepperoni;

            bool smaller = false;
            if (actual < 1000)
            {
                smaller = true;
            }

            Assert.True(smaller);
        }

        [Theory]
        [InlineData(1, 3)]
        [InlineData(2, 3)]
        [InlineData(3, 3)]
        public void DecreaseInventoryShouldDecreaseHamAndMeatball(int size, int type)
        {
            Order TestOrder = new Order();
            TestOrder.DesiredSizes = new List<int>();
            TestOrder.DesiredTypes = new List<int>();
            TestOrder.DesiredSizes.Add(size);
            TestOrder.DesiredTypes.Add(type);

            Location TestLocation = new Location();
            TestLocation.DecreaseInventory(TestOrder);

            double actual = TestLocation.HamAndMeatball;

            bool smaller = false;
            if (actual < 1000)
            {
                smaller = true;
            }

            Assert.True(smaller);
        }

        [Theory]
        [InlineData(1, 4)]
        [InlineData(2, 4)]
        [InlineData(3, 4)]
        public void DecreaseInventoryShouldDecreasePeppersAndOnions(int size, int type)
        {
            Order TestOrder = new Order();
            TestOrder.DesiredSizes = new List<int>();
            TestOrder.DesiredTypes = new List<int>();
            TestOrder.DesiredSizes.Add(size);
            TestOrder.DesiredTypes.Add(type);

            Location TestLocation = new Location();
            TestLocation.DecreaseInventory(TestOrder);

            double actual = TestLocation.PeppersAndOnions;

            bool smaller = false;
            if (actual < 1000)
            {
                smaller = true;
            }

            Assert.True(smaller);
        }

        //CostCalculator Tests
        [Theory]
        [InlineData(1, 1)]
        [InlineData(1, 2)]
        [InlineData(1, 3)]
        [InlineData(1, 4)]
        [InlineData(2, 1)]
        [InlineData(2, 2)]
        [InlineData(2, 3)]
        [InlineData(2, 4)]
        [InlineData(3, 1)]
        [InlineData(3, 2)]
        [InlineData(3, 3)]
        [InlineData(3, 4)]
        public void CostCalculatorShouldAllowPeopleToAddIfNotInDangerOfGoingOverLimit(int size, int type)
        {
            double CurrentTotal = 0;

            Location TestLocation = new Location();

            bool Overlimit = false;
            Overlimit = TestLocation.CostCalculator(size, type, CurrentTotal);

            Assert.False(Overlimit);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(1, 2)]
        [InlineData(1, 3)]
        [InlineData(1, 4)]
        [InlineData(2, 1)]
        [InlineData(2, 2)]
        [InlineData(2, 3)]
        [InlineData(2, 4)]
        [InlineData(3, 1)]
        [InlineData(3, 2)]
        [InlineData(3, 3)]
        [InlineData(3, 4)]
        public void CostCalculatorShouldNotAllowPeopleToAddToAnOrderIfInDangerOfGoingOverLimit(int size, int type)
        {
            double CurrentTotal = 499.00;

            Location TestLocation = new Location();

            bool Overlimit = false;
            Overlimit = TestLocation.CostCalculator(size, type, CurrentTotal);

            Assert.True(Overlimit);
        }

        //LastOrderTwoHoursAgo tests
        [Fact]
        public void LastOrderTwoHoursAgoShouldNotAllowSomeoneToOrderTwiceInTwoHours()
        {
            bool expected = false;

            Location TestLocation = new Location();

            Order CurrentOrder = new Order();
            CurrentOrder.OrderPlaced = DateTime.Now;

            User NewUser = new User();
            NewUser.Username = "Tester";
            CurrentOrder.username = NewUser.Username;

            TestLocation.OrderHistory.Add(CurrentOrder);
            bool actual = TestLocation.LastOrderOverTwoHoursAgo(NewUser);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LastOrderTwoHoursAgoShouldAllowSomeoneToOrderTwiceInMoreThanTwoHours()
        {
            bool expected = true;

            Location TestLocation = new Location();

            Order CurrentOrder = new Order();

            DateTime CurrentDateTime = new DateTime();
            CurrentDateTime = DateTime.Now;
            DateTime TwoHoursAgo = new DateTime();
            TwoHoursAgo = CurrentDateTime - TimeSpan.FromHours(2);
            CurrentOrder.OrderPlaced = TwoHoursAgo;

            User NewUser = new User();
            NewUser.Username = "Tester";
            CurrentOrder.username = NewUser.Username;

            TestLocation.OrderHistory.Add(CurrentOrder);
            bool actual = TestLocation.LastOrderOverTwoHoursAgo(NewUser);

            Assert.Equal(expected, actual);
        }

        //RetrieveUserOrderHistory test
        [Fact]
        public void RetrieveUserOrderHistoryShouldReturnPreviousOrders()
        {

            User NewUser = new User();
            NewUser.Username = "Tester";

            Order NewOrder = new Order();
            NewOrder.username = NewUser.Username;

            Location TestLocation = new Location();
            TestLocation.OrderHistory.Add(NewOrder);

            List<Order> RetrievedList = new List<Order>();
            RetrievedList = TestLocation.RetrieveUserOrderHistory(NewUser.Username);

            List<Order> OrderList = new List<Order>();
            OrderList.Add(NewOrder);
            OrderList.AddRange(RetrievedList);

            Assert.Equal(OrderList[0], OrderList[1]);
        }

        [Fact]
        public void RetrieveUserOrderHistoryShouldNotReturnOrdersFromOtherUsers()
        {
            User NewUser = new User();
            NewUser.Username = "Tester";

            Order NewOrder = new Order();
            NewOrder.username = NewUser.Username;

            User SecondUser = new User();
            SecondUser.Username = "Second";

            Order SecondOrder = new Order();
            SecondOrder.username = SecondUser.Username;

            Location TestLocation = new Location();
            TestLocation.OrderHistory.Add(NewOrder);
            TestLocation.OrderHistory.Add(SecondOrder);

            List<Order> RetrievedList = new List<Order>();
            RetrievedList = TestLocation.RetrieveUserOrderHistory(NewUser.Username);

            List<Order> OrderList = new List<Order>();
            OrderList.Add(SecondOrder);
            OrderList.AddRange(RetrievedList);

            bool SameString = false;
            if (OrderList[0].username.Equals(OrderList[1].username))
            {
                SameString = true;
            }

            Assert.False(SameString);
        }
    }
}
