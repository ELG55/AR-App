using UnityEngine;

[CreateAssetMenu(fileName = "NewInventoryItem", menuName = "Inventory/New Inventory Item")]
public class InventoryItem : ScriptableObject
{
    public string itemName;
    public GameObject prefab;
    public Vector3 defaultRotation;
    public Vector3 defaultScale;
    public Vector3 inventoryViewScale;
}
