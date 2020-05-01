namespace JuniorForever.Api.Dtos
{
    public class RatingDto
    {
        public string Content { get; set; }
        public int Stars { get; set; }
        public AuthorDto Author { get; set; }
    }
}
