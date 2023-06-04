using Newtonsoft.Json;

namespace MarketUpdater;

internal static class Market
{
    private static Dictionary<string, object> marketObj = new Dictionary<string, object>();
    private static Dictionary<string, object> data = new Dictionary<string, object>();
    private static List<object> inventory = new List<object>();

    internal static async Task Generate_Market(string market)
    {
        BuildJson();

        if (market != "dlconly")
        {
            AddInventoryItems(inventory, CUE4Parse.Ids.CosmeticIds, 1);
            AddInventoryItems(inventory, CUE4Parse.Ids.OutfitIds, 1);
        }
        
        AddInventoryItems(inventory, CUE4Parse.Ids.DlcIds, 1);
        
        if (market == "all")
        {
            AddInventoryItems(inventory, CUE4Parse.Ids.ItemIds, Extras.ItemAmount);
            AddInventoryItems(inventory, CUE4Parse.Ids.AddonIds, Extras.ItemAmount);
            AddInventoryItems(inventory, CUE4Parse.Ids.OfferingIds, Extras.ItemAmount);
        }
        
        if (market != "dlconly" && market != "notemp")
            AddInventoryItems(inventory, CUE4Parse.Ids.PerkIds, 3);

        if (!Directory.Exists("Files")) Directory.CreateDirectory("Files");
        var json = JsonConvert.SerializeObject(marketObj, Formatting.Indented);

        var fileNameDict = new Dictionary<string, string>
        {
            { "all", "Market.json" },
            { "dlconly", "MarketDlcOnly.json" },
            { "notemp", "MarketNoSavefile.json" },
            { "perks", "MarketWithPerks.json" }
        };

        if (fileNameDict.TryGetValue(market, out var fileName)) 
            await File.WriteAllTextAsync($"Files/{fileName}", json);
    }

    private static void BuildJson()
    {
        marketObj.Clear();
        data.Clear();
        inventory.Clear();

        marketObj.Add("code", 200);
        marketObj.Add("message", "OK");
        data.Add("playerId", "MarketUpdater");
        data.Add("updated", DateTime.Now.ToString("MM/dd/yyyy"));
        data.Add("comment", "Market created by MarketUpdater");
        data.Add("developer", "essence#0001");
        data.Add("inventory", inventory);
        marketObj.Add("data", data);
    }

    private static void AddInventoryItems(List<object> inventory, IEnumerable<object> items, int count)
    {
        inventory.AddRange(items.Select(item => new Dictionary<string, object>
        {
            { "lastUpdatedAt", (DateTimeOffset.Now).ToUnixTimeSeconds() },
            { "objectId", item },
            { "quantity", count }
        }));
    }
}