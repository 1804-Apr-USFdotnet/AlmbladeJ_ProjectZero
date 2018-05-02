using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using AutoFixture.Xunit2;
using AutoFixture.AutoMoq;
using AutoFixture;
using System.Data.Entity;
using Moq;
using Repository;

namespace Project0.Tests
{
    public class UnitTests
    {
        [Fact]
        public void RepoAdd_AddRestaurant_CheckAdded()
        {
            //Arrange
            var dbmock = new Mock<RRRavesDBEntities>();
            var dbsetmock = new Mock<DbSet<Restaurant>>();
            dbsetmock.Setup(x => x.Add(It.IsAny<Restaurant>())).Returns((Restaurant u) => u);
            dbmock.Setup(x => x.Restaurants).Returns(dbsetmock.Object);

            var restrepo = new RestaurantRepository(dbmock.Object);


            Restaurant restaurantEx = new Restaurant();


            //Act
            restrepo.Add(restaurantEx);
            var actual = restrepo.Get(restaurantEx.ID_Restaurant);

            //Assert
            Assert.Equal(restaurantEx, actual);
        }
    }
}
