using UnityEngine;

public class EquipmentComponent : MonoBehaviour
{
    private WeaponBase firstWeaponSlot;

    public void EquipWeaponOnFirstSlot(WeaponBase weapon)
    {
        Debug.Log($"Equiping weapon: {weapon.name}");
        firstWeaponSlot = weapon;
    }
}