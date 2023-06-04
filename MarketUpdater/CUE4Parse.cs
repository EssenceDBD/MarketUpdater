using System.Dynamic;
using System.Text.RegularExpressions;
using CUE4Parse.FileProvider;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MarketUpdater;

internal static class CUE4Parse
{
    private static DefaultFileProvider? Provider { get; set; }

    internal static void Initialize(string paksPath)
    {
        if (!Directory.Exists(paksPath))
        {
            Extras.CenterText("That directory was not found, re-launch and try again.");
            Console.ReadKey();
            Environment.Exit(0);
        }

        Provider = new DefaultFileProvider(paksPath, SearchOption.AllDirectories, true);
        Provider.Initialize();
        Provider.Mount();
    }

    internal static string GetAccessKey()
    {
        Provider.TrySaveAsset("DeadByDaylight/Config/DefaultGame.ini", out var data);
        var lastLine = "";
        
        using (var stream = new MemoryStream(data))
        using (var reader = new StreamReader(stream))
        {
            string line;
            
            while ((line = reader.ReadLine()) != null)
                if (line.Contains("_live"))
                    lastLine = line;
        }

        Console.WriteLine(lastLine);

        var match = Regex.Match(lastLine, @"Key=""(.*?)""");
        return match.Groups[1].Value;
    }

    internal static void Get_Files()
    {
        foreach (var keyValuePair in Provider.Files.Where(val => val.Value.Path.Contains("DeadByDaylight/Content/Data")))
        {
            switch (keyValuePair.Value.Name)
            {
                case "CustomizationItemDB.uasset":
                    FilePaths.CustomizationItemDb.Add(keyValuePair.Value.Path);
                    break;
                case "OutfitDB.uasset":
                    FilePaths.OutfitDb.Add(keyValuePair.Value.Path);
                    break;
                case "CharacterDescriptionDB.uasset":
                    FilePaths.CharacterDescriptionDb.Add(keyValuePair.Value.Path);
                    break;
                case "ItemDB.uasset":
                    FilePaths.ItemDb.Add(keyValuePair.Value.Path);
                    break;
                case "ItemAddonDB.uasset":
                    FilePaths.ItemAddonDb.Add(keyValuePair.Value.Path);
                    break;
                case "OfferingDB.uasset":
                    FilePaths.OfferingDb.Add(keyValuePair.Value.Path);
                    break;
                case "PerkDB.uasset":
                    FilePaths.PerkDb.Add(keyValuePair.Value.Path);
                    break;
            }
        }

        Add_Values(FilePaths.CustomizationItemDb, "CustomizationItemDB");
        Add_Values(FilePaths.OutfitDb, "OutfitDB");
        Add_Values(FilePaths.CharacterDescriptionDb, "CharacterDescriptionDB");
        Add_Values(FilePaths.ItemDb, "ItemDB");
        Add_Values(FilePaths.ItemAddonDb, "ItemAddonDB");
        Add_Values(FilePaths.OfferingDb, "OfferingDB");
        Add_Values(FilePaths.PerkDb, "PerkDB");
    }

    private static void Add_Values(List<string> list, string type)
    {
        foreach (var item in list)
        {
            var export = JsonConvert.DeserializeObject<dynamic>(
                JsonConvert.SerializeObject(Provider?.LoadObjectExports(item))) ?? new ExpandoObject();

            foreach (JProperty p in export[0]?.Rows ?? Enumerable.Empty<JProperty>())
            {
                var properties = p.Values<JObject>();
                foreach (var property in properties)
                {
                    switch (type)
                    {
                        case "CustomizationItemDB":
                            Ids.CosmeticIds.Add(property?["CustomizationId"]?.ToString() ?? string.Empty);
                            break;
                        case "OutfitDB":
                            Ids.OutfitIds.Add(property?["ID"]?.ToString() ?? string.Empty);
                            break;
                        case "CharacterDescriptionDB":
                            if (property?["CharacterId"]?.ToString() == "None") continue;
                            Ids.DlcIds.Add(property?["CharacterId"]?.ToString() ?? string.Empty);
                            break;
                        case "ItemDB":
                            if (property?["Type"]?.ToString() != "EInventoryItemType::Power" && property?["ItemId"]?.ToString() != "Item_LamentConfiguration")
                                Ids.ItemIds.Add(property?["ItemId"]?.ToString() ?? string.Empty);
                            break;
                        case "ItemAddonDB":
                            Ids.AddonIds.Add(property?["ItemId"]?.ToString() ?? string.Empty);
                            break;
                        case "OfferingDB":
                            Ids.OfferingIds.Add(property?["ItemId"]?.ToString() ?? string.Empty);
                            break;
                        case "PerkDB":
                            Ids.PerkIds.Add(property?["ItemId"]?.ToString() ?? string.Empty);
                            break;
                    }
                }
            }
        }
    }

    private static class FilePaths
    {
        internal static List<string> CustomizationItemDb = new();
        internal static List<string> OutfitDb = new();
        internal static List<string> CharacterDescriptionDb = new();
        internal static List<string> ItemDb = new();
        internal static List<string> ItemAddonDb = new();
        internal static List<string> OfferingDb = new();
        internal static List<string> PerkDb = new();
    }

    internal static class Ids
    {
        internal static List<object> CosmeticIds = new();
        internal static List<object> OutfitIds = new();
        internal static List<object> DlcIds = new();
        internal static List<object> ItemIds = new();
        internal static List<object> AddonIds = new();
        internal static List<object> OfferingIds = new();
        internal static List<object> PerkIds = new();
    }
}