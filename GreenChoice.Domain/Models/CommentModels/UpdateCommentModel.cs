namespace GreenChoice.Domain.Models.CommentModels;

public class UpdateCommentModel
{
    public int Id{ get; set; }
    public int ProductId { get; set; }
    public int UserId { get; set; }
    public string Text { get; set; }
    public float CommentScore { get; set; }
}
