namespace MoM.Blog.Dtos
{
    public partial class PagingDto
    {
        public int pageNo { get; set; }
        public int pageSize { get; set; }
    }

    public partial class PagingWithSortDto
    {
        public int pageNo { get; set; }
        public int pageSize { get; set; }
        public string sortColumn { get; set; }
        public bool sortByAscending { get; set; }
    }
}
