using FluentAssertions;
using ERP.StudentRequests.Core.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.StudentRequests.Core.Tests.Entity
{
    public class RequestTest
    {
        [Fact]
        public void Request_DefaultValues_AreSet()
        {
            // Arrange
            var request = new Request();

            // Assert
            request.Topic.Should().BeEmpty();
            request.RequestType.Should().BeEmpty();
            request.LecturerName.Should().BeEmpty();
            request.Message.Should().BeEmpty();
            request.StudentName.Should().BeEmpty();
            request.StudentRegNo.Should().BeEmpty();
            request.StudentBatch.Should().BeEmpty();
            request.StudentDegree.Should().BeEmpty();
            request.StudentId.Should().BeEmpty();
            request.LecturerId.Should().BeEmpty();
            request.Student.Should().BeNull();
            request.Lecturer.Should().BeNull();
        }


        [Fact]
        public void Request_Relationships_AreCorrect()
        {
            // Arrange
            var studentId = Guid.NewGuid();
            var lecturerId = Guid.NewGuid();
            var student = new Student { Id = studentId };
            var lecturer = new Lecturer { Id = lecturerId };
            var request = new Request { StudentId = studentId, Student = student, LecturerId = lecturerId, Lecturer = lecturer };

            // Act

            // Assert
            request.Student.Should().Be(student);
            request.Lecturer.Should().Be(lecturer);
        }


        [Fact]
        // for data integrity
        public void Request_DataIntegrity_IsCorrect()
        {
            // Arrange
            var request = new Request { StudentId = Guid.NewGuid(), LecturerId = Guid.NewGuid() };

            // Act

            // Assert
            request.StudentId.Should().NotBeEmpty();
            request.LecturerId.Should().NotBeEmpty();
        }

        [Fact]
        // for property assignments
        public void Request_PropertyAssignments_AreCorrect()
        {
            // Arrange
            var studentId = Guid.NewGuid();
            var lecturerId = Guid.NewGuid();
            var request = new Request
            {
                Topic = "Test Topic",
                RequestType = "Test Type",
                LecturerName = "Test Lecturer",
                Message = "Test Message",
                StudentName = "Test Student",
                StudentRegNo = "Test Reg No",
                StudentBatch = "Test Batch",
                StudentDegree = "Test Degree",
                StudentId = studentId,
                LecturerId = lecturerId
            };

            // Act

            // Assert
            request.Topic.Should().Be("Test Topic");
            request.RequestType.Should().Be("Test Type");
            request.LecturerName.Should().Be("Test Lecturer");
            request.Message.Should().Be("Test Message");
            request.StudentName.Should().Be("Test Student");
            request.StudentRegNo.Should().Be("Test Reg No");
            request.StudentBatch.Should().Be("Test Batch");
            request.StudentDegree.Should().Be("Test Degree");
            request.StudentId.Should().Be(studentId);
            request.LecturerId.Should().Be(lecturerId);
        }

        [Fact]
        // Add test for foreign key constraints
        public void Request_ForeignKeyConstraints_AreValid()
        {
            // Arrange
            var request = new Request();

            // Act

            // Assert
            typeof(Request).GetProperty(nameof(Request.Student)).GetCustomAttributes(typeof(ForeignKeyAttribute), true)
                .Should().NotBeEmpty();
            typeof(Request).GetProperty(nameof(Request.Lecturer)).GetCustomAttributes(typeof(ForeignKeyAttribute), true)
                .Should().NotBeEmpty();
        }
    }
}
    