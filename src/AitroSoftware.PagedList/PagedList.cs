using System;
using System.Collections;
using System.Collections.Generic;

namespace AitroSoftware.PagedList
{
    /// <summary>
    /// Represents a subset of a collection of objects.
    /// </summary>
    /// <typeparam name="TElement">The type of object the collection should contain.</typeparam>
    public class PagedList<TElement> : IPagedList<TElement>
    {
        private readonly List<TElement> _subset = new List<TElement>();

        /// <summary>
        /// Initializes a new instance of the <see cref="PagedList{TElement}"/> class.
        /// </summary>
        /// <param name="currentPage">The enumerable of current page objects</param>
        /// <param name="pageIndex">The 1 based index of the current page</param>
        /// <param name="pageSize">The size of any individual page</param>
        /// <param name="totalCount">The total number of items in the superset</param>
        public PagedList(
            IEnumerable<TElement> currentPage,
            int pageIndex,
            int pageSize,
            int totalCount)
        {
            _subset.AddRange(currentPage);

            if (pageIndex < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(pageIndex), "Page cannot be less than 1");
            }

            if (pageSize < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize), "Page size cannot be less than 1");
            }

            TotalItemCount = totalCount;
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(TotalItemCount / (double)PageSize);
        }

        /// <inheritdoc />
        public int Count => _subset.Count;

        /// <inheritdoc />
        public int TotalPages { get; }

        /// <inheritdoc />
        public int TotalItemCount { get; }

        /// <inheritdoc />
        public int PageIndex { get; }

        /// <inheritdoc />
        public int PageSize { get; }

        /// <inheritdoc />
        public IEnumerator<TElement> GetEnumerator()
        {
            return _subset.GetEnumerator();
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
