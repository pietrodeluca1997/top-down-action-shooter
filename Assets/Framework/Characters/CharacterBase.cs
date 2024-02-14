using UnityEngine;


[RequireComponent(typeof(InteractionComponent))]
[RequireComponent(typeof(InventoryComponent))]
[RequireComponent(typeof(EquipmentComponent))]
[RequireComponent(typeof(CombatComponent))]
public class CharacterBase : MonoBehaviour
{
    /// <summary>
    /// The interaction component handling interactions with objects.
    /// </summary>
    public InteractionComponent InteractionComponent { get; private set; }

    /// <summary>
    /// The equipment component handling character equipment.
    /// </summary>
    public EquipmentComponent EquipmentComponent { get; private set; }

    /// <summary>
    /// The inventory component.
    /// </summary>
    public InventoryComponent InventoryComponent { get; private set; }

    /// <summary>
    /// The combat component.
    /// </summary>
    public CombatComponent CombatComponent { get; private set; }

    protected virtual void Awake()
    {
        InteractionComponent = GetComponent<InteractionComponent>();
        EquipmentComponent = GetComponent<EquipmentComponent>();
        InventoryComponent = GetComponent<InventoryComponent>();
        CombatComponent = GetComponent<CombatComponent>();
    }
}