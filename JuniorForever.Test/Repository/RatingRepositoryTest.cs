using JuniorForever.Repository;
using JuniorForever.Repository.Data;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace JuniorForever.Test.Repository
{
    public class RatingRepositoryTest
    {
        private readonly DataContext _dataContext = new DataContext(new DbContextOptions<DataContext>());

        [Fact]
        public async void ExistRatings()
        {
            RatingRepository ratingRepository = new RatingRepository(_dataContext);

            var result = await ratingRepository.GetAllRatings();

            Assert.True(result.Length > 0);
        }
    }
}