using PizzaStoreApplicationLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PizzaStoreApplicationTest
{
    public class UserTest
    {
        public static IEnumerable<object[]> GetTestData()
        {
            yield return new object[] { };
            yield return new object[] { };
            yield return new object[] { } };
            yield return new object[] { };
        }

        [Theory]
        [MemberData(nameof(GetTestData))]
        public void UserShouldBeAbleToCreateOrder(string[] data)
        {
            var expected = true;
            //Arrange
            var user = new Order();
            user.CreateOrder(data);

            //Act
            var actual = user.RecentOrder;

            //Assert
            Assert.True(expected, actual);
        }

        [Theory]
        [MemberData(nameof(GetTestData))]
        public void UserShouldNotBeAbleToOrderTwiceInTwoHours(string[] data)
        {
            var expected = True;

            //Arrange
            var user = new Order();
            user.CreateOrder(data);

            //Act
            user.CreateOrder();
            var actual = user.RecentOrder;

            //Assert
            Assert.True(expected, actual);
        }

        [Theory]
        [MemberData(nameof(GetTestData))]
        public void UserShouldBeAbleToOrderTwiceInMoreThanTwoHours(string[] data)
        {
            var expected = false;

            //Arrange
            var user = new Order();
            user.CreateOrder(data);

            //Act
            user.AlterOrderTime();
            user.CreateOrder();
            var actual = user.RecentOrder;

            //Assert
            Assert.False(expected, actual);
        }


    }
}
