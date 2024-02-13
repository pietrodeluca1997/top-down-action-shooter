using System;
using UnityEngine;

[Serializable]
public class InventoryItem
{
    [SerializeField]
    private ItemData itemData;

    [SerializeField]
    private int stackSize;

    public InventoryItem(ItemData itemData, int stackSize)
    {
        this.itemData = itemData;
        this.stackSize = stackSize;
    }
}