/*
    Orders.cs
    Author: Brandon Ward
    Last update: 11/26/2018

    This class is the model for the orders
    table int the database. This model contains
    the FirstName and LastName given by the uploaded
    data.
*/
using System;
namespace CSVParser.Models
{
    public class Orders
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
