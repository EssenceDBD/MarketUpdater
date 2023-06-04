namespace MarketUpdater;

internal class BloodwebGenerator
{
    private static List<object> BloodwebList = new List<object>();

    internal static Dictionary<string, object> Make_Bloodweb()
    {
        BloodwebList.AddRange(CUE4Parse.Ids.ItemIds);
        BloodwebList.AddRange(CUE4Parse.Ids.AddonIds);
        BloodwebList.AddRange(CUE4Parse.Ids.OfferingIds);

        var pathData = new List<string>
        {
            "0_101",
            "0_102",
            "0_103",
            "0_104",
            "0_105",
            "0_106",
            "101_102",
            "102_103",
            "103_104",
            "104_105",
            "105_106",
            "106_101",
            "101_201",
            "101_202",
            "102_203",
            "102_204",
            "103_205",
            "103_206",
            "104_207",
            "104_208",
            "105_209",
            "105_210",
            "106_211",
            "106_212",
            "201_202",
            "202_203",
            "203_204",
            "204_205",
            "205_206",
            "206_207",
            "207_208",
            "208_209",
            "209_210",
            "210_211",
            "211_212",
            "212_201",
            "301_302",
            "302_303",
            "303_304",
            "304_305",
            "305_306",
            "306_307",
            "307_308",
            "308_309",
            "309_310",
            "310_311",
            "311_312",
            "312_301"
        };

        var ringData = new List<Dictionary<string, object>>()
        {
            new Dictionary<string, object>()
            {
                {
                    "nodeData", new List<Dictionary<string, object>>()
                    {
                        new Dictionary<string, object>()
                        {
                            { "nodeId", 0 },
                            { "state", "Available" }
                        }
                    }
                }
            },
            new Dictionary<string, object>()
            {
                {
                    "nodeData", new List<Dictionary<string, object>>()
                    {
                        new Dictionary<string, object>()
                        {
                            { "contentId", BloodwebList[new Random().Next(BloodwebList.Count)] },
                            { "nodeId", 101 },
                            { "state", "Available" }
                        },
                        new Dictionary<string, object>()
                        {
                            { "contentId", BloodwebList[new Random().Next(BloodwebList.Count)] },
                            { "nodeId", 102 },
                            { "state", "Available" }
                        },
                        new Dictionary<string, object>()
                        {
                            { "contentId", BloodwebList[new Random().Next(BloodwebList.Count)] },
                            { "nodeId", 103 },
                            { "state", "Available" }
                        },
                        new Dictionary<string, object>()
                        {
                            { "contentId", BloodwebList[new Random().Next(BloodwebList.Count)] },
                            { "nodeId", 104 },
                            { "state", "Available" }
                        },
                        new Dictionary<string, object>()
                        {
                            { "contentId", BloodwebList[new Random().Next(BloodwebList.Count)] },
                            { "nodeId", 105 },
                            { "state", "Available" }
                        },
                        new Dictionary<string, object>()
                        {
                            { "contentId", BloodwebList[new Random().Next(BloodwebList.Count)] },
                            { "nodeId", 106 },
                            { "state", "Available" }
                        },
                    }
                }
            },
            new Dictionary<string, object>()
            {
                {
                    "nodeData", new List<Dictionary<string, object>>()
                    {
                        new Dictionary<string, object>()
                        {
                            { "contentId", BloodwebList[new Random().Next(BloodwebList.Count)] },
                            { "nodeId", 201 },
                            { "state", "Available" }
                        },
                        new Dictionary<string, object>()
                        {
                            { "contentId", BloodwebList[new Random().Next(BloodwebList.Count)] },
                            { "nodeId", 202 },
                            { "state", "Available" }
                        },
                        new Dictionary<string, object>()
                        {
                            { "contentId", BloodwebList[new Random().Next(BloodwebList.Count)] },
                            { "nodeId", 203 },
                            { "state", "Available" }
                        },
                        new Dictionary<string, object>()
                        {
                            { "contentId", BloodwebList[new Random().Next(BloodwebList.Count)] },
                            { "nodeId", 204 },
                            { "state", "Available" }
                        },
                        new Dictionary<string, object>()
                        {
                            { "contentId", BloodwebList[new Random().Next(BloodwebList.Count)] },
                            { "nodeId", 205 },
                            { "state", "Available" }
                        },
                        new Dictionary<string, object>()
                        {
                            { "contentId", BloodwebList[new Random().Next(BloodwebList.Count)] },
                            { "nodeId", 206 },
                            { "state", "Available" }
                        },
                        new Dictionary<string, object>()
                        {
                            { "contentId", BloodwebList[new Random().Next(BloodwebList.Count)] },
                            { "nodeId", 207 },
                            { "state", "Available" }
                        },
                        new Dictionary<string, object>()
                        {
                            { "contentId", BloodwebList[new Random().Next(BloodwebList.Count)] },
                            { "nodeId", 208 },
                            { "state", "Available" }
                        },
                        new Dictionary<string, object>()
                        {
                            { "contentId", BloodwebList[new Random().Next(BloodwebList.Count)] },
                            { "nodeId", 209 },
                            { "state", "Available" }
                        },
                        new Dictionary<string, object>()
                        {
                            { "contentId", BloodwebList[new Random().Next(BloodwebList.Count)] },
                            { "nodeId", 210 },
                            { "state", "Available" }
                        },
                        new Dictionary<string, object>()
                        {
                            { "contentId", BloodwebList[new Random().Next(BloodwebList.Count)] },
                            { "nodeId", 211 },
                            { "state", "Available" }
                        },
                        new Dictionary<string, object>()
                        {
                            { "contentId", BloodwebList[new Random().Next(BloodwebList.Count)] },
                            { "nodeId", 212 },
                            { "state", "Available" }
                        },
                    }
                }
            },
            new Dictionary<string, object>()
            {
                {
                    "nodeData", new List<Dictionary<string, object>>()
                    {
                        new Dictionary<string, object>()
                        {
                            { "contentId", BloodwebList[new Random().Next(BloodwebList.Count)] },
                            { "nodeId", 301 },
                            { "state", "Available" }
                        },
                        new Dictionary<string, object>()
                        {
                            { "contentId", BloodwebList[new Random().Next(BloodwebList.Count)] },
                            { "nodeId", 302 },
                            { "state", "Available" }
                        },
                        new Dictionary<string, object>()
                        {
                            { "contentId", BloodwebList[new Random().Next(BloodwebList.Count)] },
                            { "nodeId", 303 },
                            { "state", "Available" }
                        },
                        new Dictionary<string, object>()
                        {
                            { "contentId", BloodwebList[new Random().Next(BloodwebList.Count)] },
                            { "nodeId", 304 },
                            { "state", "Available" }
                        },
                        new Dictionary<string, object>()
                        {
                            { "contentId", BloodwebList[new Random().Next(BloodwebList.Count)] },
                            { "nodeId", 305 },
                            { "state", "Available" }
                        },
                        new Dictionary<string, object>()
                        {
                            { "contentId", BloodwebList[new Random().Next(BloodwebList.Count)] },
                            { "nodeId", 306 },
                            { "state", "Available" }
                        },
                        new Dictionary<string, object>()
                        {
                            { "contentId", BloodwebList[new Random().Next(BloodwebList.Count)] },
                            { "nodeId", 307 },
                            { "state", "Available" }
                        },
                        new Dictionary<string, object>()
                        {
                            { "contentId", BloodwebList[new Random().Next(BloodwebList.Count)] },
                            { "nodeId", 308 },
                            { "state", "Available" }
                        },
                        new Dictionary<string, object>()
                        {
                            { "contentId", BloodwebList[new Random().Next(BloodwebList.Count)] },
                            { "nodeId", 309 },
                            { "state", "Available" }
                        },
                        new Dictionary<string, object>()
                        {
                            { "contentId", BloodwebList[new Random().Next(BloodwebList.Count)] },
                            { "nodeId", 310 },
                            { "state", "Available" }
                        },
                        new Dictionary<string, object>()
                        {
                            { "contentId", BloodwebList[new Random().Next(BloodwebList.Count)] },
                            { "nodeId", 311 },
                            { "state", "Available" }
                        },
                        new Dictionary<string, object>()
                        {
                            { "contentId", BloodwebList[new Random().Next(BloodwebList.Count)] },
                            { "nodeId", 312 },
                            { "state", "Available" }
                        },
                        new Dictionary<string, object>()
                        {
                            { "contentId", BloodwebList[new Random().Next(BloodwebList.Count)] },
                            { "nodeId", 313 },
                            { "state", "Available" }
                        },
                        new Dictionary<string, object>()
                        {
                            { "contentId", BloodwebList[new Random().Next(BloodwebList.Count)] },
                            { "nodeId", 314 },
                            { "state", "Available" }
                        },
                        new Dictionary<string, object>()
                        {
                            { "contentId", BloodwebList[new Random().Next(BloodwebList.Count)] },
                            { "nodeId", 315 },
                            { "state", "Available" }
                        },
                        new Dictionary<string, object>()
                        {
                            { "contentId", BloodwebList[new Random().Next(BloodwebList.Count)] },
                            { "nodeId", 316 },
                            { "state", "Available" }
                        },
                        new Dictionary<string, object>()
                        {
                            { "contentId", BloodwebList[new Random().Next(BloodwebList.Count)] },
                            { "nodeId", 317 },
                            { "state", "Available" }
                        },
                        new Dictionary<string, object>()
                        {
                            { "contentId", BloodwebList[new Random().Next(BloodwebList.Count)] },
                            { "nodeId", 318 },
                            { "state", "Available" }
                        },
                    }
                }
            },
            new Dictionary<string, object>()
            {
                {
                    "nodeData", new List<Dictionary<string, object>>()
                    {
                        new Dictionary<string, object>()
                        {
                            { "contentId", BloodwebList[new Random().Next(BloodwebList.Count)] },
                            { "nodeId", 401 },
                            { "state", "Available" }
                        },
                    }
                }
            }
        };

        var bloodWebData = new Dictionary<string, object>
        {
            { "paths", pathData },
            { "ringData", ringData }
        };

        return bloodWebData;
    }
}