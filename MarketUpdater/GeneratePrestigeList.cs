using Newtonsoft.Json;

namespace MarketUpdater
{
    internal class GeneratePrestigeList
    {
        internal static async Task GenerateList()
        {
            var characters = new List<Dictionary<string, object>>();
            var items = new List<Dictionary<string, object>>();
            var addons = new List<Dictionary<string, object>>();
            var offerings = new List<Dictionary<string, object>>();

            const string directoryName = "Other";
            
            if (!Directory.Exists(directoryName)) Directory.CreateDirectory(directoryName);

            characters.AddRange(CUE4Parse.Ids.DlcIds.Select(character => new Dictionary<string, object>
            {
                { "characterName", character },
                { "prestigeLevel", "10" },
                { "bloodwebLevel", "10" }
            }));

            var characterJson = JsonConvert.SerializeObject(characters, Formatting.Indented);
            await File.WriteAllTextAsync($"{directoryName}/CustomCharacterData.json", characterJson);

            items.AddRange(CUE4Parse.Ids.ItemIds.Select(item => new Dictionary<string, object>
            {
                { "itemName", item },
                { "quantity", "100" }
            }));

            var itemJson = JsonConvert.SerializeObject(items, Formatting.Indented);
            await File.WriteAllTextAsync($"{directoryName}/CustomItemAmount.json", itemJson);

            addons.AddRange(CUE4Parse.Ids.AddonIds.Select(item => new Dictionary<string, object>
            {
                { "addonName", item },
                { "quantity", "100" }
            }));

            var addonJson = JsonConvert.SerializeObject(addons, Formatting.Indented);
            await File.WriteAllTextAsync($"{directoryName}/CustomAddonAmount.json", addonJson);

            offerings.AddRange(CUE4Parse.Ids.OfferingIds.Select(item => new Dictionary<string, object>
            {
                { "offeringName", item },
                { "quantity", "100" }
            }));

            var offeringJson = JsonConvert.SerializeObject(offerings, Formatting.Indented);
            await File.WriteAllTextAsync($"{directoryName}/CustomOfferingAmount.json", offeringJson);
        }
    }
}
