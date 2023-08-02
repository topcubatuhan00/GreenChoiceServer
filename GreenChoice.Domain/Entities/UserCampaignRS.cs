using GreenChoice.Domain.Core;

namespace GreenChoice.Domain.Entities;

public class UserCampaignRS : EntityBase
{
    public int UserId{ get; set; }
    public int CampaignId{ get; set; }
}
