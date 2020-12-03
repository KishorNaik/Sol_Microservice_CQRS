using AutoMapper;
using Framework.Models;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Movie.Query.Api.Business.Features.Handlers;
using Movie.Query.Api.Business.Features.Queries;
using Movie.Query.Api.Cores.Repository;
using Movies.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movie.Query.UnitTest
{
    [TestClass]
    public class GetAllMoviesDataUnitTest
    {
        private readonly Mock<IGetAllMoviesListRepository> getAllMovieDataRepositoryMock = null;

        private IRequestHandler<GetAllMoviesListQuery, object> requestHandler = null;

        public GetAllMoviesDataUnitTest()
        {
            getAllMovieDataRepositoryMock = new Mock<IGetAllMoviesListRepository>();

            requestHandler = new GetAllMovieListQueryHandler(getAllMovieDataRepositoryMock.Object);
        }

        [TestMethod]
        public async Task Movie_Success()
        {
            getAllMovieDataRepositoryMock
                .Setup((r) => r.GetAllMovieListAsync())
                .ReturnsAsync(new List<MovieModel>() { new MovieModel() { Title = "X-Men" } });

            var response = await requestHandler.Handle(new GetAllMoviesListQuery(), new System.Threading.CancellationToken());

            Assert.IsTrue(response is List<MovieModel>);
        }

        [TestMethod]
        public async Task Movie_Error_OnNull()
        {
            getAllMovieDataRepositoryMock
                .Setup((r) => r.GetAllMovieListAsync())
                .ReturnsAsync((IReadOnlyList<MovieModel>)null);

            var response = await requestHandler.Handle(new GetAllMoviesListQuery(), new System.Threading.CancellationToken());

            Assert.IsTrue(response is ErrorModel);
        }

        [TestMethod]
        public async Task Movie_Error_OnZeroCount()
        {
            getAllMovieDataRepositoryMock
                .Setup((r) => r.GetAllMovieListAsync())
                .ReturnsAsync(new List<MovieModel>());

            var response = await requestHandler.Handle(new GetAllMoviesListQuery(), new System.Threading.CancellationToken());

            Assert.IsTrue(response is ErrorModel);
        }

        [TestMethod]
        public async Task Movie_Error_OnException()
        {
            getAllMovieDataRepositoryMock
                .Setup((r) => r.GetAllMovieListAsync())
                .Throws<Exception>();

            try
            {
                var response = await requestHandler.Handle(new GetAllMoviesListQuery(), new System.Threading.CancellationToken());
            }
            catch
            {
                Assert.IsTrue(true);
            }
        }
    }
}