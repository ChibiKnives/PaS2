using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace PaS2.Helpers
{
    internal static partial class Helper
    {
        public static Vector2 GetMiddleBetween(this Vector2 start, Vector2 end) => (start + end) / 2;

        public static Vector2 TurnRight(this Vector2 vector) => new Vector2(-vector.Y, vector.X);

        public static Vector2 TurnLeft(this Vector2 vector) => new Vector2(vector.Y, -vector.X);

        public static Vector2 ToVector2(this Vector3 vector) => new Vector2(vector.X, vector.Y);

        public static Vector3 ToVector3(this Vector2 vector) => new Vector3(vector.X, vector.Y, 0f);

        public static Vector2 ToDrawPosition(this Vector2 vector) => vector - Main.screenPosition; 
        
        public static void DrawLine(this SpriteBatch spriteBatch, Vector2 start, Vector2 end, Color? color = null, int lineWidth = 1)
        {
            Vector2 dist = end - start;

            float rotation = dist.ToRotation();

            Color lineColor = color ?? Color.White;

            var destRect = new Rectangle((int)start.X, (int)start.Y, (int)dist.Length(), lineWidth);

            spriteBatch.Draw(Main.magicPixel, destRect, null, lineColor, rotation, default, SpriteEffects.None, 0);
        }
    }
}
