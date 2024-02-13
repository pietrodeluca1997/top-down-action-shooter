using UnityEngine;

public class EquipmentComponent : MonoBehaviour
{
    [SerializeField]
    private Transform pistolWeaponSocket, weaponHandSocket;

    private WeaponBase firstWeaponSlot;

    public void EquipWeaponOnFirstSlot(WeaponBase weapon)
    {
        //TODO: Testing purposes

        firstWeaponSlot = Instantiate(weapon, pistolWeaponSocket.position, pistolWeaponSocket.rotation);

        PutOnSocket(pistolWeaponSocket, firstWeaponSlot);
    }

    public void EquipWeapon()
    {
        //TODO: Testing purposes
        if (firstWeaponSlot != null)
        {
            PutOnSocket(weaponHandSocket, firstWeaponSlot);
        }
        else
        {
            Debug.Log("Unable to find a weapon to equip, you must pick one...");
        }
    }   

    private void PutOnSocket(Transform socket, WeaponBase weapon)
    {
        weapon.transform.parent = socket;
        weapon.transform.position = socket.position;

        weapon.transform.localScale = Vector3.one;
    }
}