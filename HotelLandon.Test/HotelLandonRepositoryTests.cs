﻿using HotelLandon.Data;
using HotelLandon.Models;
using HotelLandon.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace HotelLandon.Test
{
    public class CustomersRepository : HotelLandonRepositoryTests<Customer>
    {

    }
    public class HotelLandonRepositoryTests<TEntity>
        where TEntity : EntityBase, new()
    {
        private readonly RepositoryBase<TEntity> repository;
        public HotelLandonRepositoryTests()
        {
            DbContextOptionsBuilder<HotelLandonContext> builder = new();
            builder.UseInMemoryDatabase("HotelLandon");

            HotelLandonContext context = new(builder.Options);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            repository = new RepositoryBase<TEntity>(context);

            context.Customers.AddRange(FakeData.Customers);
            context.Rooms.AddRange(FakeData.Rooms);

 
        }

        [Fact]
        public async Task FindAll_ReturnsAllItems()
        {
            //Arrange
            int count = (await repository.GetAllAsync()).Count;
            //Act
            var items = await repository.GetAllAsync();

            //Assert
            Assert.Equal(count, items.Count);
        }
        //[Fact]
        //public async Task FindPersons_ReturnsSomeItems()
        //{
        //    (await repository.GetAllAsync()).Where(e => e.Id == 1);
        //}

        [Fact]
        public async Task Ajout()
        {
            //Arrange
            int count = (await repository.GetAllAsync()).Count;
            Customer toto = new ()
            {
                FirstName = "Toto",
                LastName = "Tutu",
                BirthDate = DateTime.Now,
            };
            //Act
            var items = await repository.AddAsync(toto);
            //Assert
            Assert.Equal(count + 1, count + items);
        }

    }
}
