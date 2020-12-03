using AutoMapper;
using Framework.Models;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Movie.Command.Api.Business.Features.Commands;
using Movie.Command.Api.Business.Features.Handlers;
using Movie.Command.Api.Cores.Repository;
using Movies.Models;
using System;
using System.Threading.Tasks;

namespace Movie.Command.UnitTest
{
    [TestClass]
    public class MovieCreateCommandUnitTest
    {
        private readonly Mock<IMovieCreateRepository> movieCreateRepositoryMock = null;
        private readonly Mock<IMapper> mapperMock = null;

        private IRequestHandler<MovieCreateCommand, Object> movieCreateCommandHandler = null;

        public MovieCreateCommandUnitTest()
        {
            movieCreateRepositoryMock = new Mock<IMovieCreateRepository>();
            mapperMock = new Mock<IMapper>();

            movieCreateCommandHandler = new MovieCreateCommandHandler(movieCreateRepositoryMock.Object, mapperMock.Object);
        }

        private MovieCreateCommand MovieCreateCommandData()
        {
            var movieCreateCommand = new MovieCreateCommand()
            {
                Title = "X-Men",
                ReleaseDate = new DateTime(2020, 10, 1)
            };

            return movieCreateCommand;
        }

        [TestMethod]
        public async Task AddMovie_Success()
        {
            var movieCreateCommand = this.MovieCreateCommandData();

            movieCreateRepositoryMock
                .Setup((r) => r.MoviewCreateAsync(It.IsAny<MovieModel>()))
                .ReturnsAsync(true);

            var response = await movieCreateCommandHandler.Handle(movieCreateCommand, new System.Threading.CancellationToken());

            Assert.IsTrue(Convert.ToBoolean(response));
        }

        [TestMethod]
        public async Task AddMovie_MovieExists()
        {
            var movieCreateCommand = this.MovieCreateCommandData();

            movieCreateRepositoryMock
                .Setup((r) => r.MoviewCreateAsync(It.IsAny<MovieModel>()))
                .ReturnsAsync(false);

            var response = await movieCreateCommandHandler.Handle(movieCreateCommand, new System.Threading.CancellationToken());

            Assert.IsTrue(response is ErrorModel);
        }

        [TestMethod]
        public async Task AddMovie_ThrowException()
        {
            var movieCreateCommand = this.MovieCreateCommandData();

            movieCreateRepositoryMock
                .Setup((r) => r.MoviewCreateAsync(It.IsAny<MovieModel>()))
                .Throws<Exception>();

            try
            {
                var response = await movieCreateCommandHandler.Handle(movieCreateCommand, new System.Threading.CancellationToken());
            }
            catch
            {
                Assert.IsTrue(true);
            }
        }
    }
}