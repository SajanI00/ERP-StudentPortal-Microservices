using AutoMapper;
using ERP.StudentRequests.Api.MappingProfiles;
using ERP.StudentRequests.Core.DTOs.Response;
using ERP.StudentRequests.Core.Entity;
using FluentAssertions;

namespace ERP.StudentRequests.Api.Tests.MappingProfiles
{
    public class DomainToResponseProfileTests
    {
        private readonly IMapper _mapper;

        public DomainToResponseProfileTests()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainToResponse());
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public void MapRequestToGetReqLetterResponse_ShouldMapCorrectly()
        {
            // Arrange
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
                StudentId = Guid.NewGuid(),
                LecturerId = Guid.NewGuid()
            };

            // Act
            var result = _mapper.Map<GetReqLetterResponse>(request);

            // Assert
            result.Should().NotBeNull();
            result.Topic.Should().Be("Test Topic");
            result.RequestType.Should().Be("Test Type");
            result.LecturerName.Should().Be("Test Lecturer");
            result.Message.Should().Be("Test Message");
            result.StudentName.Should().Be("Test Student");
            result.StudentRegNo.Should().Be("Test Reg No");
            result.StudentBatch.Should().Be("Test Batch");
            result.StudentDegree.Should().Be("Test Degree");
            result.StudentId.Should().Be(request.StudentId);
            result.LecturerId.Should().Be(request.LecturerId);
        }

        [Fact]
        public void MapStudentToGetStudentResponse_ShouldMapCorrectly()
        {
            // Arrange
            var student = new Student
            {
                Id = Guid.NewGuid(),
                Name = "Test Student",
                RegNo = "Test Reg No",
                Batch = "Test Batch",
                Degree = "Test Degree",
                Semester = "Test Semester"
            };

            // Act
            var result = _mapper.Map<GetStudentResponse>(student);

            // Assert
            result.Should().NotBeNull();
            result.StudentId.Should().Be(student.Id);
            result.Name.Should().Be("Test Student");
            result.RegNo.Should().Be("Test Reg No");
            result.Batch.Should().Be("Test Batch");
            result.Degree.Should().Be("Test Degree");
            result.Semester.Should().Be("Test Semester");
        }

        [Fact]
        public void MapLecturerToGetLecturerResponse_ShouldMapCorrectly()
        {
            // Arrange
            var lecturer = new Lecturer
            {
                Id = Guid.NewGuid(),
                Name = "Test Lecturer",
                Department = "Test Department",
                Title = "Test Title"
            };

            // Act
            var result = _mapper.Map<GetLecturerResponse>(lecturer);

            // Assert
            result.Should().NotBeNull();
            result.LecturerId.Should().Be(lecturer.Id);
            result.Name.Should().Be("Test Lecturer");
            result.Department.Should().Be("Test Department");
            result.Title.Should().Be("Test Title");
        }
    }
}
