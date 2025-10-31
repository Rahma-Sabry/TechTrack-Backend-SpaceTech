using AutoMapper;

namespace TechPathNavigator.Extensions
{
    /// <summary>
    /// Extension methods for AutoMapper operations
    /// Simplifies mapping operations throughout the application
    /// </summary>
    public static class MappingExtensions
    {
        /// <summary>
        /// Maps a collection of source objects to destination type
        /// </summary>
        public static List<TDestination> MapList<TSource, TDestination>(
            this IMapper mapper,
            IEnumerable<TSource> source)
        {
            return mapper.Map<List<TDestination>>(source);
        }

        /// <summary>
        /// Maps source to destination with null checking
        /// </summary>
        public static TDestination? MapOrDefault<TSource, TDestination>(
            this IMapper mapper,
            TSource? source) where TDestination : class
        {
            return source == null ? null : mapper.Map<TDestination>(source);
        }

        /// <summary>
        /// Updates an existing destination object from source
        /// </summary>
        public static TDestination MapTo<TSource, TDestination>(
            this IMapper mapper,
            TSource source,
            TDestination destination)
        {
            return mapper.Map(source, destination);
        }
    }
}
