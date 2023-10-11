using System.Collections.Generic;
using Code.Core.Serialization;

namespace Code.Inventory.Data
{
    public class InventoryDataSerializer
    {
        private const string FileName = "InventoryData";

        public void SaveCells(List<Cell> cells)
        {
            JsonSerializer.Serialize(cells, FileName);
        }
        public List<Cell> LoadCells()
        {
            return JsonSerializer.Deserialize<List<Cell>>(FileName);
        }
   }
}
