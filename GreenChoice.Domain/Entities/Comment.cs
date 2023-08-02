using GreenChoice.Domain.Core;

namespace GreenChoice.Domain.Entities;

public class Comment : EntityBase
{
    public int ProductId{ get; set; }
    public int UserId{ get; set; }
    public string Text{ get; set; }
    public float CommentScore{ get; set; }
}
