using UnityEngine;

public class WeaponBase : InteractableObject
{
    public override void Interact(CharacterBase interactor)
    {
        interactor.EquipmentComponent.EquipWeaponOnFirstSlot(this);
    }
}
