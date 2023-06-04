using Newtonsoft.Json;

namespace MarketUpdater;

internal static class Extras
{
    internal static int PrestigeLevel { get; set; }
    internal static int ItemAmount { get; set; }
    internal static int PlayerLevel { get; set; }
    internal static int DevotionLevel { get; set; }

    private static int Padding(string output) => (Console.WindowWidth / 2) - (output.Length / 2);
    internal static void CenterText(string text) => Console.WriteLine("{0}{1}", new string(' ', Padding(text)), text);
    
    internal static List<Dictionary<string, object>> CharacterItems = new List<Dictionary<string, object>>();

    internal static async Task<string> SendRequestAsync(string url)
    {
        using var client = new HttpClient();
        var response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadAsStringAsync();
        return result;
    }

    internal static async Task MakeFile(List<object> list, string fileName)
    {
        const string directoryName = "IDs";
        if (!Directory.Exists(directoryName)) Directory.CreateDirectory(directoryName);
        
        var json = JsonConvert.SerializeObject(list, Formatting.Indented);
        await using (var writer = new StreamWriter($"{directoryName}/{fileName}"))
        {
            await writer.WriteAsync(json);
        }

        Console.WriteLine($"{fileName} generated");
    }

    internal static void Header()
    {
        CenterText("\"Two facts: boys make better girls and furries are superior to all\" - Essence");
        CenterText("MarketUpdater developed by essence#0001");
        Console.WriteLine(Environment.NewLine);
    }

    internal static void Get_Items()
    {
        Add_Items(CUE4Parse.Ids.ItemIds, ItemAmount);
        Add_Items(CUE4Parse.Ids.AddonIds, ItemAmount);
        Add_Items(CUE4Parse.Ids.OfferingIds, ItemAmount);
        Add_Items(CUE4Parse.Ids.PerkIds, 3);
    }

    private static void Add_Items(List<object> items, int count)
    {
        CharacterItems.AddRange(items.Select(item => new Dictionary<string, object>
        {
            { "itemId", item },
            { "quantity", count }
        }));
    }
}