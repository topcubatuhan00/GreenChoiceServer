namespace GreenChoice.Domain.Models.CampaignModels;

public class UpdateCampaignModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime BeginDate { get; set; }
    public DateTime EndDate { get; set; }
}
