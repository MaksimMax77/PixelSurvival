using System;
using Code.Inventory.Items;

namespace Code.Inventory
{
    [Serializable]
    public struct Cell
    {
        public ItemData itemData;
        public bool seted;
    }
}
