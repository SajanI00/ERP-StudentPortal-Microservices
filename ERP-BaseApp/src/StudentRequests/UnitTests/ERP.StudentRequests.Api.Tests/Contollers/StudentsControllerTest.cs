using AutoMapper;
using ERP.StudentRequests.Api.Controllers;
using ERP.StudentRequests.Core.DTOs.Request;
using ERP.StudentRequests.Core.DTOs.Response;
using ERP.StudentRequests.Core.Entity;
using ERP.StudentRequests.Core.Interfaces;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ERP.StudentRequests.Api.UnitTests.Controllers
{
    public class StudentsControllerTest
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IMapper> _mockMapper;
        private readonly StudentsController _controller;
        private readonly IFixture _fixture;

        public StudentsControllerTest()
        {
            _fixture = new Fixture();
            _mockUnitOfWork = _fixture.Freeze<Mock<IUnitOfWork>>();
            _mockMapper = _fixture.Freeze<Mock<IMapper>>();
            _controller = new StudentsController(_mockUnitOfWork.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetStudentMethod_ShouldReturnOk_WhenStudentFound()
        {
            // Arrange
            var studentId = Guid.NewGuid();
            var studentEntity = _fixture.Build<Student>()
                                        .With(s => s.Id, studentId)
                                        .Create();
            var studentResponse = _fixture.Build<GetStudentResponse>()
                                          .With(r => r.StudentId, studentId)
                                          .Create();

            _mockUnitOfWork.Setup(uow => uow.Students.GetById(studentId))
                           .ReturnsAsync(studentEntity);
            _mockMapper.Setup(mapper => mapper.Map<GetStudentResponse>(studentEntity))
                       .Returns(studentResponse);

            // Act
            var result = await _controller.GetStudentMethod(studentId);

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            var okResult = result as OkObjectResult;
            okResult.Value.Should().BeEquivalentTo(studentResponse);
        }


        [Fact]
        public async Task GetStudentMethod_ReturnsNotFound_WhenStudentNotFound()
        {
            // Arrange
            var studentId = Guid.NewGuid();

            _mockUnitOfWork.Setup(uow => uow.Students.GetById(studentId))
                           .ReturnsAsync((Student)null);

            // Act
            var result = await _controller.GetStudentMethod(studentId);

            // Assert
            result.Should().BeOfType<NotFoundResult>();
        }


        [Fact]
        public async Task AddStudentMethod_ReturnsCreatedAtAction_WhenModelStateIsValid()
        {
            // Arrange
            var createStudentRequest = _fixture.Create<CreateStudentRequest>();
            var studentEntity = _fixture.Build<Student>()
                                        .With(s => s.Name, createStudentRequest.Name)
                                        .Create();

            _mockMapper.Setup(mapper => mapper.Map<Student>(createStudentRequest))
                       .Returns(studentEntity);

            // Act
            var result = await _controller.AddStudentMethod(createStudentRequest);

            // Assert
            result.Should().BeOfType<CreatedAtActionResult>();
            var createdAtActionResult = result as CreatedAtActionResult;
            createdAtActionResult.ActionName.Should().Be(nameof(StudentsController.GetStudentMethod));
            createdAtActionResult.RouteValues["studentId"].Should().Be(studentEntity.Id);
            createdAtActionResult.Value.Should().Be(studentEntity);
        }

        [Fact]
        public async Task AddStudentMethod_ReturnsBadRequest_WhenModelStateIsInvalid()
        {
            // Arrange
            var createStudentRequest = _fixture.Build<CreateStudentRequest>().Without(x => x.Name).Create(); // Invalid request

            _controller.ModelState.AddModelError("Name", "Name is required");

            // Act
            var result = await _controller.AddStudentMethod(createStudentRequest);

            // Assert
            result.Should().BeOfType<BadRequestResult>();
        }


        [Fact]
        public async Task UpdateStudentMethod_ReturnsNoContent_WhenModelStateIsValid()
        {
            // Arrange
            var updateStudentRequest = _fixture.Create<UpdateStudentRequest>();
            var studentEntity = _fixture.Build<Student>()
                                        .With(s => s.Id, updateStudentRequest.StudentId)
                                        .With(s => s.Name, updateStudentRequest.Name)
                                        .Create();

            _mockMapper.Setup(mapper => mapper.Map<Student>(updateStudentRequest))
                       .Returns(studentEntity);

            // Act
            var result = await _controller.UpdateStudentMethod(updateStudentRequest);

            // Assert
            result.Should().BeOfType<NoContentResult>();
        }



        [Fact]
        public async Task UpdateStudentMethod_ReturnsBadRequest_WhenModelStateIsInvalid()
        {
            // Arrange
            var updateStudentRequest = _fixture.Build<UpdateStudentRequest>().Without(x => x.Name).Create(); // Invalid request

            _controller.ModelState.AddModelError("Name", "Name is required");

            // Act
            var result = await _controller.UpdateStudentMethod(updateStudentRequest);

            // Assert
            result.Should().BeOfType<BadRequestResult>();
        }

        [Fact]
        public async Task GetAllStudentsMethod_ReturnsOkWithStudents()
        {
            // Arrange
            var students = _fixture.CreateMany<Student>().ToList();
            var studentResponses = _fixture.Build<GetStudentResponse>()
                                          .CreateMany(students.Count);

            _mockUnitOfWork.Setup(uow => uow.Students.GetAll())
                           .ReturnsAsync(students);
            _mockMapper.Setup(mapper => mapper.Map<IEnumerable<GetStudentResponse>>(students))
                       .Returns(studentResponses);

            // Act
            var result = await _controller.GetAllStudentsMethod();

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            var okResult = result as OkObjectResult;
            okResult.Value.Should().BeEquivalentTo(studentResponses);
        }

        [Fact]
        public async Task DeleteStudentMethod_ReturnsNoContent_WhenStudentExists()
        {
            // Arrange
            var studentId = Guid.NewGuid();
            var studentEntity = _fixture.Build<Student>()
                                        .With(s => s.Id, studentId)
                                        .Create();

            _mockUnitOfWork.Setup(uow => uow.Students.GetById(studentId))
                           .ReturnsAsync(studentEntity);

            // Act
            var result = await _controller.DeleteStudentMethod(studentId);

            // Assert
            result.Should().BeOfType<NoContentResult>();
        }

        [Fact]
        public async Task DeleteStudentMethod_ReturnsNotFound_WhenStudentDoesNotExist()
        {
            // Arrange
            var studentId = Guid.NewGuid();

            _mockUnitOfWork.Setup(uow => uow.Students.GetById(studentId))
                           .ReturnsAsync((Student)null);

            // Act
            var result = await _controller.DeleteStudentMethod(studentId);

            // Assert
            result.Should().BeOfType<NotFoundResult>();
        }
    }
}
