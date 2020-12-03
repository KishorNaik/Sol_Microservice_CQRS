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
    public class GetMovieDataByReleaseDateUnitTest
    {
        private readonly Mock<IGetMovieDataByReleaseDateRepository> getMovieDataByReleaseDateRepositoryMock = null;
        private readonly Mock<IMapper> mapperMock = null;

        private IRequestHandler<GetMovieDataByReleaseDateQuery, object> requestHandler = null;

        public GetMovieDataByReleaseDateUnitTest()
        {
            getMovieDataByReleaseDateRepositoryMock = new Mock<IGetMovieDataByReleaseDateRepository>();
            mapperMock = new Mock<IMapper>();

            requestHandler = new GetMovieDataByReleaseDateQueryHandler(getMovieDataByReleaseDateRepositoryMock.Object, mapperMock.Object);
        }

        private GetMovieDataByReleaseDateQuery GetQueryRequestData()
        {
            return new GetMovieDataByReleaseDateQuery()
            {
                ReleaseStartDate = new DateTime(1995, 1, 1),
                ReleaseEndDate = new DateTime(2020, 1, 1)
            };
        }

        [TestMethod]
        public async Task Movie_Success()
        {
            var requestData = this.GetQueryRequestData();

            getMovieDataByReleaseDateRepositoryMock
                .Setup((r) => r.GetMovieDataByReleaseDateAsync(It.IsAny<MovieModel>()))
                .ReturnsAsync(new List<MovieModel>() { new MovieModel() { Title = "X-Men" } });

            var response = await requestHandler.Handle(requestData, new System.Threading.CancellationToken());

            Assert.IsTrue(response is List<MovieModel>);
        }

        [TestMethod]
        public async Task Movie_Error_OnNull()
        {
            var requestData = this.GetQueryRequestData();

            getMovieDataByReleaseDateRepositoryMock
                .Setup((r) => r.GetMovieDataByReleaseDateAsync(It.IsAny<MovieModel>()))
                .ReturnsAsync((IReadOnlyList<MovieModel>)null);

            var response = await requestHandler.Handle(requestData, new System.Threading.CancellationToken());

            Assert.IsTrue(response is ErrorModel);
        }

        [TestMethod]
        public async Task Movie_Error_OnZeroCount()
        {
            var requestData = this.GetQueryRequestData();

            getMovieDataByReleaseDateRepositoryMock
                .Setup((r) => r.GetMovieDataByReleaseDateAsync(It.IsAny<MovieModel>()))
                .ReturnsAsync(new List<MovieModel>());

            var response = await requestHandler.Handle(requestData, new System.Threading.CancellationToken());

            Assert.IsTrue(response is ErrorModel);
        }

        [TestMethod]
        public async Task Movie_Error_OnException()
        {
            var requestData = this.GetQueryRequestData();

            getMovieDataByReleaseDateRepositoryMock
                .Setup((r) => r.GetMovieDataByReleaseDateAsync(It.IsAny<MovieModel>()))
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