using System.Linq;
using Xunit;

namespace AitroSoftware.PagedList.Tests
{
    public class PagedListFacts
    {
        [Fact]
        public void TotalItemCountIsPreserved()
        {
            var data = Enumerable.Range(1, 200);

            var pagedList = data.ToPagedList(2, 10);

            Assert.Equal(200, pagedList.TotalItemCount);
        }

        [Fact]
        public void PageSizeIsPreserved()
        {
            var data = Enumerable.Range(1, 50);

            var pagedList = data.ToPagedList(3, 10);

            Assert.Equal(10, pagedList.PageSize);
        }

        [Fact]
        public void EmptyListShouldHaveZeroPages()
        {
            var data = Enumerable.Empty<int>();

            var pagedList = data.ToPagedList(1, 10);

            Assert.Equal(0, pagedList.Count);
        }

        [Fact]
        public void OutOfRangePageShouldShowZeroItems()
        {
            var data = Enumerable.Range(1, 20);

            var pagedList = data.ToPagedList(1000, 40);

            Assert.Equal(0, pagedList.Count);
        }

        [Theory]
        [InlineData(new[] { 1, 2, 3, 4 }, 1, 1)]
        [InlineData(new[] { 1, 2, 3, 4, 5 }, 2, 2)]
        public void PageIndexIsPreserved(int[] data, int pageNum, int expectedPageNumber)
        {
            var pagedList = data.ToPagedList(pageNum, 1);

            Assert.Equal(expectedPageNumber, pagedList.PageIndex);
        }

        [Theory]
        [InlineData(new[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 3, 3)]
        [InlineData(new[] { 1, 2, 3, 4 }, 1, 4)]
        [InlineData(new[] { 1, 2, 3, 4, 5, 6 }, 2, 3)]
        [InlineData(new[] { 1, 2, 3, 4, 5, 6, 7 }, 7, 1)]
        public void TotalPagesIsCorrect(int[] data, int pageSize, int expectedNumberOfPages)
        {
            var pagedList = data.ToPagedList(1, pageSize);

            Assert.Equal(expectedNumberOfPages, pagedList.TotalPages);
        }
    }
}
