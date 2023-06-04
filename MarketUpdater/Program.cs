using MarketUpdater;

try
{
    Console.Title = "MarketUpdater - EssenceOwO";

    Extras.Header();
    
    Console.Write("Paks Path: ");
    var paksPath = Console.ReadLine();
    MarketUpdater.CUE4Parse.Initialize(paksPath);
    Catalog.AccessKey = MarketUpdater.CUE4Parse.GetAccessKey();
    MarketUpdater.CUE4Parse.Get_Files();
    
    UserInput:

    Console.Write("What prestige do you want?: ");
    Extras.PrestigeLevel = Convert.ToInt32(Console.ReadLine());
    Console.Write("How many items do you want? (This number is multiplied by 2): ");
    Extras.ItemAmount = Convert.ToInt32(Console.ReadLine());
    Console.Write("What player level do you want?: ");
    Extras.PlayerLevel = Convert.ToInt32(Console.ReadLine());
    Console.Write("What devotion level do you want?: ");
    Extras.DevotionLevel = Convert.ToInt32(Console.ReadLine());

    Console.Clear();
    Extras.Header();
    Console.WriteLine(
        $"Prestige: {Extras.PrestigeLevel}\nItem Amount: {Extras.ItemAmount * 2}\nPlayer Level: {Extras.PlayerLevel}\nDevotion Level: {Extras.DevotionLevel}");
    Console.Write("Are you sure you want these values? (Y/n): ");

    switch (Console.ReadLine())
    {
        case "n":
        case "no":
            Console.Clear();
            Extras.Header();
            goto UserInput;
        default:
            /*
             * Generates files containing all the IDs in the game that can be used in your own projects
             * These files have no correlation with the intended purpose of this application which is to generate files for the use in Fiddler
             */
            await Extras.MakeFile(MarketUpdater.CUE4Parse.Ids.DlcIds, "Dlc.json");
            await Extras.MakeFile(MarketUpdater.CUE4Parse.Ids.AddonIds, "Addons.json");
            await Extras.MakeFile(MarketUpdater.CUE4Parse.Ids.OfferingIds, "Offerings.json");
            await Extras.MakeFile(MarketUpdater.CUE4Parse.Ids.ItemIds, "Items.json");
            await Extras.MakeFile(MarketUpdater.CUE4Parse.Ids.CosmeticIds, "Cosmetics.json");
            await Extras.MakeFile(MarketUpdater.CUE4Parse.Ids.OutfitIds, "Outfits.json");
            await Extras.MakeFile(MarketUpdater.CUE4Parse.Ids.PerkIds, "Perks.json");
            
            /*
             * Generates JSON files that can be incorporated within your own projects to allow people to customize the data to their liking
             * CustomAddonAmount.json contains a list of objects that contain the addon ID and the amount of addons
             * CustomItemAmount.json contains a list of objects that contain the item ID and the amount of items
             * CustomOfferingAmount.json contains a list of objects that contain the offering ID and the amount of offerings
             * CustomCharacterData.json contains a list of objects that contain the character, prestige level, and bloodweb level
             */
            await GeneratePrestigeList.GenerateList();
            
            /*
             * Generates the market files
             * 'All' contains items, addons, perks, offerings, cosmetics, outfits, and DLC
             * 'DLCOnly' contains only DLC
             * 'NoTemp' contains cosmetics, outfits, and DLC
             * 'Perks' contains cosmetics, outfits, DLC, and perks
             *
             * url to respond to: api/v1/inventories
             */
            await Market.Generate_Market("all");
            await Market.Generate_Market("dlconly");
            await Market.Generate_Market("notemp");
            await Market.Generate_Market("perks");
            Console.WriteLine("Market files generated");

            // Populates the CharacterItems that is used to generate the GetAll.json and Bloodweb.json files
            Extras.Get_Items();

            /*
             * Generates the GetAll.json file
             * 
             * url to respond to: dbd-character-data/get-all
             */
            await GetAll.Generate_Getall();
            Console.WriteLine("GetAll generated");

            /*
             * Generates the Bloodweb.json file
             * 
             * url to respond to: dbd-character-data/bloodweb
             */
            await Bloodweb.Generate_Bloodweb();
            Console.WriteLine("Bloodweb generated");

            // Generates the PlayerLevel.json file
            await PlayerLevel.Generate_PlayerLevel();
            Console.WriteLine("PlayerLevel generated");

            /*
             * Generates the Catalog.json file
             *
             * url to respond to: regex:^(?=.*\bbhvrdbd\b)(?=.*\bcatalog.json\b).*$
             */
            await Catalog.Get_Catalog();
            Console.WriteLine("Breakable sets + early releases catalog generated");
            break;
    }
    
    Console.WriteLine("\nPress any key to close...");
    Console.ReadKey();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    Console.ReadKey();
}