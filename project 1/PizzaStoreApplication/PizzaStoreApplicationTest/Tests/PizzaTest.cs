using PizzaStoreApplicationLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PizzaStoreApplicationTest
{
    public class PizzaTest
    {
        //SizeModifierSet test
        public static IEnumerable<object[]> GetTestDataForSizeModifier()
        {
            yield return new object[] { new int[] { 1, 2, 3 } };
            yield return new object[] { new double[] { 1, 1.5, 2 } };
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 3)]
        public void SizeModifierShouldChangeForDifferentSizesPicked(int size, double modifier)
        {
            Pizza TestPizza = new Pizza(size, 1);//Type of pizza is irrelevant here, so we shall only use the cheese pizza

            TestPizza.SizeModifierSet(size);
            double actual = TestPizza.SizeModifier;

            Assert.Equal(modifier, actual);
        }
    }
}
