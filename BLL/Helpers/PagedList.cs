

namespace BLL.Helpers
{
    public class PagedList<TEntity> : List<TEntity>
    {
        public MetaData MetaData { get; set; }
        public PagedList(List<TEntity> items, int count, int pageNumber, int pageSize)
        {
            MetaData = new MetaData
            {
                TotalCount = count,
                PageSize = pageSize,
                CurrentPage = pageNumber,
                TotalPages = (int)Math.Ceiling(count / (double)pageSize)
            };
            AddRange(items);
        }
        public static PagedList<TEntity> ToPagedList(IEnumerable<TEntity> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source
              .Skip((pageNumber - 1) * pageSize)
              .Take(pageSize).ToList();
            return new PagedList<TEntity>(items, count, pageNumber, pageSize);
        }
    }
}
