using UnityEngine;


[RequireComponent(typeof(InteractionComponent))]
[RequireComponent(typeof(EquipmentComponent))]
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

    protected virtual void Awake()
    {
        InteractionComponent = GetComponent<InteractionComponent>();
        EquipmentComponent = GetComponent<EquipmentComponent>();
    }
}