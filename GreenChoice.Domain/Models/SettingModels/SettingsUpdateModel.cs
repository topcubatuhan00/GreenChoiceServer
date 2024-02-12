namespace GreenChoice.Domain.Models.SettingModels;

public class SettingsUpdateModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Value { get; set; }
    public string UpdaterName { get; set; }
    public DateTime? UpdatedDate { get; set; } = DateTime.Now;
}
