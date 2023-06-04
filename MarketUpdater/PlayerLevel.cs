using Newtonsoft.Json;

namespace MarketUpdater;

internal static class PlayerLevel
{
    internal static async Task Generate_PlayerLevel()
    {
        var playerLevelObj = new Dictionary<string, object>
        {
            { "totalXp", 1337 },
            { "levelVersion", 1 },
            { "level", Extras.PlayerLevel },
            { "prestigeLevel", Extras.DevotionLevel },
            { "currentXp", 1337 },
            { "currentXpUpperBound", 1337 }
        };

        var json = JsonConvert.SerializeObject(playerLevelObj, Formatting.Indented);
        await File.WriteAllTextAsync("Files/PlayerLevel.json", json);
    }
}