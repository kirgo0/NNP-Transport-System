using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore;
using DAL.Entity;
using Times = Moq.Times;
using System.Data.Common;
using Effort;
using System.Diagnostics;
using System.Linq.Expressions;

namespace DAL.Tests
{
    public class BaseRepositoryUnitTests
    {

        [Fact]
        public void Create_InputBusInstance_CalledAddMethodOfDbSetWithBusInstance()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().Options;
            var mockDbContext = new Mock<ApplicationDbContext>(options);
            var mockBusSet = new Mock<DbSet<Bus>>();

            mockDbContext
                .Setup(context => context.Set<Bus>()).Returns(mockBusSet.Object);
            
            var repository = new TestBusRepository(mockDbContext.Object);

            var testBus = new Mock<Bus>().Object;

            // Act
            repository.Create(testBus);

            // Assert
            mockBusSet.Verify(
                busSet => busSet.Add
                (
                    testBus
                )
            , Times.Once);
        }

        [Fact]
        public void Get_InputId_CalledFindMethodAndReturnedCorrectObject()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().Options;
            var mockDbContext = new Mock<ApplicationDbContext>(options);
            var mockBusSet = new Mock<DbSet<Bus>>();

            Bus testBus = new Bus() { id = 1};

            mockBusSet.Setup(busSet => busSet.Find(testBus.id)).Returns(testBus);

            mockDbContext
                .Setup(context => context.Set<Bus>()).Returns(mockBusSet.Object);

            var repository = new TestBusRepository(mockDbContext.Object);

            // Act

            var result = repository.GetById(testBus.id);

            // Assert

            mockBusSet.Verify(
                busSet => busSet.Find(testBus.id), Times.Once
                );
            Assert.Equal(result, testBus);
        }

        [Fact]
        public void Remove_InputBusInstance_CalledRemoveMethodOfDbSet()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().Options;
            var mockDbContext = new Mock<ApplicationDbContext>(options);
            var mockBusSet = new Mock<DbSet<Bus>>();

            Bus testBus = new Bus() { id = 1 };

            mockDbContext
                .Setup(context => context.Set<Bus>()).Returns(mockBusSet.Object);

            var repository = new TestBusRepository(mockDbContext.Object);

            // Act

            repository.Remove(testBus);

            // Assert

            mockBusSet.Verify(
                busSet => busSet.Remove(testBus), Times.Once
                );
        }


        [Fact]
        public void Update_InputBusInstance_CalledUpdateMethodOfDbSet()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().Options;
            var mockDbContext = new Mock<ApplicationDbContext>(options);
            var mockBusSet = new Mock<DbSet<Bus>>();

            Bus testBus = new Bus() { id = 1 };

            mockDbContext
                .Setup(context => context.Set<Bus>()).Returns(mockBusSet.Object);

            var repository = new TestBusRepository(mockDbContext.Object);

            // Act

            repository.Update(testBus);

            // Assert

            mockBusSet.Verify(
                busSet => busSet.Update(testBus), Times.Once
                );
        }
    }
}
