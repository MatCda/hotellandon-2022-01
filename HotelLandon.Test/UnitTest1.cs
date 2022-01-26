using HotelLandon.Models;
using System;
using Xunit;

namespace HotelLandon.Test
{

    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            Customer customer = new()
            {
                FirstName = "Mathieu",
                LastName = "B",
                BirthDate = DateTime.Now,
            };

            //Act
            

            //Assert
            Assert.True(customer.FirstName.Length >3);

        }

        [Fact]
        public void test2()
        {
            //Arrange
            Customer customer = new()
            {
                FirstName = "A",
            };
            //Act

            //Assert
            Assert.False(customer.FirstName.Length >3);
        }

        [Fact]
        public void CustomerType()
        {
            //Arrange
            Customer customer = new()
            {
                FirstName = "A",
            };
            var expected = typeof(Customer);
            //Act

            //Assert
            Assert.IsType(expected, customer);
        }



        [Fact]
        public void Test3()
        {
            //Arrange
            
            

            //Act
            

            //Assert
            

        }


    }
}
