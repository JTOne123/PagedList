using System.Collections;
using System.Collections.Generic;

namespace AitroSoftware.PagedList
{
    public interface IPagedList : IEnumerable
    {
        /// <summary>
        /// Gets the total page count.
        /// </summary>
        int TotalPages { get; }

        /// <summary>
        /// Gets the total item count
        /// </summary>
        int TotalItemCount { get; }

        /// <summary>
        /// Gets the 1 based index of the current page
        /// </summary>
        int PageNumber { get; }

        /// <summary>
        /// Gets the maximum size of any individual page
        /// </summary>
        int PageSize { get; }
    }

    public interface IPagedList<out T> : IPagedList, IEnumerable<T>
    {
        /// <summary>
        /// Gets the number of elements contained on this page.
        /// </summary>
        int Count { get; }
    }
}
