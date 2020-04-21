using System;
using System.Threading.Tasks;
using Formula1.BLL.Contracts;
using Formula1.BLL.Implementation;
using Formula1.DataAccess.Contracts;
using Formula1.Domain;
using Formula1.Domain.Models;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace Formula1.BLL.Tests
{
    public class RiderUpdateServiceTests
    {
        [Test]
        public async Task UpdateAsync_DepartmentValidationSucceed_CreatesRider()
        {
            // Arrange
            var rider = new RiderUpdateModel();
            var expected = new Rider();
            
            var f1TeamGetService = new Mock<IF1TeamGetService>();
            f1TeamGetService.Setup(x => x.ValidateAsync(rider));

            var riderDataAccess = new Mock<IRiderDataAccess>();
            riderDataAccess.Setup(x => x.UpdateAsync(rider)).ReturnsAsync(expected);
            
            var riderGetService = new RiderUpdateService(riderDataAccess.Object, f1TeamGetService.Object);
            
            // Act
            var result = await riderGetService.UpdateAsync(rider);
            
            // Assert
            result.Should().Be(expected);
        }
        
        [Test]
        public async Task UpdateAsync_F1TeamValidationFailed_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var rider = new RiderUpdateModel();
            var expected = fixture.Create<string>();
            
            var f1TeamGetService = new Mock<IF1TeamGetService>();
            f1TeamGetService
                .Setup(x => x.ValidateAsync(rider))
                .Throws(new InvalidOperationException(expected));

            var riderDataAccess = new Mock<IRiderDataAccess>();

            var riderGetService = new RiderUpdateService(riderDataAccess.Object, f1TeamGetService.Object);
            
            // Act
            var action = new Func<Task>(() => riderGetService.UpdateAsync(rider));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>().WithMessage(expected);
            riderDataAccess.Verify(x => x.UpdateAsync(rider), Times.Never);
        }
    }
}