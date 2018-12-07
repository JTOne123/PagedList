using System;
using System.Linq;

namespace AitroSoftware.PagedList
{
    /// <summary>
    /// Container for extension methods designed to project a paged list of one type into another.
    /// </summary>
    public static class PagedListProjectionExtensions
    {
        /// <summary>
        /// Converts a paged list into a paged list of a different type.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <typeparam name="TDest">The type of the value returned by selector.</typeparam>
        /// <param name="source">The source paged list.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>
        /// A new paged list of <typeparamref name="TDest"/> whose elements are the result
        /// of invoking the transform function on each element of the source.
        /// The page count, size, total item count, and total pages are preserved
        /// </returns>
        public static IPagedList<TDest> ProjectTo<TSource, TDest>(this IPagedList<TSource> source, Func<TSource, TDest> selector)
        {
            return new PagedList<TDest>(
                source.Select(selector),
                source.PageIndex,
                source.PageSize,
                source.TotalItemCount);
        }
    }
}
