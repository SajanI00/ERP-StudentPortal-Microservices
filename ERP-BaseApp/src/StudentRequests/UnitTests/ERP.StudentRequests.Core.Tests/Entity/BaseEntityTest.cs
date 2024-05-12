
using AutoFixture;
using ERP.StudentRequests.Core.Entity;
using FluentAssertions;

namespace ERP.StudentRequests.Core.Tests.Entity
{
    public class BaseEntityTest
    {
        private readonly Fixture _fixture;

        public BaseEntityTest()
        {
            _fixture = new Fixture();
        }

        [Fact]
        public void BaseEntity_Constructor_InitializesProperties()
        {
            // Arrange
            var expectedId = Guid.NewGuid();
            var expectedAddedDate = DateTime.UtcNow;
            var expectedUpdatedDate = DateTime.UtcNow;
            var expectedStatus = 0;

            // Act
            var baseEntity = new BaseEntity
            {
                Id = expectedId,
                AddedDate = expectedAddedDate,
                UpdatedDate = expectedUpdatedDate,
                Status = expectedStatus
            };

            // Assert
            baseEntity.Id.Should().Be(expectedId);
            baseEntity.AddedDate.Should().Be(expectedAddedDate);
            baseEntity.UpdatedDate.Should().Be(expectedUpdatedDate);
            baseEntity.Status.Should().Be(expectedStatus);
        }

        [Fact]
        public void BaseEntity_DefaultValues_AreSet()
        {
            // Arrange
            var baseEntity = new BaseEntity();

            // Assert
            baseEntity.Id.Should().NotBe(Guid.Empty);
            baseEntity.AddedDate.Should().BeCloseTo(DateTime.UtcNow, precision: TimeSpan.FromSeconds(1));
            baseEntity.UpdatedDate.Should().BeCloseTo(DateTime.UtcNow, precision: TimeSpan.FromSeconds(1));
            baseEntity.Status.Should().Be(0);
        }

    }
}
