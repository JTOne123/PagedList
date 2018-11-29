using System.Collections;
using System.Collections.Generic;

namespace AitroSoftware.PagedList
{
    /// <summary>
    /// Represents a subset of a collection of objects
    /// </summary>
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

    /// <summary>
    /// Represents a subset of a collection of objects
    /// </summary>
    /// <typeparam name="T">The type of objects the collection should contain.</typeparam>
    public interface IPagedList<out T> : IPagedList, IEnumerable<T>
    {
        /// <summary>
        /// Gets the number of elements contained on this page.
        /// </summary>
        int Count { get; }
    }
}
