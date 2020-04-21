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
    public class F1TeamGetServiceTests
    {
        [Test]
        public async Task ValidateAsync_F1TeamExists_DoesNothing()
        {
            // Arrange
            var f1TeamContainer = new Mock<IF1TeamContainer>();

            var f1Team = new F1Team();
            var f1TeamDataAccess = new Mock<IF1TeamDataAccess>();
            f1TeamDataAccess.Setup(x => x.GetByAsync(f1TeamContainer.Object)).ReturnsAsync(f1Team);

            var f1TeamGetService = new F1TeamGetService(f1TeamDataAccess.Object);
            
            // Act
            var action = new Func<Task>(() => f1TeamGetService.ValidateAsync(f1TeamContainer.Object));
            
            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }
        
        [Test]
        public async Task ValidateAsync_F1TeamNotExists_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var id = fixture.Create<int>();
            
            var f1TeamContainer = new Mock<IF1TeamContainer>();
            f1TeamContainer.Setup(x => x.F1TeamId).Returns(id);

            var f1Team = new F1Team();
            var f1TeamDataAccess = new Mock<IF1TeamDataAccess>();
            f1TeamDataAccess.Setup(x => x.GetByAsync(f1TeamContainer.Object)).ReturnsAsync((F1Team)null);

            var f1TeamGetService = new F1TeamGetService(f1TeamDataAccess.Object);
            
            // Act
            var action = new Func<Task>(() => f1TeamGetService.ValidateAsync(f1TeamContainer.Object));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>($"F1Team not found by id {id}");
        }
    }
}