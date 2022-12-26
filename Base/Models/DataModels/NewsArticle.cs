namespace Models.DataModels
{
    public class NewsArticle
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<MediaObject> MediaObjects { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public int ArticleCount { get; set; }
    }
}