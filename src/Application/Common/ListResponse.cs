namespace AssetManager.Application.Common
{
    public class ListResponse<T>
    {
        public required List<T> Data { get; set; }
        public int? Limit { get; set; }
        public int Total { get; set; }
        public int? Offset { get; set; }
    }
}
