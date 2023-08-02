namespace GreenChoice.Domain.Models.CommentModels;

public class CreateCommentModel
{
    public int ProductId { get; set; }
    public int UserId { get; set; }
    public string Text { get; set; }
    public float CommentScore { get; set; }
    public string CreatorName { get; set; }
}
