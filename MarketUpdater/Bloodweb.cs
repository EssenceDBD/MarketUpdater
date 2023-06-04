using Newtonsoft.Json;

namespace MarketUpdater;

internal static class Bloodweb
{
    internal static async Task Generate_Bloodweb()
    {
        var bloodwebObj = new Dictionary<string, object>
        {
            { "bloodwebLevelChanged", false },
            { "updatedWallets", new List<object>() },
            { "characterName", "" },
            { "bloodWebLevel", 49 },
            { "prestigeLevel", Extras.PrestigeLevel },
            { "bloodWebData", BloodwebGenerator.Make_Bloodweb() },
            { "characterItems", Extras.CharacterItems },
            { "legacyPrestigeLevel", 3 }
        };

        var json = JsonConvert.SerializeObject(bloodwebObj, Formatting.Indented);
        await File.WriteAllTextAsync("Files/Bloodweb.json", json);
    }
}