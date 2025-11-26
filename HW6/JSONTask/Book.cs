using System.Text.Json.Serialization;
namespace JSONTask;

public class Book
{
    [JsonIgnore]
    public int PublishingHouseId { get; set; }

    [JsonPropertyName("Title")]
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("Name")]
    public string Name => Title;

    public PublishingHouse PublishingHouse { get; set; } = new();
}
