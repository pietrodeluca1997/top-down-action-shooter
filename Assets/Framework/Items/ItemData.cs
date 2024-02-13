using UnityEngine;

[CreateAssetMenu(fileName = "New Item Data", menuName = "Data/Item")]
public class ItemData : ScriptableObject
{
    [SerializeField]
    protected string itemName;

    [SerializeField]
    protected EItemType itemType;
}