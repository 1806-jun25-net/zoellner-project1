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
        public void UserShouldBeAbleToCreateOrder()
        {
            //Arrange
            var user = new User();
            user.CreateOrder(1);

            //Act
            var actual = user.OrderedRecently;

            //Assert
            Assert.True(actual);
        }

        //[Fact]
        //public void UserShouldNotBeAbleToOrderTwiceInTwoHours()
        //{
        //    var expected = True;

        //    //Arrange
        //    var user = new Order();
        //    user.CreateOrder(data);

        //    //Act
        //    user.CreateOrder();
        //    var actual = user.RecentOrder;

        //    //Assert
        //    Assert.True(expected, actual);
        //}

        //[Fact]
        //public void UserShouldBeAbleToOrderTwiceInMoreThanTwoHours()
        //{
        //    var expected = false;

        //    //Arrange
        //    var user = new Order();
        //    user.CreateOrder(data);

        //    //Act
        //    user.AlterOrderTime();
        //    user.CreateOrder();
        //    var actual = user.RecentOrder;

        //    //Assert
        //    Assert.False(expected, actual);
        //}


    }
}
