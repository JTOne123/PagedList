using System.Linq;
using Xunit;

namespace AitroSoftware.PagedList.Tests
{
    public class PagedListProjectionFacts
    {
        [Fact]
        public void TotalPageIsPreserved()
        {
            var data = Enumerable.Range(1, 30);

            var pagedList = data.ToPagedList(1, 2);

            var projected = pagedList.ProjectTo(x => x * 2);

            Assert.Equal(pagedList.TotalPages, projected.TotalPages);
        }

        [Fact]
        public void TotalItemCountIsPreserved()
        {
            var data = Enumerable.Range(1, 30);

            var pagedList = data.ToPagedList(1, 2);

            var projected = pagedList.ProjectTo(x => x * 2);

            Assert.Equal(pagedList.TotalItemCount, projected.TotalItemCount);
        }

        [Fact]
        public void PageSizePreserved()
        {
            var data = Enumerable.Range(1, 30);

            var pagedList = data.ToPagedList(1, 2);

            var projected = pagedList.ProjectTo(x => x * 2);

            Assert.Equal(pagedList.PageSize, projected.PageSize);
        }

        [Fact]
        public void CountIsPreserved()
        {
            var data = Enumerable.Range(1, 30);

            var pagedList = data.ToPagedList(2, 20);

            var projected = pagedList.ProjectTo(x => x * 2);

            Assert.Equal(pagedList.Count, projected.Count);
        }

        [Fact]
        public void ProjectionIsApplied()
        {
            var data = Enumerable.Range(1, 30);

            var pagedList = data.ToPagedList(2, 20);

            var projected = pagedList.ProjectTo(x => x * 2);

            var expected = new[] { 42, 44, 46, 48, 50, 52, 54, 56, 58, 60 };

            Assert.Equal(projected, expected);
        }
    }
}
