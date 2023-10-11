using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewInventory", menuName = "Inventory/New Inventory")]
public class Inventory : ScriptableObject
{
    public List<InventoryItem> inventoryItems;
}
