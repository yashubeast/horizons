using Fag.Content.Items;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fag.Content.Npcs
{
    [Autoload]
    public class Chovey : NpcBase
    {
        protected override string[] ChatLines =>
        [
            "i am king",
            "gtfo",
            "1",
            "ur",
            "ts gronk",
            "cumak",
            "erp"
        ];

        protected override (int itemType, int stack)[] ShopItems =>
        [
            (ItemID.Wood, 1),
            (ModContent.ItemType<Chord>(), 1)
        ];

        protected override (int itemType, int chanceDenominator)[] LootTable =>
        [
            (ModContent.ItemType<Chord>(), 5),
            (ItemID.Wood, 1)
        ];

    }
}
