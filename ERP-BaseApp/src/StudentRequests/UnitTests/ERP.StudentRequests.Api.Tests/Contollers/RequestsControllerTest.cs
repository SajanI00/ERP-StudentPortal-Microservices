using AutoMapper;
using ERP.StudentRequests.Api.Controllers;
using ERP.StudentRequests.Core.DTOs.Request;
using ERP.StudentRequests.Core.DTOs.Response;
using ERP.StudentRequests.Core.Entity;
using ERP.StudentRequests.Core.Interfaces;
using ERP.StudentRequests.Api.Services.Publishers.Interfaces;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ERP.StudentRequests.Core.Contracts;

namespace ERP.StudentRequests.Api.UnitTests.Controllers
{
    public class RequestsControllerTest
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<IRequestNotificationPublisherService> _mockRequestService;
        private readonly RequestsController _controller;
        private readonly IFixture _fixture;

        public RequestsControllerTest()
        {
            _fixture = new Fixture();
            _mockUnitOfWork = _fixture.Freeze<Mock<IUnitOfWork>>();
            _mockMapper = _fixture.Freeze<Mock<IMapper>>();
            _mockRequestService = _fixture.Freeze<Mock<IRequestNotificationPublisherService>>();
            _controller = new RequestsController(_mockUnitOfWork.Object, _mockMapper.Object, _mockRequestService.Object);
        }

        [Fact]
        public async Task GetStudentRequests_ShouldReturnOk_WhenRequestsFound()
        {
            // Arrange
            var studentId = Guid.NewGuid();
            var requests = _fixture.CreateMany<Request>().ToList();
            var requestResponses = _fixture.Build<GetReqLetterResponse>()
                                          .CreateMany(requests.Count);

            _mockUnitOfWork.Setup(uow => uow.Requests.GetStudentRequestAsync(studentId))
                           .ReturnsAsync(requests);
            _mockMapper.Setup(mapper => mapper.Map<IEnumerable<GetReqLetterResponse>>(requests))
                       .Returns(requestResponses);

            // Act
            var result = await _controller.GetStudentRequests(studentId);

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            var okResult = result as OkObjectResult;
            okResult.Value.Should().BeEquivalentTo(requestResponses);
        }

        [Fact]
        public async Task GetStudentRequests_ReturnsNotFound_WhenRequestsNotFound()
        {
            // Arrange
            var studentId = Guid.NewGuid();

            _mockUnitOfWork.Setup(uow => uow.Requests.GetStudentRequestAsync(studentId))
                           .ReturnsAsync((IEnumerable<Request>)null);

            // Act
            var result = await _controller.GetStudentRequests(studentId);

            // Assert
            result.Should().BeOfType<NotFoundObjectResult>();
            var notFoundResult = result as NotFoundObjectResult;
            notFoundResult.Value.Should().Be("Requests not found");
        }

        [Fact]
        public async Task GetLecturerRequests_ShouldReturnOk_WhenRequestsFound()
        {
            // Arrange
            var lecturerId = Guid.NewGuid();
            var request = _fixture.Create<Request>();
            var requestResponse = _fixture.Build<GetReqLetterResponse>()
                                          .Create();

            _mockUnitOfWork.Setup(uow => uow.Requests.GetLecturerRequestAsync(lecturerId))
                           .ReturnsAsync(request);
            _mockMapper.Setup(mapper => mapper.Map<GetReqLetterResponse>(request))
                       .Returns(requestResponse);

            // Act
            var result = await _controller.GetLecturerRequests(lecturerId);

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            var okResult = result as OkObjectResult;
            okResult.Value.Should().BeEquivalentTo(requestResponse);
        }

        [Fact]
        public async Task GetLecturerRequests_ReturnsNotFound_WhenRequestsNotFound()
        {
            // Arrange
            var lecturerId = Guid.NewGuid();

            _mockUnitOfWork.Setup(uow => uow.Requests.GetLecturerRequestAsync(lecturerId))
                           .ReturnsAsync((Request)null);

            // Act
            var result = await _controller.GetLecturerRequests(lecturerId);

            // Assert
            result.Should().BeOfType<NotFoundObjectResult>();
            var notFoundResult = result as NotFoundObjectResult;
            notFoundResult.Value.Should().Be("Requests not found");
        }

        [Fact]
        public async Task AddStudentRequest_ReturnsCreatedAtAction_WhenModelStateIsValid()
        {
            // Arrange
            var createRequest = _fixture.Create<CreateReqLetterRequest>();
            var requestEntity = _fixture.Create<Request>();
            var requestRecord = _fixture.Create<RequestCreatedNotificationRecord>();

            _mockMapper.Setup(mapper => mapper.Map<Request>(createRequest))
                       .Returns(requestEntity);

            // Act
            var result = await _controller.AddStudentRequest(createRequest);

            // Assert
            result.Should().BeOfType<CreatedAtActionResult>();
            var createdAtActionResult = result as CreatedAtActionResult;
            createdAtActionResult.ActionName.Should().Be(nameof(RequestsController.GetStudentRequests));
            createdAtActionResult.RouteValues["studentId"].Should().Be(requestEntity.StudentId);
            createdAtActionResult.Value.Should().Be(requestEntity);

            _mockRequestService.Verify(x => x.SendNotification(requestRecord), Times.Once);
        }

        [Fact]
        public async Task AddStudentRequest_ReturnsBadRequest_WhenModelStateIsInvalid()
        {
            // Arrange
            var createRequest = _fixture.Build<CreateReqLetterRequest>().Without(x => x.Topic).Create(); // Invalid request

            _controller.ModelState.AddModelError("Topic", "Topic is required");

            // Act
            var result = await _controller.AddStudentRequest(createRequest);

            // Assert
            result.Should().BeOfType<BadRequestResult>();
        }

        [Fact]
        public async Task UpdateStudentRequestMethod_ReturnsNoContent_WhenModelStateIsValid()
        {
            // Arrange
            var updateRequest = _fixture.Create<UpdateReqLetterRequest>();
            var requestEntity = _fixture.Build<Request>()
                                        .With(r => r.Id, updateRequest.StudentId)
                                        .With(r => r.Topic, updateRequest.Topic)
                                        .Create();

            _mockMapper.Setup(mapper => mapper.Map<Request>(updateRequest))
                       .Returns(requestEntity);

            // Act
            var result = await _controller.UpdateStudentRequestMethod(updateRequest);

            // Assert
            result.Should().BeOfType<NoContentResult>();
        }

        [Fact]
        public async Task UpdateStudentRequest_ReturnsBadRequest_WhenModelStateIsInvalid()
        {
            // Arrange
            var updateRequest = _fixture.Build<UpdateReqLetterRequest>().Without(x => x.Topic).Create(); // Invalid request

            _controller.ModelState.AddModelError("Topic", "Topic is required");

            // Act
            var result = await _controller.UpdateStudentRequestMethod(updateRequest);

            // Assert
            result.Should().BeOfType<BadRequestResult>();
        }


    }
}

