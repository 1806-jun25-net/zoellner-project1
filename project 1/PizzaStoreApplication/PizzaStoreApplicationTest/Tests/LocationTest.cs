﻿using PizzaStoreApplicationLibrary;
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

        //DecreaseInventory tests
        public static IEnumerable<object[]> GetTestDataForSmallPizza()
        {
            yield return new object[] { new Order() };
            yield return new object[] { new Order() };
            yield return new object[] { new Order() };
            yield return new object[] { new Order() };
        }

        [Fact]
        public void DecreaseInventoryShouldDecreaseDoughSmallCheese()
        {
            Order TestOrder = new Order();
            TestOrder.DesiredSizes = new List<int>();
            TestOrder.DesiredTypes = new List<int>();
            TestOrder.DesiredSizes.Add(1);
            TestOrder.DesiredTypes.Add(1);

            Location TestLocation = new Location();
            TestLocation.DecreaseInventory(TestOrder);

            double actual = TestLocation.Dough;

            bool smaller = false;
            if(actual < 1000)
            {
                smaller = true;
            }

            Assert.True(smaller);
        }
    }
}