using Fag.Content.Items;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace Fag.Content.NPCs
{
    [Autoload]
    public class Chovey : ModNPC
    {
        private const string ShopName = "chovey's mart";
        
        // death message
        public override LocalizedText DeathMessage => this.GetLocalization("DeathMessage");

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 25;
            AnimationType = NPCID.Guide;
            NPCID.Sets.ExtraFramesCount[Type] = 9;
            NPCID.Sets.AttackFrameCount[Type] = 4; 
            NPCID.Sets.DangerDetectRange[Type] = 700;
            NPCID.Sets.AttackType[Type] = 0;
            NPCID.Sets.AttackTime[Type] = 90;
            NPCID.Sets.AttackAverageChance[Type] = 30;
        }

        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 18;
            NPC.height = 18;
            NPC.aiStyle = 7;
            NPC.defense = 15;
            NPC.lifeMax = 250;
            NPC.knockBackResist = 0.5f;
        }

        public override string GetChat()
        {
            WeightedRandom<string> chat = new WeightedRandom<string>();
            
            chat.Add("i am chovey");
            chat.Add("gtfo");

            return chat;
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Language.GetTextValue("LegacyInterface.28");
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shopName)
        {
            if (firstButton)
            {
                shopName = ShopName;
            }
        }

        public override void AddShops()
        {
            new NPCShop(Type, ShopName)
                .Add(ItemID.Wood)
                .Add<Chord>()
                .Register();
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Chord>()));
        }
        
    }
}