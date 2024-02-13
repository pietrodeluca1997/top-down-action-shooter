using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Data", menuName = "Data/Weapon")]
public class WeaponData : ItemData
{
    public WeaponData()
    {
        itemType = EItemType.Weapon;
    }
}