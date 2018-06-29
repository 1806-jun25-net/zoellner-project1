using PizzaStoreApplicationLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStoreApplicationTest
{
    public class TwoHoursAgo : Order
    {
        //override order time, moving it back two hours
        //public override OrderPlacedAt => base.OrderPlacedAt - TimeSpan.FromHours(2);
    }
}
