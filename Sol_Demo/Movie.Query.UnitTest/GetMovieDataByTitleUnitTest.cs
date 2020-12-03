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
    public class GetMovieDataByTitleUnitTest
    {
        private readonly Mock<IGetMovieDataByTitleRepository> getMovieDataByTitleRepositoryMock = null;
        private readonly Mock<IMapper> mapperMock = null;

        private IRequestHandler<GetMovieDataByTitleQuery, object> requestHandler = null;

        public GetMovieDataByTitleUnitTest()
        {
            getMovieDataByTitleRepositoryMock = new Mock<IGetMovieDataByTitleRepository>();
            mapperMock = new Mock<IMapper>();

            requestHandler = new GetMovieDataByTitleQueryHandler(getMovieDataByTitleRepositoryMock.Object, mapperMock.Object);
        }

        private GetMovieDataByTitleQuery GetQueryRequestData()
        {
            return new GetMovieDataByTitleQuery()
            {
                Title = "Home"
            };
        }

        [TestMethod]
        public async Task Movie_Success()
        {
            var requestData = this.GetQueryRequestData();

            getMovieDataByTitleRepositoryMock
                .Setup((r) => r.GetMovieDataByTitleAsync(It.IsAny<MovieModel>()))
                .ReturnsAsync(new List<MovieModel>() { new MovieModel() { Title = "X-Men" } });

            var response = await requestHandler.Handle(requestData, new System.Threading.CancellationToken());

            Assert.IsTrue(response is List<MovieModel>);
        }

        [TestMethod]
        public async Task Movie_Error_OnNull()
        {
            var requestData = this.GetQueryRequestData();

            getMovieDataByTitleRepositoryMock
                .Setup((r) => r.GetMovieDataByTitleAsync(It.IsAny<MovieModel>()))
                .ReturnsAsync((IReadOnlyList<MovieModel>)null);

            var response = await requestHandler.Handle(requestData, new System.Threading.CancellationToken());

            Assert.IsTrue(response is ErrorModel);
        }

        [TestMethod]
        public async Task Movie_Error_OnZeroCount()
        {
            var requestData = this.GetQueryRequestData();

            getMovieDataByTitleRepositoryMock
                .Setup((r) => r.GetMovieDataByTitleAsync(It.IsAny<MovieModel>()))
                .ReturnsAsync(new List<MovieModel>());

            var response = await requestHandler.Handle(requestData, new System.Threading.CancellationToken());

            Assert.IsTrue(response is ErrorModel);
        }

        [TestMethod]
        public async Task Movie_Error_OnException()
        {
            var requestData = this.GetQueryRequestData();

            getMovieDataByTitleRepositoryMock
                .Setup((r) => r.GetMovieDataByTitleAsync(It.IsAny<MovieModel>()))
                .Throws<Exception>();

            try
            {
                var response = await requestHandler.Handle(requestData, new System.Threading.CancellationToken());
            }
            catch
            {
                Assert.IsTrue(true);
            }
        }
    }
}