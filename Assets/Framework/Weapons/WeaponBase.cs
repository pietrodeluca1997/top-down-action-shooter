using UnityEngine;

public class WeaponBase : InteractableObject
{
    public override void Interact(CharacterBase interactor)
    {
        Debug.Log($"Equiping weapon {gameObject.name} on {interactor.name}...");

        interactor.EquipmentComponent.EquipWeaponOnFirstSlot(this);
    }
}
