namespace AutoManager.Core.Requests;
public abstract class PagedRequest
{
    public int PageSize { get; set; } = Configuration.DefaultPageSize;
    public int PageNumber { get; set; } = Configuration.DefaultPageNumber;
}
