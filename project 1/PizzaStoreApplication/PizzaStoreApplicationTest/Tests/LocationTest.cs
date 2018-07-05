using PizzaStoreApplicationLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PizzaStoreApplicationTest
{
    public class LocationTest
    {
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


    }
}
