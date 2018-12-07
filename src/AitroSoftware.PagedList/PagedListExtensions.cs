using System;
using System.Collections.Generic;
using System.Linq;

namespace AitroSoftware.PagedList
{
    /// <summary>
    /// Container for extension methods designed for creating <see cref="IPagedList{T}"/> instances.
    /// </summary>
    public static class PagedListExtensions
    {
        /// <summary>
        /// Creates a subset of this collection of objects.
        /// </summary>
        /// <typeparam name="T">The type of object the collection should contain</typeparam>
        /// <param name="source">The source <see cref="IEnumerable{T}"/> to be divided into subsets.</param>
        /// <param name="pageIndex">The one based index of the page.</param>
        /// <param name="pageSize">The maximum number of items allowed on one page.</param>
        /// <returns>
        /// A subset of this <see cref="IEnumerable{T}"/>.
        /// </returns>
        public static IPagedList<T> ToPagedList<T>(this IEnumerable<T> source, int pageIndex, int pageSize)
        {
            return CreatePagedListInternal(source, pageIndex, pageSize);
        }

        private static IPagedList<T> CreatePagedListInternal<T>(IEnumerable<T> source, int pageIndex, int pageSize)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (pageIndex <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(pageIndex));
            }

            if (pageSize <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize));
            }

            int skipVal = pageSize * (pageIndex - 1);

            int totalItemCount = source.Count();

            IEnumerable<T> currentPage = source.Skip(skipVal).Take(pageSize);

            return new PagedList<T>(currentPage, pageIndex, pageSize, totalItemCount);
        }
    }
}
