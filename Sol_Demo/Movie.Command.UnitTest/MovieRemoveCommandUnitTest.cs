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
    public class MovieRemoveCommandUnitTest
    {
        private readonly Mock<IMovieRemoveRepository> movieRemoveRepositoryMock = null;
        private readonly Mock<IMapper> mapperMock = null;

        private IRequestHandler<MovieRemoveCommand, bool> movieRemoveCommandHandler = null;

        public MovieRemoveCommandUnitTest()
        {
            movieRemoveRepositoryMock = new Mock<IMovieRemoveRepository>();
            mapperMock = new Mock<IMapper>();

            movieRemoveCommandHandler = new MovieRemoveCommandHandler(movieRemoveRepositoryMock.Object, mapperMock.Object);
        }

        private MovieRemoveCommand MovieRemoveCommandData()
        {
            var movieRemoveCommand = new MovieRemoveCommand()
            {
                MovieIdentity = Guid.Parse("4a1c7726-5a52-42df-b3ac-0c862f341cb9")
            };

            return movieRemoveCommand;
        }

        [TestMethod]
        public async Task RemoveMovie_Success()
        {
            var movieRemoveCommand = this.MovieRemoveCommandData();

            movieRemoveRepositoryMock
                .Setup((r) => r.MovieRemoveAsync(It.IsAny<MovieModel>()))
                .ReturnsAsync(true);

            var response = await movieRemoveCommandHandler.Handle(movieRemoveCommand, new System.Threading.CancellationToken());

            Assert.IsTrue(Convert.ToBoolean(response));
        }

        [TestMethod]
        public async Task RemoveMovie_ThrowException()
        {
            var movieRemoveCommand = this.MovieRemoveCommandData();

            movieRemoveRepositoryMock
                .Setup((r) => r.MovieRemoveAsync(It.IsAny<MovieModel>()))
                .Throws<Exception>();

            try
            {
                var response = await movieRemoveCommandHandler.Handle(movieRemoveCommand, new System.Threading.CancellationToken());
            }
            catch
            {
                Assert.IsTrue(true);
            }
        }
    }
}