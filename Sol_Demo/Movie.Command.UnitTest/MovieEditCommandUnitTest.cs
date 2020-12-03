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
    public class MovieEditCommandUnitTest
    {
        private readonly Mock<IMovieEditRepository> movieEditRepositoryMock = null;
        private readonly Mock<IMapper> mapperMock = null;

        private IRequestHandler<MovieEditCommand, Object> movieEditCommandHandler = null;

        public MovieEditCommandUnitTest()
        {
            movieEditRepositoryMock = new Mock<IMovieEditRepository>();
            mapperMock = new Mock<IMapper>();

            movieEditCommandHandler = new MovieEditCommandHandler(movieEditRepositoryMock.Object, mapperMock.Object);
        }

        private MovieEditCommand MovieEditCommandData()
        {
            var movieEditCommand = new MovieEditCommand()
            {
                MovieIdentity = Guid.Parse("4a1c7726-5a52-42df-b3ac-0c862f341cb9"),
                Title = "Home Alone",
                ReleaseDate = new DateTime(1995, 10, 1)
            };

            return movieEditCommand;
        }

        [TestMethod]
        public async Task EditMovie_Success()
        {
            var movieEditCommand = this.MovieEditCommandData();

            movieEditRepositoryMock
                .Setup((r) => r.MovieEditAsync(It.IsAny<MovieModel>()))
                .ReturnsAsync(true);

            var response = await movieEditCommandHandler.Handle(movieEditCommand, new System.Threading.CancellationToken());

            Assert.IsTrue(Convert.ToBoolean(response));
        }

        [TestMethod]
        public async Task EditMovie_MovieExists()
        {
            var movieEditCommand = this.MovieEditCommandData();

            movieEditRepositoryMock
                .Setup((r) => r.MovieEditAsync(It.IsAny<MovieModel>()))
                .ReturnsAsync(false);

            var response = await movieEditCommandHandler.Handle(movieEditCommand, new System.Threading.CancellationToken());

            Assert.IsTrue(response is ErrorModel);
        }

        [TestMethod]
        public async Task EditMovie_ThrowException()
        {
            var movieEditCommand = this.MovieEditCommandData();

            movieEditRepositoryMock
                .Setup((r) => r.MovieEditAsync(It.IsAny<MovieModel>()))
                .Throws<Exception>();

            try
            {
                var response = await movieEditCommandHandler.Handle(movieEditCommand, new System.Threading.CancellationToken());
            }
            catch
            {
                Assert.IsTrue(true);
            }
        }
    }
}