using Bocatasion.API.Bocatasion.API.Contracts.DTOs.Food;
using Bocatasion.API.Controllers;
using Bocatasion.API.QA;
using Bocatasion.API.Services.Contracts;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Xunit;

namespace Bocatasion.API.Testing
{
    [ExcludeFromCodeCoverage]
    public class SandwichManagementControllerTests
    {
        [Fact]
        public void GetById_Success()
        {
            // Arrange        
            int id = 1;
            var dto = SandwichBuilder.BuildValidSandwichDto();

            Mock<ILogger<SandwichManagementController>> logger = new Mock<ILogger<SandwichManagementController>>(MockBehavior.Strict);
            Mock<ISandwichService> service = new Mock<ISandwichService>(MockBehavior.Strict);
            service.Setup(s => s.GetSandwichById(id)).Returns(dto);

            SandwichManagementController target = new SandwichManagementController(logger.Object, service.Object);

            // Act
            var actual = target.GetSandwichById(id);

            // Assert
            actual.Should().NotBeNull();

            service.Verify(s => s.GetSandwichById(id), Times.Once());
        }

        [Fact]
        public void GetAll_Success()
        {
            // Arrange        
            int id = 1;
            var dtos = SandwichBuilder.BuildValidSandwichDtoCollection();

            Mock<ILogger<SandwichManagementController>> logger = new Mock<ILogger<SandwichManagementController>>(MockBehavior.Strict);
            Mock<ISandwichService> service = new Mock<ISandwichService>(MockBehavior.Strict);
            service.Setup(s => s.GetAllSandwiches()).Returns(dtos);

            SandwichManagementController target = new SandwichManagementController(logger.Object, service.Object);

            // Act
            var actual = target.GetAllSandwiches();

            // Assert
            actual.Should().NotBeNull();

            service.Verify(s => s.GetAllSandwiches(), Times.Once());
        }

        [Fact]
        public void Create_Success()
        {
            // Arrange        
            var creatable = SandwichBuilder.BuildValidSandwichCreatableDto();

            Mock<ILogger<SandwichManagementController>> logger = new Mock<ILogger<SandwichManagementController>>(MockBehavior.Strict);
            Mock<ISandwichService> service = new Mock<ISandwichService>(MockBehavior.Strict);
            service.Setup(s => s.CreateSandwich(creatable)).Returns(new SandwichDto());

            SandwichManagementController target = new SandwichManagementController(logger.Object, service.Object);

            // Act
            var actual = target.CreateSandwich(creatable);

            // Assert
            actual.Should().NotBeNull();

            service.Verify(s => s.CreateSandwich(creatable), Times.Once());
        }

        [Fact]
        public void Update_Success()
        {
            // Arrange        
            int id = 1;
            var updatable = SandwichBuilder.BuildValidSandwichUpdatableDto(id);

            Mock<ILogger<SandwichManagementController>> logger = new Mock<ILogger<SandwichManagementController>>(MockBehavior.Strict);
            Mock<ISandwichService> service = new Mock<ISandwichService>(MockBehavior.Strict);
            service.Setup(s => s.UpdateSandwich(updatable)).Returns(true);

            SandwichManagementController target = new SandwichManagementController(logger.Object, service.Object);

            // Act
            var actual = target.UpdateSandwich(updatable);

            // Assert
            actual.Should().NotBeNull();

            service.Verify(s => s.UpdateSandwich(updatable), Times.Once());
        }

        [Fact]
        public void Delete_Success()
        {
            // Arrange        
            int id = 1;
            var updatable = SandwichBuilder.BuildValidSandwichUpdatableDto(id);

            Mock<ILogger<SandwichManagementController>> logger = new Mock<ILogger<SandwichManagementController>>(MockBehavior.Strict);
            Mock<ISandwichService> service = new Mock<ISandwichService>(MockBehavior.Strict);
            service.Setup(s => s.DeleteSandwich(id)).Verifiable();

            SandwichManagementController target = new SandwichManagementController(logger.Object, service.Object);

            // Act
            var actual = target.DeleteSandwich(id);

            // Assert
            actual.Should().NotBeNull();

            service.Verify(s => s.DeleteSandwich(id), Times.Once());
        }
    }
}
