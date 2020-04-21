using System;
using System.Threading.Tasks;
using AutoFixture;
using Formula1.BLL.Implementation;
using Formula1.DataAccess.Contracts;
using Formula1.Domain;
using Formula1.Domain.Contracts;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace Formula1.BLL.Tests
{
    public class RiderGetServiceTests
    {
        [Test]
        public async Task ValidateAsync_RiderExists_DoesNothing()
        {
            // Arrange
            var riderContainer = new Mock<IRiderContainer>();

            var rider = new Rider();
            var riderDataAccess = new Mock<IRiderDataAccess>();
            riderDataAccess.Setup(x => x.GetByAsync(riderContainer.Object)).ReturnsAsync(rider);

            var riderGetService = new RiderGetService(riderDataAccess.Object);
            
            // Act
            var action = new Func<Task>(() => riderGetService.ValidateAsync(riderContainer.Object));
            
            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }
        
        [Test]
        public async Task ValidateAsync_RiderNotExists_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var id = fixture.Create<int>();
            
            var riderContainer = new Mock<IRiderContainer>();
            riderContainer.Setup(x => x.RiderId).Returns(id);

            var rider = new Rider();
            var riderDataAccess = new Mock<IRiderDataAccess>();
            riderDataAccess.Setup(x => x.GetByAsync(riderContainer.Object)).ReturnsAsync((Rider)null);

            var riderGetService = new RiderGetService(riderDataAccess.Object);
            
            // Act
            var action = new Func<Task>(() => riderGetService.ValidateAsync(riderContainer.Object));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>($"Rider not found by id {id}");
        }
    }
}