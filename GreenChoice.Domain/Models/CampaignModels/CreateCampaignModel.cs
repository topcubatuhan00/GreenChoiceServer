namespace GreenChoice.Domain.Models.CampaignModels;

public class CreateCampaignModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime BeginDate { get; set; }
    public DateTime EndDate { get; set; }
    public string CreatorName { get; set; }
}
