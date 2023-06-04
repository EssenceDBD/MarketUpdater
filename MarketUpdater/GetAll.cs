using Newtonsoft.Json;

namespace MarketUpdater;

internal static class GetAll
{
    private static Dictionary<string, List<Dictionary<string, object>>> getallObj =
        new Dictionary<string, List<Dictionary<string, object>>>();
    private static List<Dictionary<string, object>> characters = new List<Dictionary<string, object>>();

    internal static async Task Generate_Getall()
    {
        getallObj.Add("list", characters);
        
        characters.AddRange(CUE4Parse.Ids.DlcIds.Select(character => new Dictionary<string, object>
        {
            { "characterName", character },
            { "legacyPrestigeLevel", 3 },
            { "characterItems", Extras.CharacterItems },
            { "bloodWebLevel", 49 },
            { "bloodWebData", BloodwebGenerator.Make_Bloodweb() },
            { "prestigeLevel", Extras.PrestigeLevel }
        }));

        var json = JsonConvert.SerializeObject(getallObj, Formatting.Indented);
        await File.WriteAllTextAsync("Files/GetAll.json", json);
    }
}