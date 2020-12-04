using Bocatasion.API.QA;
using Bocatasion.API.Services.Mappers;
using FluentAssertions;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace Bocatasion.API.Services.Testing.Mappers
{
    [ExcludeFromCodeCoverage]
    public class SandwichMapperTests
    {
        [Fact]
        public void MapFromModelToDto_Success()
        {
            // Arrange
            var target = SandwichBuilder.BuildValidSandwichModel();

            // Act
            var result = SandwichMapper.MapToSandwichDto(target);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(target.Id);
            result.Name.Should().Be(target.Name);
            result.Description.Should().Be(target.Description);
            result.Disabled.Should().Be(target.Disabled);
            result.ImageUrl.Should().Be(target.ImageUrl);
            result.Price.Should().Be(target.Price);
        }

        [Fact]
        public void MapFromEntityToModel_Success()
        {
            // Arrange
            int id = 1;
            var target = SandwichBuilder.BuildValidSandwich(id);

            // Act
            var result = SandwichMapper.MapToSandwichModel(target);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(target.Id);
            result.Name.Should().Be(target.Name);
            result.Description.Should().Be(target.Description);
            result.Disabled.Should().Be(target.Disabled);
            result.ImageUrl.Should().Be(target.ImageUrl);
            result.Price.Should().Be(target.Price);
        }

        [Fact]
        public void MapFromCreatableDtoToModel_Success()
        {
            // Arrange
            var target = SandwichBuilder.BuildValidSandwichCreatableDto();

            // Act
            var result = SandwichMapper.MapToSandwichModel(target);

            // Assert
            result.Should().NotBeNull();
            result.Name.Should().Be(target.Name);
            result.Description.Should().Be(target.Description);
            result.Disabled.Should().Be(target.Disabled);
            result.ImageUrl.Should().Be(target.ImageUrl);
            result.Price.Should().Be(target.Price);
        }

        [Fact]
        public void MapFromModelToEntity_Success()
        {
            // Arrange
            var target = SandwichBuilder.BuildValidSandwichModel();

            // Act
            var result = SandwichMapper.MapToSandwichEntity(target);

            // Assert
            result.Should().NotBeNull();
            result.Name.Should().Be(target.Name);
            result.Description.Should().Be(target.Description);
            result.Disabled.Should().Be(target.Disabled);
            result.ImageUrl.Should().Be(target.ImageUrl);
            result.Price.Should().Be(target.Price);
        }

        [Fact]
        public void MapFromEntityToDto_Success()
        {
            // Arrange
            int id = 1;
            var target = SandwichBuilder.BuildValidSandwich(id);

            // Act
            var result = SandwichMapper.MapToSandwichDto(target);

            // Assert
            result.Should().NotBeNull();
            result.Name.Should().Be(target.Name);
            result.Description.Should().Be(target.Description);
            result.Disabled.Should().Be(target.Disabled);
            result.ImageUrl.Should().Be(target.ImageUrl);
            result.Price.Should().Be(target.Price);
        }

        [Fact]
        public void MapUpdatesToEntity_Success()
        {
            // Arrange
            int id = 1;
            var entity = SandwichBuilder.BuildValidSandwich(id);
            var updatable = SandwichBuilder.BuildValidSandwichUpdatableDto(id);

            // Act
            SandwichMapper.MapUpdatesToEntity(entity, updatable);

            // Assert
            updatable.Should().NotBeNull();
            updatable.Name.Should().Be(entity.Name);
            updatable.Description.Should().Be(entity.Description);
            updatable.Disabled.Should().Be(entity.Disabled);
            updatable.ImageUrl.Should().Be(entity.ImageUrl);
            updatable.Price.Should().Be(entity.Price);
        }
    }
}
