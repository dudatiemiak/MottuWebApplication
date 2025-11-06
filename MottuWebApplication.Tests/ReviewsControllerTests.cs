using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using MottuWebApplication.Infrastructure.Data;
using MottuWebApplication.Domain.Entities;
using MottuWebApplication.Application.Services;
using MottuWebApplication.Controllers;
using Xunit;



namespace MottuWebApplication.Tests
{
    public class ReviewsControllerTests
    {
        private AppDbContext SetupDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: System.Guid.NewGuid().ToString())
                .Options;

            var dbContext = new AppDbContext(options);
            dbContext.Database.EnsureCreated();
            return dbContext;
        }

        private Mock<IPredictionService> SetupPredictionServiceMock(bool precisaManutencao, float score)
        {
            var fakeModelOutput = new ModelOutput
            {
                PredicaoPrecisaManutencao = precisaManutencao,
                Score = score
            };

            var mockService = new Mock<IPredictionService>();
            mockService
                .Setup(s => s.PredictManutencao(It.IsAny<ModelInput>()))
                .Returns(fakeModelOutput);

            return mockService;
        }

        [Fact]
        public async Task PostReview_PrecisaManutencao_True_DeveSalvarComoPrecisaManutencao()
        {
            var dbContext = SetupDbContext();
            var mockService = SetupPredictionServiceMock(true, 0.95f);
            var controller = new ReviewsController(dbContext, mockService.Object);

            var input = new CreateReview
            {
                KmRodados = 5000,
                DiasDesdeUltimaManutencao = 180
            };

            var actionResult = await controller.PostReview(input);

            Assert.IsType<CreatedAtActionResult>(actionResult.Result);
            var savedReview = await dbContext.Reviews.FirstOrDefaultAsync();
            Assert.NotNull(savedReview);
            Assert.Equal("Positivo", savedReview.PredictedManutencao);
            Assert.Equal(0.95f, savedReview.ManutencaoScore);
        }

        [Fact]
        public async Task PostReview_PrecisaManutencao_False_DeveSalvarComoNaoPrecisaManutencao()
        {
            var dbContext = SetupDbContext();
            var mockService = SetupPredictionServiceMock(false, 0.10f);
            var controller = new ReviewsController(dbContext, mockService.Object);

            var input = new CreateReview
            {
                KmRodados = 1000,
                DiasDesdeUltimaManutencao = 30
            };

            var actionResult = await controller.PostReview(input);

            Assert.IsType<CreatedAtActionResult>(actionResult.Result);
            var savedReview = await dbContext.Reviews.FirstOrDefaultAsync();
            Assert.NotNull(savedReview);
            Assert.Equal("Negativo", savedReview.PredictedManutencao);
            Assert.Equal(0.10f, savedReview.ManutencaoScore);
        }

        [Fact]
        public async Task GetReview_ComIdInexistente_DeveRetornarNotFound()
        {
            var dbContext = SetupDbContext();
            var mockService = SetupPredictionServiceMock(true, 0.9f);
            var controller = new ReviewsController(dbContext, mockService.Object);

            var actionResult = await controller.GetReview(999);

            Assert.IsType<NotFoundResult>(actionResult.Result);
        }
    }
}
