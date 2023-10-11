using UnityEngine;

namespace Code.Core.Serialization
{
    [System.Serializable]
    public class SpriteData 
    {
        public string name;
        public float xMin;
        public float xMax;
        public float yMin;
        public float yMax;
        public float pivotX;
        public float pivotY;
        public byte[] data;
    
        public static SpriteData FromSprite(Sprite sprite)
        {
            var result = new SpriteData
            {
                name = sprite.name,
                xMin = sprite.rect.xMin,
                xMax = sprite.rect.xMax,
                yMin = sprite.rect.yMin,
                yMax = sprite.rect.yMax,
                pivotX = sprite.pivot.x,
                pivotY = sprite.pivot.y,
                data = sprite.texture.EncodeToPNG()
            };

            return result;
        }

        public static Sprite ToSprite(SpriteData data)
        {
            var rect = new Rect
            {
                xMin = data.xMin,
                xMax = data.xMax,
                yMin = data.yMin,
                yMax = data.yMax
            };

            var pivot = new Vector2
            {
                x = data.pivotX,
                y = data.pivotY
            };

            var texture = new Texture2D(2, 2);
            texture.LoadImage(data.data);

            var result = Sprite.Create(texture, rect, pivot);
            result.name = data.name;

            return result;
        }
    }
}
