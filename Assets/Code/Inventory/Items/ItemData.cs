using System;
using Code.Core.Serialization;
using UnityEngine;

namespace Code.Inventory.Items
{
    [Serializable]
    public class ItemData
    {
        public SpriteData spriteData;
        public int amount;

        public void SetSpriteData(Sprite sprite)
        {
            spriteData = SpriteData.FromSprite(sprite);
        }

        public Sprite GetSprite()
        {
           return SpriteData.ToSprite(spriteData);
        }
    }
}
