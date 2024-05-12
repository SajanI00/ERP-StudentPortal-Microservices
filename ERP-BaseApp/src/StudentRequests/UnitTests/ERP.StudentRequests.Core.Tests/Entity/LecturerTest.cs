using FluentAssertions;
using AutoFixture;
using ERP.StudentRequests.Core.Entity;

namespace ERP.StudentRequests.Core.Tests.Entity
{
        public class LecturerTest
        {
            private readonly Fixture _fixture;

            public LecturerTest()
            {
                _fixture = new Fixture();
            }

            [Fact]
            public void Lecturer_Constructor_InitializesCollections()
            {
                // Act
                var lecturer = new Lecturer();

                // Assert
                lecturer.Requests.Should().NotBeNull();
                lecturer.Requests.Should().BeEmpty();
            }

            [Fact]
            public void Lecturer_Properties_InitializedCorrectly()
            {
                // Arrange
                var name = _fixture.Create<string>();
                var department = _fixture.Create<string>();
                var title = _fixture.Create<string>();

                // Act
                var lecturer = new Lecturer
                {
                    Name = name,
                    Department = department,
                    Title = title
                };

                // Assert
                lecturer.Name.Should().Be(name);
                lecturer.Department.Should().Be(department);
                lecturer.Title.Should().Be(title);
            }

        }
    

}
