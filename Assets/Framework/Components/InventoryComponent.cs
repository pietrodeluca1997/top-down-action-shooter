using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryComponent : AbstractSingleton<InventoryComponent>
{
    [SerializeField]
    private List<InventoryItem> inventoryItems;

    public void AddItem(InventoryItem item)
    {
        inventoryItems.Add(item);
    }
}