using FluentAssertions;
using AutoFixture;
using ERP.StudentRequests.Core.Entity;

namespace ERP.StudentRequests.Core.Tests.Entity
{
    public class StudentTest
    {
        private readonly Fixture _fixture;

        public StudentTest()
        {
            _fixture = new Fixture();
        }

        [Fact]
        public void Student_Constructor_InitializesCollections()
        {
            // Act
            var student = new Student();

            // Assert
            student.Requests.Should().NotBeNull();
            student.Requests.Should().BeEmpty(); // to ensure that the Requests collection is initialized and empty
        }

        [Fact]
        public void Student_Properties_InitializedCorrectly()
        {
            // Arrange
            var name = _fixture.Create<string>();
            var regNo = _fixture.Create<string>();
            var batch = _fixture.Create<string>();
            var degree = _fixture.Create<string>();
            var semester = _fixture.Create<string>();

            // Act
            var student = new Student
            {
                Name = name,
                RegNo = regNo,
                Batch = batch,
                Degree = degree,
                Semester = semester
            };

            // Assert
            student.Name.Should().Be(name);
            student.RegNo.Should().Be(regNo);
            student.Batch.Should().Be(batch);
            student.Degree.Should().Be(degree);
            student.Semester.Should().Be(semester);
        }
    }
}
