﻿namespace Catalog.UnitTests.Services.Brands.Commands;

public sealed class CreateBrandCommandHandlerTests
{
    //[Fact]
    //public async Task CreateBrandHandler_ShouldReturnSuccessResult()
    //{
    //    //// Arrange
    //    //var brandRepository = new Mock<IBrandRepository>();
    //    //var unitOfWork = new Mock<IUnitOfWork>();
    //    //var command = new CreateBrandCommand("Test", "Test");
    //    //var validator = new CreateBrandValidator();
    //    //var handler = new CreateBrandCommandHandler(unitOfWork.Object, brandRepository.Object, validator);

    //    //// Act
    //    //var result = await handler.Handle(command);

    //    // Assert
    //    return 
    //}

    [Fact]
    public void Test1()
    {
        int a = 4;
        a.Should().Be(4);
    }

}
