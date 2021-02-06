using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.Data
{
    public class CustomerData
    {
        public List<Customers> GetCustomerList()
        {
            return new List<Customers>()
                {
                    new Customers
                    {
                        CustomerId = 1,
                        FirstName = "Paul",
                        LastName = "Walker",
                        Email = "paul@gmail.com",
                        Password = "Paul123",
                      
                    },
                     new Customers
                     {
                         CustomerId = 2,
                         FirstName = "Chris",
                         LastName = "Hemsworth",
                         Email = "chris@gmail.com",
                         Password = "Chris123",
                        
                     },
                     new Customers
                    {
                        CustomerId = 3,
                        FirstName = "Chris",
                        LastName = "Evan",
                        Email = "chrisevan@gmail.com",
                        Password = "Evan123",
                      
                    },
                     new Customers
                    {
                        CustomerId = 4,
                        FirstName = "Harry",
                        LastName = "Potter",
                        Email = "harry@gmail.com",
                        Password = "Harry123",
                       
                    },
                     new Customers
                    {
                        CustomerId = 5,
                        FirstName = "Robert",
                        LastName = "Downey",
                        Email = "robert@gmail.com",
                        Password = "Robert123",
                     
                    }
                };
        }
    }
}
