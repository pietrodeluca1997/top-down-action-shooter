using UnityEngine;

public class EquipmentComponent : MonoBehaviour
{
    [SerializeField]
    private Transform pistolWeaponSocket;

    private WeaponBase firstWeaponSlot;

    public void EquipWeaponOnFirstSlot(WeaponBase weapon)
    {
        Debug.Log($"Equiping weapon: {weapon.name}");

        //TODO: Testing purposes

        firstWeaponSlot = Instantiate(weapon, pistolWeaponSocket.position, pistolWeaponSocket.rotation);

        firstWeaponSlot.transform.parent = pistolWeaponSocket;
        firstWeaponSlot.transform.position = pistolWeaponSocket.position;

        firstWeaponSlot.transform.localScale = Vector3.one;

        Destroy(weapon.gameObject);
    }
}