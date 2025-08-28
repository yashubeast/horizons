using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fag.Content.GlobalNpcs
{
    public class KingSlime : GlobalNPC
    {
        public override bool InstancePerEntity => true;
        private static Asset<Texture2D> _newTexture;

        public override void Load()
        {
            if (!Main.dedServ)
            {
                _newTexture = ModContent.Request<Texture2D>("Fag/Content/GlobalNpcs/KingSlime");
            }
        }

        public override bool PreDraw(NPC npc, SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            if (npc.type != NPCID.KingSlime) return true;
            var tex = _newTexture.Value;
            var source = npc.frame;
            var origin = source.Size() / 2f;
            spriteBatch.Draw(tex, npc.Center - screenPos, source, drawColor, npc.rotation, origin, npc.scale,
                SpriteEffects.None, 0f);
            return false; // skip default draw

        }
    }
}
