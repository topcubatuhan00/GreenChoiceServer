namespace GreenChoice.Domain.Dtos;

public class CommentReponseDto
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int UserId { get; set; }
    public string Text { get; set; }
    public string UserName { get; set; }
    public string ProductName { get; set; }
    public float CommentScore { get; set; }
    public string UserPhotoName { get; set; }
}
