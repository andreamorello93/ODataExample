using Microsoft.OData.ModelBuilder;

namespace ODataExample.Api.Extensions
{
    public static class EntityTypeConfigurationExtensions
    {
        public static StructuralTypeConfiguration<T> SetMaxTopAndPageSize<T>(this EntityTypeConfiguration<T> entityTypeConfiguration) where T : class
        {
            return entityTypeConfiguration.Page(500, 500);
        }
    }
}
