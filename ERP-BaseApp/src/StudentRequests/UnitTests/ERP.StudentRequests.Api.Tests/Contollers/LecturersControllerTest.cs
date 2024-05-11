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
    public class LecturersControllerTest
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IMapper> _mockMapper;
        private readonly LecturersController _controller;
        private readonly IFixture _fixture;

        public LecturersControllerTest()
        {
            _fixture = new Fixture();
            _mockUnitOfWork = _fixture.Freeze<Mock<IUnitOfWork>>();
            _mockMapper = _fixture.Freeze<Mock<IMapper>>();
            _controller = new LecturersController(_mockUnitOfWork.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetLecturerMethod_ShouldReturnOk_WhenStudentFound()
        {
            // Arrange
            var lecturerId = Guid.NewGuid();
            var lecturerEntity = _fixture.Build<Lecturer>()
                                        .With(l => l.Id, lecturerId)
                                        .Create();
            var lecturerResponse = _fixture.Build<GetLecturerResponse>()
                                          .With(r => r.LecturerId, lecturerId)
                                          .Create();

            _mockUnitOfWork.Setup(uow => uow.Lecturers.GetById(lecturerId))
                           .ReturnsAsync(lecturerEntity);
            _mockMapper.Setup(mapper => mapper.Map<GetLecturerResponse>(lecturerEntity))
                       .Returns(lecturerResponse);

            // Act
            var result = await _controller.GetLecturerMethod(lecturerId);

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            var okResult = result as OkObjectResult;
            okResult.Value.Should().BeEquivalentTo(lecturerResponse);
        }

        [Fact]
        public async Task GetLecturerMethod_ReturnsNotFound_WhenLecturerNotFound()
        {
            // Arrange
            var lecturerId = Guid.NewGuid();

            _mockUnitOfWork.Setup(uow => uow.Lecturers.GetById(lecturerId))
                           .ReturnsAsync((Lecturer)null);

            // Act
            var result = await _controller.GetLecturerMethod(lecturerId);

            // Assert
            result.Should().BeOfType<NotFoundResult>();
        }


        [Fact]
        public async Task AddLecturerMethod_ReturnsCreatedAtAction_WhenModelStateIsValid()
        {
            // Arrange
            var createLecturerRequest = _fixture.Create<CreateLecturerRequest>();
            var lecturerEntity = _fixture.Build<Lecturer>()
                                        .With(l => l.Name, createLecturerRequest.Name)
                                        .Create();

            _mockMapper.Setup(mapper => mapper.Map<Lecturer>(createLecturerRequest))
                       .Returns(lecturerEntity);

            // Act
            var result = await _controller.AddLecturerMethod(createLecturerRequest);

            // Assert
            result.Should().BeOfType<CreatedAtActionResult>();
            var createdAtActionResult = result as CreatedAtActionResult;
            createdAtActionResult.ActionName.Should().Be(nameof(LecturersController.GetLecturerMethod));
            createdAtActionResult.RouteValues["lecturerId"].Should().Be(lecturerEntity.Id);
            createdAtActionResult.Value.Should().Be(lecturerEntity);
        }

        [Fact]
        public async Task AddLecturerMethod_ReturnsBadRequest_WhenModelStateIsInvalid()
        {
            // Arrange
            var createLecturerRequest = _fixture.Build<CreateLecturerRequest>().Without(x => x.Name).Create(); // Invalid request

            _controller.ModelState.AddModelError("Name", "Name is required");

            // Act
            var result = await _controller.AddLecturerMethod(createLecturerRequest);

            // Assert
            result.Should().BeOfType<BadRequestResult>();
        }


        [Fact]
        public async Task UpdateLecturerMethod_ReturnsNoContent_WhenModelStateIsValid()
        {
            // Arrange
            var updateLecturerRequest = _fixture.Create<UpdateLecturerRequest>();
            var lecturerEntity = _fixture.Build<Lecturer>()
                                        .With(l => l.Id, updateLecturerRequest.LecturerId)
                                        .With(l => l.Name, updateLecturerRequest.Name)
                                        .Create();

            _mockMapper.Setup(mapper => mapper.Map<Lecturer>(updateLecturerRequest))
                       .Returns(lecturerEntity);

            // Act
            var result = await _controller.UpdateLecturerMethod(updateLecturerRequest);

            // Assert
            result.Should().BeOfType<NoContentResult>();
        }



        [Fact]
        public async Task UpdateLecturerMethod_ReturnsBadRequest_WhenModelStateIsInvalid()
        {
            // Arrange
            var updateLecturerRequest = _fixture.Build<UpdateLecturerRequest>().Without(x => x.Name).Create(); // Invalid request

            _controller.ModelState.AddModelError("Name", "Name is required");

            // Act
            var result = await _controller.UpdateLecturerMethod(updateLecturerRequest);

            // Assert
            result.Should().BeOfType<BadRequestResult>();
        }

        [Fact]
        public async Task GetAllLecturersMethod_ReturnsOkWithLecturers()
        {
            // Arrange
            var lecturers = _fixture.CreateMany<Lecturer>().ToList();
            var lecturerResponses = _fixture.Build<GetLecturerResponse>()
                                          .CreateMany(lecturers.Count);

            _mockUnitOfWork.Setup(uow => uow.Lecturers.GetAll())
                           .ReturnsAsync(lecturers);
            _mockMapper.Setup(mapper => mapper.Map<IEnumerable<GetLecturerResponse>>(lecturers))
                       .Returns(lecturerResponses);

            // Act
            var result = await _controller.GetAllLecturersMethod();

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            var okResult = result as OkObjectResult;
            okResult.Value.Should().BeEquivalentTo(lecturerResponses);
        }

        [Fact]
        public async Task DeleteLecturerMethod_ReturnsNoContent_WhenLecturerExists()
        {
            // Arrange
            var lecturerId = Guid.NewGuid();
            var lecturerEntity = _fixture.Build<Lecturer>()
                                        .With(l => l.Id, lecturerId)
                                        .Create();

            _mockUnitOfWork.Setup(uow => uow.Lecturers.GetById(lecturerId))
                           .ReturnsAsync(lecturerEntity);

            // Act
            var result = await _controller.DeleteLecturerMethod(lecturerId);

            // Assert
            result.Should().BeOfType<NoContentResult>();
        }

        [Fact]
        public async Task DeleteLecturerMethod_ReturnsNotFound_WhenLecturerDoesNotExist()
        {
            // Arrange
            var lecturerId = Guid.NewGuid();

            _mockUnitOfWork.Setup(uow => uow.Lecturers.GetById(lecturerId))
                           .ReturnsAsync((Lecturer)null);

            // Act
            var result = await _controller.DeleteLecturerMethod(lecturerId);

            // Assert
            result.Should().BeOfType<NotFoundResult>();
        }
    }
}
