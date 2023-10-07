using UnityEngine;

namespace Core
{
    public static class ConvertToSpriteExtension
    {
        public static Sprite ConvertToSprite(this Texture2D texture)
        {
            return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        }
    }
}