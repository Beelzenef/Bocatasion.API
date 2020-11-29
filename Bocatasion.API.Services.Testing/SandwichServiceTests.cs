using Bocatasion.API.Bocatasion.API.Contracts.DTOs.Food;
using Bocatasion.API.Bocatasion.API.Data.Contracts.Repositories;
using Bocatasion.API.Data.Contracts.Entities;
using Bocatasion.API.QA;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Xunit;

namespace Bocatasion.API.Services.Testing
{
    [ExcludeFromCodeCoverage]
    public class SandwichServiceTests
    {
        private Mock<ISandwichRepository> repoMock;
        public SandwichServiceTests()
        {
            repoMock = new Mock<ISandwichRepository>();
        }

        [Fact]
        public void SandwichService_GetAllSandwiches_Success()
        {
            // Arrange
            IEnumerable<Sandwich> data = SandwichBuilder.BuildValidSandwichCollection();

            repoMock.Setup(x => x.GetAll())
                .Returns(data);
            var service = GenerateMockedService();

            // Act
            var result = service.GetAllSandwiches();

            // Assert
            result.Should().NotBeNull();
            result.Count().Should().Be(data.Count());
            result.Should().BeAssignableTo<IEnumerable<SandwichDto>>();
            repoMock.Verify(x => x.GetAll(), Times.Once);

        }

        [Fact]
        public void SandwichService_GetById_Success()
        {
            // Arrange
            Sandwich data = SandwichBuilder.BuildValidSandwich(0);

            repoMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(data);
            var service = GenerateMockedService();

            // Act
            var result = service.GetSandwichById(data.Id);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<SandwichDto>();
            repoMock.Verify(x => x.GetById(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void SandwichService_GetById_IdIsZero_ShouldFail()
        {
            // Arrange
            Sandwich data = SandwichBuilder.BuildValidSandwich(0);
            int id = 0;

            repoMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(data);
            var service = GenerateMockedService();

            // Act
            var result = service.GetSandwichById(0);

            // Assert
            result.Should().BeNull();
            repoMock.Verify(x => x.GetById(It.IsAny<int>()), Times.Never);
        }

        [Fact]
        public void SandwichService_GetById_NoData_ShouldFail()
        {
            // Arrange
            Sandwich data = null;
            int id = 22;

            repoMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(data);
            var service = GenerateMockedService();

            // Act
            var result = service.GetSandwichById(id);

            // Assert
            result.Should().BeNull();
            repoMock.Verify(x => x.GetById(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void SandwichService_Delete_Success()
        {
            // Arrange
            Sandwich data = SandwichBuilder.BuildValidSandwich(0);

            repoMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(data);
            repoMock.Setup(x => x.Delete(It.IsAny<int>()))
                .Verifiable();
            repoMock.Setup(x => x.Save())
                .Verifiable();
            var service = GenerateMockedService();

            // Act
            service.DeleteSandwich(data.Id);

            // Assert
            repoMock.Verify(x => x.GetById(It.IsAny<int>()), Times.Once);
            repoMock.Verify(x => x.Delete(It.IsAny<int>()), Times.Once);
            repoMock.Verify(x => x.Save(), Times.Once);
        }

        [Fact]
        public void SandwichService_Delete_IdIsZero_ShouldFail()
        {
            // Arrange
            int id = 0;
            Sandwich data = SandwichBuilder.BuildValidSandwich(0);

            repoMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(data);
            repoMock.Setup(x => x.Delete(It.IsAny<int>()))
                .Verifiable();
            repoMock.Setup(x => x.Save())
                .Verifiable();
            var service = GenerateMockedService();

            // Act
            Assert.Throws<ArgumentNullException>(()
               => service.DeleteSandwich(id));

            // Assert
            repoMock.Verify(x => x.GetById(It.IsAny<int>()), Times.Never);
            repoMock.Verify(x => x.Delete(It.IsAny<int>()), Times.Never);
            repoMock.Verify(x => x.Save(), Times.Never);
        }

        [Fact]
        public void SandwichService_Delete_NoData_ShouldFail()
        {
            // Arrange
            int id = 1;
            Sandwich data = null;

            repoMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(data);
            repoMock.Setup(x => x.Delete(It.IsAny<int>()))
                .Verifiable();
            repoMock.Setup(x => x.Save())
                .Verifiable();
            var service = GenerateMockedService();

            // Act
            service.DeleteSandwich(id);

            // Assert
            repoMock.Verify(x => x.GetById(It.IsAny<int>()), Times.Once);
            repoMock.Verify(x => x.Delete(It.IsAny<int>()), Times.Never);
            repoMock.Verify(x => x.Save(), Times.Never);
        }

        [Fact]
        public void SandwichService_Delete_DeleteThrows_ShouldFail()
        {
            // Arrange
            int id = 1;
            Sandwich data = null;

            repoMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(data);
            repoMock.Setup(x => x.Delete(It.IsAny<int>()))
                .Throws<Exception>();
            repoMock.Setup(x => x.Save())
                .Verifiable();
            var service = GenerateMockedService();

            // Act
            service.DeleteSandwich(id);

            // Assert
            repoMock.Verify(x => x.GetById(It.IsAny<int>()), Times.Once);
            repoMock.Verify(x => x.Delete(It.IsAny<int>()), Times.Never);
            repoMock.Verify(x => x.Save(), Times.Never);
        }

        [Fact]
        public void SandwichService_Delete_SaveThrows_ShouldFail()
        {
            // Arrange
            int id = 1;
            Sandwich data = null;

            repoMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(data);
            repoMock.Setup(x => x.Delete(It.IsAny<int>()))
                .Verifiable();
            repoMock.Setup(x => x.Save())
                .Throws<Exception>();
            var service = GenerateMockedService();

            // Act
            service.DeleteSandwich(id);

            // Assert
            repoMock.Verify(x => x.GetById(It.IsAny<int>()), Times.Once);
            repoMock.Verify(x => x.Delete(It.IsAny<int>()), Times.Never);
            repoMock.Verify(x => x.Save(), Times.Never);
        }

        [Fact]
        public void SandwichService_CreateSandwich_Success()
        {
            // Arrange
            SandwichCreatableDto data = SandwichBuilder.BuildValidSandwichCreatableDto();

            repoMock.Setup(x => x.Insert(It.IsAny<Sandwich>()))
                .Verifiable();
            repoMock.Setup(x => x.Save())
                .Verifiable();
            var service = GenerateMockedService();

            // Act
            var result = service.CreateSandwich(data);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<SandwichDto>();
            repoMock.Verify(x => x.Insert(It.IsAny<Sandwich>()), Times.Once);
            repoMock.Verify(x => x.Save(), Times.Once);
        }

        [Fact]
        public void SandwichService_CreateSandwich_CreatableIsNull_ShouldFail()
        {
            // Arrange
            SandwichCreatableDto data = null;

            repoMock.Setup(x => x.Insert(It.IsAny<Sandwich>()))
                .Verifiable();
            repoMock.Setup(x => x.Save())
                .Verifiable();
            var service = GenerateMockedService();

            SandwichDto result = null;

            // Act
            Assert.Throws<ArgumentNullException>(()
               => result = service.CreateSandwich(data));

            // Assert
            result.Should().BeNull();
            repoMock.Verify(x => x.Insert(It.IsAny<Sandwich>()), Times.Never);
            repoMock.Verify(x => x.Save(), Times.Never);
        }

        [Fact]
        public void SandwichService_CreateSandwich_InsertThrows_ShouldFail()
        {
            // Arrange
            SandwichCreatableDto data = SandwichBuilder.BuildValidSandwichCreatableDto();

            repoMock.Setup(x => x.Insert(It.IsAny<Sandwich>()))
               .Throws<Exception>();
            repoMock.Setup(x => x.Save())
                .Verifiable();
            var service = GenerateMockedService();

            SandwichDto result = null;

            // Act
            Assert.Throws<DbUpdateException>(()
               => result = service.CreateSandwich(data));

            // Assert
            result.Should().BeNull();
            repoMock.Verify(x => x.Insert(It.IsAny<Sandwich>()), Times.Once);
            repoMock.Verify(x => x.Save(), Times.Never);
        }

        [Fact]
        public void SandwichService_CreateSandwich_SaveThrows_ShouldFail()
        {
            // Arrange
            SandwichCreatableDto data = SandwichBuilder.BuildValidSandwichCreatableDto();

            repoMock.Setup(x => x.Insert(It.IsAny<Sandwich>()))
                .Verifiable();
            repoMock.Setup(x => x.Save())
                .Throws<Exception>();
            var service = GenerateMockedService();

            SandwichDto result = null;

            // Act
            Assert.Throws<DbUpdateException>(()
               => result = service.CreateSandwich(data));

            // Assert
            result.Should().BeNull();
            repoMock.Verify(x => x.Insert(It.IsAny<Sandwich>()), Times.Once);
            repoMock.Verify(x => x.Save(), Times.Once);
        }

        [Fact]
        public void SandwichService_UpdateSandwich_Success()
        {
            // Arrange
            int id = 1;
            Sandwich existingData = SandwichBuilder.BuildValidSandwich(id);
            SandwichUpdatableDto data = SandwichBuilder.BuildValidSandwichUpdatableDto(id);

            repoMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(existingData);
            repoMock.Setup(x => x.Update(It.IsAny<Sandwich>()))
                .Verifiable();
            repoMock.Setup(x => x.Save())
                .Verifiable();
            var service = GenerateMockedService();

            // Act
            var result = service.UpdateSandwich(data);

            // Assert
            result.Should().BeTrue();
            repoMock.Verify(x => x.GetById(It.IsAny<int>()), Times.Once);
            repoMock.Verify(x => x.Update(It.IsAny<Sandwich>()), Times.Once);
            repoMock.Verify(x => x.Save(), Times.Once);
        }

        [Fact]
        public void SandwichService_UpdateSandwich_UpdatableIsNull_ShouldFail()
        {
            // Arrange
            int id = 1;
            Sandwich existingData = SandwichBuilder.BuildValidSandwich(id);
            SandwichUpdatableDto data = null;

            repoMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(existingData);
            repoMock.Setup(x => x.Update(It.IsAny<Sandwich>()))
                .Verifiable();
            repoMock.Setup(x => x.Save())
                .Verifiable();
            var service = GenerateMockedService();

            bool result = false;

            // Act
            Assert.Throws<ArgumentNullException>(()
               => result = service.UpdateSandwich(data));

            // Assert
            result.Should().BeFalse();
            repoMock.Verify(x => x.GetById(It.IsAny<int>()), Times.Never);
            repoMock.Verify(x => x.Insert(It.IsAny<Sandwich>()), Times.Never);
            repoMock.Verify(x => x.Save(), Times.Never);
        }

        [Fact]
        public void SandwichService_UpdateSandwich_NoData_ShouldFail()
        {
            // Arrange
            int id = 1;
            Sandwich existingData = null;
            SandwichUpdatableDto data = SandwichBuilder.BuildValidSandwichUpdatableDto(id);

            repoMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(existingData);
            repoMock.Setup(x => x.Update(It.IsAny<Sandwich>()))
                .Verifiable();
            repoMock.Setup(x => x.Save())
                .Verifiable();
            var service = GenerateMockedService();

            // Act
            var result = service.UpdateSandwich(data);

            // Assert
            result.Should().BeFalse();
            repoMock.Verify(x => x.GetById(It.IsAny<int>()), Times.Once);
            repoMock.Verify(x => x.Update(It.IsAny<Sandwich>()), Times.Never);
            repoMock.Verify(x => x.Save(), Times.Never);
        }

        [Fact]
        public void SandwichService_UpdateSandwich_UpdatableThrows_ShouldFail()
        {
            // Arrange
            int id = 1;
            Sandwich existingData = null;
            SandwichUpdatableDto data = SandwichBuilder.BuildValidSandwichUpdatableDto(id);

            repoMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(existingData);
            repoMock.Setup(x => x.Update(It.IsAny<Sandwich>()))
                .Throws<Exception>();
            repoMock.Setup(x => x.Save())
                .Verifiable();
            var service = GenerateMockedService();

            // Act
            bool result = service.UpdateSandwich(data);

            // Assert
            result.Should().BeFalse();
            repoMock.Verify(x => x.GetById(It.IsAny<int>()), Times.Once);
            repoMock.Verify(x => x.Update(It.IsAny<Sandwich>()), Times.Never);
            repoMock.Verify(x => x.Save(), Times.Never);
        }

        [Fact]
        public void SandwichService_UpdateSandwich_SaveThrows_ShouldFail()
        {
            // Arrange
            int id = 1;
            Sandwich existingData = null;
            SandwichUpdatableDto data = SandwichBuilder.BuildValidSandwichUpdatableDto(id);

            repoMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(existingData);
            repoMock.Setup(x => x.Update(It.IsAny<Sandwich>()))
                .Verifiable();
            repoMock.Setup(x => x.Save())
                .Throws<Exception>();
            var service = GenerateMockedService();

            // Act
            bool result = service.UpdateSandwich(data);

            // Assert
            result.Should().BeFalse();
            repoMock.Verify(x => x.GetById(It.IsAny<int>()), Times.Once);
            repoMock.Verify(x => x.Update(It.IsAny<Sandwich>()), Times.Never);
            repoMock.Verify(x => x.Save(), Times.Never);
        }

        private SandwichService GenerateMockedService()
        {
            var service = new SandwichService(repoMock.Object);
            return service;
        }
    }
}
