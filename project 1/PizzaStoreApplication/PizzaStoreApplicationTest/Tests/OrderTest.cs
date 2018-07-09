using PizzaStoreApplicationLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PizzaStoreApplicationTest
{
    public class OrderTest
    {
        [Theory]
        [InlineData(new int[] {1, 1}, "Small Cheese Pizza $8.00")]
        [InlineData(new int[] { 1, 2}, "Small Pepperoni Pizza $9.00")]
        [InlineData(new int[] { 1, 3}, "Small Meat Pizza $11.00")]
        [InlineData(new int[] { 1, 4 }, "Small Veggie Pizza $11.00")]
        [InlineData(new int[] { 2, 1 }, "Medium Cheese Pizza $11.00")]
        [InlineData(new int[] { 2, 2 }, "Medium Pepperoni Pizza $12.00")]
        [InlineData(new int[] { 2, 3 }, "Medium Meat Pizza $14.00")]
        [InlineData(new int[] { 2, 4 }, "Medium Veggie Pizza $14.00")]
        [InlineData(new int[] { 3, 1 }, "Large Cheese Pizza $14.00")]
        [InlineData(new int[] { 3, 2 }, "Large Pepperoni Pizza $15.00")]
        [InlineData(new int[] { 3, 3 }, "Large Meat Pizza $17.00")]
        [InlineData(new int[] { 3, 4 }, "Large Veggie Pizza $17.00")]
        public void PrintPizzaShouldReturnTheProperStringGivenASizeAndTypeOfPizza(int[] data, string expected)
        {
            int size = data[0];
            int type = data[1];

            Order NeededToTest = new Order();

            string actual =  NeededToTest.PrintPizza(size, type);

            bool result = expected.Equals(actual);

            Assert.True(result);
        }
    }
}
