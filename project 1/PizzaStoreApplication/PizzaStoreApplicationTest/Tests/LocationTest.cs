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
        [InlineData (false, new int[] {2,3})]
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

        //SizeModifierSet test
        public static IEnumerable<object[]> GetTestDataForSizeModifier()
        {
            yield return new object[] { new int[] { 1, 2, 3 } };
            yield return new object[] { new double[] { 1, 1.5, 2 } };
        }

        [Theory]
        [InlineData(1,1)]
        [InlineData(2,1.5)]
        [InlineData(3,2)]
        public void SizeModifierShouldChangeForDifferentSizesPicked(int size, double modifier)
        {
            Pizza TestPizza = new Pizza(size, 1);//Type of pizza is irrelevant here, so we shall only use the cheese pizza

            TestPizza.SizeModifierSet(size);
            double actual = TestPizza.SizeModifier;

            Assert.Equal(modifier, actual);
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
    }
}
