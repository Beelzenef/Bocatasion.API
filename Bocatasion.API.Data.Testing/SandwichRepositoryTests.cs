using Bocatasion.API.Bocatasion.API.Data;
using Bocatasion.API.Bocatasion.API.Data.Repositories;
using Bocatasion.API.Data.Contracts.Entities;
using Bocatasion.API.QA;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Xunit;

namespace Bocatasion.API.Data.Testing
{
    [ExcludeFromCodeCoverage]
    public class SandwichRepositoryTests
    {
        private Context _mockedContext;

        public SandwichRepositoryTests()
        {
            _mockedContext = GetMockContext();
            CleanUp();
        }

        [Fact]
        public void SandwichRepo_GetAll_Success()
        {
            // Arrange
            var models = SandwichBuilder.BuildValidSandwichCollection();

            _mockedContext.AddRange(models);
            _mockedContext.SaveChanges();

            var repo = new SandwichRepository(_mockedContext);

            // Act
            var result = repo.GetAll();

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(models.Count());

            // Clean up
            CleanUp();
        }

        [Fact]
        public void SandwichRepo_GetById_Success()
        {
            // Arrange
            int id = 2;
            var model = SandwichBuilder.BuildValidSandwich(id);

            _mockedContext.Add(model);
            _mockedContext.SaveChanges();

            var repo = new SandwichRepository(_mockedContext);

            // Act
            var result = repo.GetById(model.Id);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().NotBe(0);
            result.Id.Should().Be(model.Id);

            // Clean up
            CleanUp();
        }


        [Fact]
        public void SandwichRepo_GetById_IdIsZero_ShouldFail()
        {
            // Arrange
            var model = SandwichBuilder.BuildValidSandwich(0);

            _mockedContext.Add(model);
            _mockedContext.SaveChanges();

            var repo = new SandwichRepository(_mockedContext);

            Sandwich result = null;

            // Act - Assert
            Assert.Throws<ArgumentNullException>(()
                => result = repo.GetById(0));

            result.Should().BeNull();

            // Clean up
            CleanUp();
        }

        [Fact]
        public void SandwichRepo_Delete_Success()
        {
            // Arrange
            int id = 2;
            var model = SandwichBuilder.BuildValidSandwich(id);

            _mockedContext.Add(model);
            _mockedContext.SaveChanges();

            var repo = new SandwichRepository(_mockedContext);

            // Act
            repo.Delete(model.Id);
            repo.Save();

            // Assert
            var models = repo.GetAll();
            models.Should().HaveCount(0);

            // Clean up
            CleanUp();
        }

        [Fact]
        public void SandwichRepo_Delete_IdIsZero_ShouldFail()
        {
            // Arrange
            var model = SandwichBuilder.BuildValidSandwich(0);

            _mockedContext.Add(model);
            _mockedContext.SaveChanges();

            var repo = new SandwichRepository(_mockedContext);

            // Act - Assert
            Assert.Throws<ArgumentNullException>(()
                => repo.Delete(0));

            var models = repo.GetAll();
            models.Should().HaveCount(1);

            // Clean up
            CleanUp();
        }

        [Fact]
        public void SandwichRepo_Delete_EntityNotExists_ShouldFail()
        {
            // Arrange
            var model = SandwichBuilder.BuildValidSandwich(1);

            _mockedContext.Add(model);
            _mockedContext.SaveChanges();

            var repo = new SandwichRepository(_mockedContext);

            // Act - Assert
            repo.Delete(2);

            var models = repo.GetAll();
            models.Should().HaveCount(1);

            // Clean up
            CleanUp();
        }

        [Fact]
        public void SandwichRepo_Insert_Success()
        {
            // Arrange
            var model = SandwichBuilder.BuildValidSandwich(1);

            var repo = new SandwichRepository(_mockedContext);

            // Act 
            repo.Insert(model);
            repo.Save();

            // Assert
            var models = repo.GetAll();
            models.Should().HaveCount(1);

            // Clean up
            CleanUp();
        }

        [Fact]
        public void SandwichRepo_Insert_EntityIsNull_Success()
        {
            // Arrange
            Sandwich model = null;

            var repo = new SandwichRepository(_mockedContext);

            // Act - Assert
            Assert.Throws<ArgumentNullException>(()
                => repo.Insert(model));

            var models = repo.GetAll();
            models.Should().HaveCount(0);

            // Clean up
            CleanUp();
        }

        [Fact]
        public void SandwichRepo_Update_Success()
        {
            // Arrange
            var model = SandwichBuilder.BuildValidSandwich(1);

            _mockedContext.Add(model);
            _mockedContext.SaveChanges();

            string newDescription = "New description";

            model.Description = newDescription;

            var repo = new SandwichRepository(_mockedContext);

            // Act 
            repo.Update(model);
            repo.Save();

            // Assert
            var models = repo.GetAll();
            models.Should().HaveCount(1);
            var updatedModel = repo.GetById(model.Id);
            updatedModel.Description.Should().Be(newDescription);

            // Clean up
            CleanUp();
        }

        [Fact]
        public void SandwichRepo_Update_EntityIsNull_ShouldFail()
        {
            // Arrange
            Sandwich model = null;

            var repo = new SandwichRepository(_mockedContext);

            // Act - Assert
            Assert.Throws<ArgumentNullException>(()
                => repo.Update(model));

            // Clean up
            CleanUp();
        }

        private Context GetMockContext()
        {
            var models = SandwichBuilder.BuildValidSandwichCollection();

            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "Bocatasion")
                .Options;

            var context = new Context(options);
            context.AddRange(models);
            context.SaveChanges();

            return context;
        }

        private void CleanUp()
        {
            var models = _mockedContext.Sandwiches;

            _mockedContext.RemoveRange(models);
            _mockedContext.SaveChanges();
        }
    }
}
