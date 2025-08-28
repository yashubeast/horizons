using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace Fag.Content.Npcs
{
    public abstract class NpcBase : ModNPC
    {

        public override LocalizedText DeathMessage => this.GetLocalization("DeathMessage");

        // set defaults ################################################################################################
        protected virtual int DefaultLife => 100;                                                               // input
        protected virtual int DefaultDefense => 10;                                                             // input

        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 18;
            NPC.height = 18;
            NPC.defense = DefaultDefense;
            NPC.lifeMax = DefaultLife;
            NPC.knockBackResist = 0.5f;
            NPC.aiStyle = 7;
            AnimationType = NPCID.Guide;
        }

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 25;
            NPCID.Sets.AttackType[Type] = 3;
            NPCID.Sets.AttackTime[Type] = 90;
            NPCID.Sets.DangerDetectRange[Type] = 700;
            NPCID.Sets.AttackAverageChance[Type] = 30;
        }

        // chat lines ##################################################################################################
        protected abstract string[] ChatLines { get; }                                                          // input
        public override string GetChat()
        {
            var chat = new WeightedRandom<string>();
            foreach (var line in ChatLines)
                chat.Add(line);
            return chat;
        }

        // shop stuff ##################################################################################################
        protected virtual string ShopName => GetType().Name;                                                    // input
        protected virtual string ShopBtnName => "Shop";                                                         // input

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = ShopBtnName;
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shopName)
        {
            if (firstButton) shopName = ShopName;
        }

        protected abstract (int itemType, int stack)[] ShopItems { get; }                                       // input
        public override void AddShops()
        {
            var shop = new NPCShop(Type, ShopName);

            foreach (var (itemType, stack) in ShopItems)
            {
                var item = new Item();
                item.SetDefaults(itemType);
                item.stack = stack;
                shop.Add(item);
            }

            shop.Register();
        }

        // lootdrops ###################################################################################################
        protected abstract (int itemType, int chanceDenominator)[] LootTable { get; }                           // input
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            foreach (var (itemType, chance) in LootTable)
            {
                npcLoot.Add(ItemDropRule.Common(itemType, chance));
            }
        }
    }
}