using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.DataModels;
using Models.UtilityModels;

namespace DataAccess.Configurations.Entities
{
    public class CategorySeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category
                {
                    Id = 1000,
                    Name = SD.Academics
                },
                new Category
                {
                    Id = 2000,
                    Name = SD.Technology
                },
                new Category
                {
                    Id = 3000,
                    Name = SD.News
                },
                new Category
                {
                    Id = 4000,
                    Name = SD.Business
                },
                new Category
                {
                    Id = 5000,
                    Name = SD.Entertainment
                },
                new Category
                {
                    Id = 6000,
                    Name = SD.Culture
                },
                new Category
                {
                    Id = 7000,
                    Name = SD.Nature
                });
        }
    }
}
