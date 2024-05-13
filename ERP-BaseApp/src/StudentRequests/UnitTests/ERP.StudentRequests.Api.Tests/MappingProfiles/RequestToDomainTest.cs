//using AutoMapper;
//using ERP.StudentRequests.Api.MappingProfiles;
//using ERP.StudentRequests.Core.DTOs.Request;
//using ERP.StudentRequests.Core.Entity;
//using FluentAssertions;

//namespace ERP.StudentRequests.Api.Tests.MappingProfiles
//{
//    public class RequestToDomainProfileTests
//    {
//        private readonly IMapper _mapper;

//        public RequestToDomainProfileTests()
//        {
//            var mapperConfig = new MapperConfiguration(cfg =>
//            {
//                cfg.AddProfile(new RequestToDomain());
//            });
//            _mapper = mapperConfig.CreateMapper();
//        }

//        [Fact]
//        public void MapCreateReqLetterRequestToRequest_ShouldMapCorrectly()
//        {
//            // Arrange
//            var createRequest = new CreateReqLetterRequest
//            {
//                StudentId = Guid.NewGuid(),
//                LecturerId = Guid.NewGuid(),
//                Topic = "Test Topic",
//                RequestType = "Test Type",
//                LecturerName = "Test Lecturer",
//                Message = "Test Message",
//                StudentName = "Test Student",
//                StudentRegNo = "Test Reg No",
//                StudentBatch = "Test Batch",
//                StudentDegree = "Test Degree"
//            };

//            // Act
//            var result = _mapper.Map<Request>(createRequest);

//            // Assert
//            result.Should().NotBeNull();
//            result.StudentId.Should().Be(createRequest.StudentId);
//            result.LecturerId.Should().Be(createRequest.LecturerId);
//            result.Topic.Should().Be("Test Topic");
//            result.RequestType.Should().Be("Test Type");
//            result.LecturerName.Should().Be("Test Lecturer");
//            result.Message.Should().Be("Test Message");
//            result.StudentName.Should().Be("Test Student");
//            result.StudentRegNo.Should().Be("Test Reg No");
//            result.StudentBatch.Should().Be("Test Batch");
//            result.StudentDegree.Should().Be("Test Degree");
//            result.Status.Should().Be(1);
//            result.AddedDate.Should().BeCloseTo(DateTime.UtcNow, precision: TimeSpan.FromSeconds(1));
//            result.UpdatedDate.Should().BeCloseTo(DateTime.UtcNow, precision: TimeSpan.FromSeconds(1));
//        }

//        [Fact]
//        public void MapUpdateReqLetterRequestToRequest_ShouldMapCorrectly()
//        {
//            // Arrange
//            var updateRequest = new UpdateReqLetterRequest
//            {
//                RequestId = Guid.NewGuid(),
//                StudentId = Guid.NewGuid(),
//                LecturerId = Guid.NewGuid(),
//                Topic = "Updated Topic",
//                RequestType = "Updated Type",
//                LecturerName = "Updated Lecturer",
//                Message = "Updated Message",
//                StudentName = "Updated Student",
//                StudentRegNo = "Updated Reg No",
//                StudentBatch = "Updated Batch",
//                StudentDegree = "Updated Degree"
//            };

//            // Act
//            var result = _mapper.Map<Request>(updateRequest);

//            // Assert
//            result.Should().NotBeNull();
//            result.Id.Should().Be(updateRequest.RequestId);
//            result.StudentId.Should().Be(updateRequest.StudentId);
//            result.LecturerId.Should().Be(updateRequest.LecturerId);
//            result.Topic.Should().Be("Updated Topic");
//            result.RequestType.Should().Be("Updated Type");
//            result.LecturerName.Should().Be("Updated Lecturer");
//            result.Message.Should().Be("Updated Message");
//            result.StudentName.Should().Be("Updated Student");
//            result.StudentRegNo.Should().Be("Updated Reg No");
//            result.StudentBatch.Should().Be("Updated Batch");
//            result.StudentDegree.Should().Be("Updated Degree");
//            result.UpdatedDate.Should().BeCloseTo(DateTime.UtcNow, precision: TimeSpan.FromSeconds(1));
//        }

//        [Fact]
//        public void MapCreateStudentRequestToStudent_ShouldMapCorrectly()
//        {
//            // Arrange
//            var createStudentRequest = new CreateStudentRequest
//            {
//                Name = "Test Student",
//                RegNo = "Test Reg No",
//                Batch = "Test Batch",
//                Degree = "Test Degree",
//                Semester = "Test Semester"
//            };

//            // Act
//            var result = _mapper.Map<Student>(createStudentRequest);

//            // Assert
//            result.Should().NotBeNull();
//            result.Name.Should().Be("Test Student");
//            result.RegNo.Should().Be("Test Reg No");
//            result.Batch.Should().Be("Test Batch");
//            result.Degree.Should().Be("Test Degree");
//            result.Semester.Should().Be("Test Semester");
//            result.Status.Should().Be(1);
//            result.AddedDate.Should().BeCloseTo(DateTime.UtcNow, precision: TimeSpan.FromSeconds(1));
//            result.UpdatedDate.Should().BeCloseTo(DateTime.UtcNow, precision: TimeSpan.FromSeconds(1));
//        }

//        [Fact]
//        public void MapUpdateStudentRequestToStudent_ShouldMapCorrectly()
//        {
//            // Arrange
//            var updateStudentRequest = new UpdateStudentRequest
//            {
//                StudentId = Guid.NewGuid(),
//                Name = "Updated Student",
//                RegNo = "Updated Reg No",
//                Batch = "Updated Batch",
//                Degree = "Updated Degree",
//                Semester = "Updated Semester"
//            };

//            // Act
//            var result = _mapper.Map<Student>(updateStudentRequest);

//            // Assert
//            result.Should().NotBeNull();
//            result.Id.Should().Be(updateStudentRequest.StudentId);
//            result.Name.Should().Be("Updated Student");
//            result.RegNo.Should().Be("Updated Reg No");
//            result.Batch.Should().Be("Updated Batch");
//            result.Degree.Should().Be("Updated Degree");
//            result.Semester.Should().Be("Updated Semester");
//            result.UpdatedDate.Should().BeCloseTo(DateTime.UtcNow, precision: TimeSpan.FromSeconds(1));
//        }

//        [Fact]
//        public void MapCreateLecturerRequestToLecturer_ShouldMapCorrectly()
//        {
//            // Arrange
//            var createLecturerRequest = new CreateLecturerRequest
//            {
//                Name = "Test Lecturer",
//                Department = "Test Department",
//                Title = "Test Title"
//            };

//            // Act
//            var result = _mapper.Map<Lecturer>(createLecturerRequest);

//            // Assert
//            result.Should().NotBeNull();
//            result.Name.Should().Be("Test Lecturer");
//            result.Department.Should().Be("Test Department");
//            result.Title.Should().Be("Test Title");
//            result.Status.Should().Be(1);
//            result.AddedDate.Should().BeCloseTo(DateTime.UtcNow, precision: TimeSpan.FromSeconds(1));
//            result.UpdatedDate.Should().BeCloseTo(DateTime.UtcNow, precision: TimeSpan.FromSeconds(1));
//        }

//        [Fact]
//        public void MapUpdateLecturerRequestToLecturer_ShouldMapCorrectly()
//        {
//            // Arrange
//            var updateLecturerRequest = new UpdateLecturerRequest
//            {
//                LecturerId = Guid.NewGuid(),
//                Name = "Updated Lecturer",
//                Department = "Updated Department",
//                Title = "Updated Title"
//            };

//            // Act
//            var result = _mapper.Map<Lecturer>(updateLecturerRequest);

//            // Assert
//            result.Should().NotBeNull();
//            result.Id.Should().Be(updateLecturerRequest.LecturerId);
//            result.Name.Should().Be("Updated Lecturer");
//            result.Department.Should().Be("Updated Department");
//            result.Title.Should().Be("Updated Title");
//            result.UpdatedDate.Should().BeCloseTo(DateTime.UtcNow, precision: TimeSpan.FromSeconds(1));
//        }
//    }
//}

