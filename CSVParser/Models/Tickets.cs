/*
    Tickets.cs
    Author: Brandon Ward
    Last update: 11/26/2018

    This class is the model for the tickets
    table in the database. This model contains
    the TicketNumber and EventDate given by the uploaded
    data.
*/
using System;
namespace CSVParser.Models
{
    public class Tickets
    {
        public int ID { get; set; }
        public string TicketNumber { get; set; }
        public DateTime EventDate { get; set; }
    }
}
