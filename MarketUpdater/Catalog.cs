namespace MarketUpdater;

internal static class Catalog
{
    internal static string? AccessKey { get; set; }

    internal static async Task Get_Catalog()
    {
        Console.WriteLine(Environment.NewLine);
        Console.Write("Enter game version: ");
        var gameVersion = Console.ReadLine();
        Console.WriteLine("Generating catalog file...");

        using var client = new HttpClient();
        client.DefaultRequestHeaders.Add("User-Agent", "EssenceOwO");
        client.DefaultRequestHeaders.Add("Access-Key", AccessKey);
        client.DefaultRequestHeaders.Add("Game-Version", gameVersion[0..3]);

        var response = await client.GetAsync("https://essenceuwu.uk/api/v1/DeadByDaylight/CDN/catalog");
        var responseContent = await response.Content.ReadAsStringAsync();

        if (responseContent.Contains("access key") || responseContent.Contains("game version")) throw new Exception(
            "Issue with obtaining catalog file, make sure your game is updated for the latest version and that you inputted the version correctly.");

        await File.WriteAllTextAsync("Files/Catalog.json", responseContent);
    }
}