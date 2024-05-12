using AutoMapper;
using ERP.StudentRequests.Api.Controllers;
using ERP.StudentRequests.Core.DTOs.Request;
using ERP.StudentRequests.Core.DTOs.Response;
using ERP.StudentRequests.Core.Entity;
using ERP.StudentRequests.Core.Interfaces;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ERP.StudentRequests.Api.Tests.Contollers
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
            // Arrange : setting up the necessary conditions for the test
            var studentId = Guid.NewGuid(); // generating a random student ID for testing

                         // creating a mock student entity with the generated student ID
            var studentEntity = _fixture.Build<Student>()
                                        .With(s => s.Id, studentId)
                                        .Create();

                        // creating a mock response object with the student ID match to the the generated ID
            var studentResponse = _fixture.Build<GetStudentResponse>()
                                          .With(r => r.StudentId, studentId)
                                          .Create();

                       // setting up the mock UnitofWork to return the mock student entity when GetById is called with the generated student ID
            _mockUnitOfWork.Setup(uow => uow.Students.GetById(studentId))
                           .ReturnsAsync(studentEntity);

                      // setting up the mock mapper to return the mock student response when mapping the mock student entity
            _mockMapper.Setup(mapper => mapper.Map<GetStudentResponse>(studentEntity))
                       .Returns(studentResponse);

            // Act :  invoke the method we want to test
            var result = await _controller.GetStudentMethod(studentId);

            // Assert : verify that the method under test behaves as expected
            result.Should().BeOfType<OkObjectResult>();
            var okResult = result as OkObjectResult;
            okResult.Value.Should().BeEquivalentTo(studentResponse); // verifying that the returned value match the mock student response
        }


        [Fact]
        public async Task GetStudentMethod_ReturnsNotFound_WhenStudentNotFound()
        {
            // Arrange

                        // the behavior of the mockUnitOfWork is set up
                       // tell it that when the GetStudentRequestAsync method is called with the specified studentId, it should return null
            var studentId = Guid.NewGuid();

            _mockUnitOfWork.Setup(uow => uow.Students.GetById(studentId))
                           .ReturnsAsync((Student)null);

            // Act
                       //call the GetStudentRequests method of the controller and pass the studentId
                      //this simulates invoking the action method
            var result = await _controller.GetStudentMethod(studentId);

            // Assert
                     //we expect the result to be of type NotFoundObjectResult.
                    //this ensures that when the requests are not found, the controller returns a 404 Not Found status code
            result.Should().BeOfType<NotFoundResult>();

                   //cast the result to NotFoundObjectResult to access its properties
            var notFoundResult = result as NotFoundObjectResult;

                  //we assert that the value of the NotFoundObjectResult should be "Requests not found"
                  //this verifies that correct error message is returned when requests are not found
            notFoundResult.Value.Should().Be("Requests not found");

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
