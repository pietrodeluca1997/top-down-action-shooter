using UnityEngine;

public class WeaponBase : InteractableObject
{
    [SerializeField]
    private WeaponData data;

    public override void Interact(CharacterBase interactor)
    {
        interactor.InventoryComponent.AddItem(new InventoryItem(data, 1));
        interactor.EquipmentComponent.EquipWeaponOnFirstSlot(this);
        Destroy(gameObject);
    }
}
