﻿//Anthony Zoellner
//Project 1

using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStoreApplicationLibrary
{
    class Order : IIngredients
    {
        //fields
        public DateTime OrderPlaced => DateTime.Now;
    }
}
