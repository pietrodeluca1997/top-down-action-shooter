using UnityEngine;

[RequireComponent(typeof(LocomotionComponentOnFoot))]
[RequireComponent(typeof(InteractionComponent))]
[RequireComponent(typeof(EquipmentComponent))]
[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(PlayerCharacter))]
public class PlayerComponentCommunicationProxy : MonoBehaviour
{
    /// <summary>
    /// The locomotion component controlling movement on foot.
    /// </summary>
    public LocomotionComponentOnFoot LocomotionComponentOnFoot { get; private set; }

    /// <summary>
    /// The interaction component handling interactions with objects.
    /// </summary>
    public InteractionComponent InteractionComponent { get; private set; }

    /// <summary>
    /// The equipment component handling character equipment.
    /// </summary>
    public EquipmentComponent EquipmentComponent { get; private set; }

    /// <summary>
    /// The player controller for subscribe components on events.
    /// </summary>
    public PlayerController PlayerController { get; private set; }

    /// <summary>
    /// The player character.
    /// </summary>
    public PlayerCharacter PlayerCharacter { get; private set; }


    private void Awake()
    {
        InteractionComponent = GetComponent<InteractionComponent>();
        EquipmentComponent = GetComponent<EquipmentComponent>();
        PlayerCharacter = GetComponent<PlayerCharacter>();
        PlayerController = GetComponent<PlayerController>();

        PlayerController.OnEAction += OnInteractionAction;
        PlayerController.OnOneKeyAction += OnActionBarAction;
    }

    public void OnInteractionAction(EInputActionEventType actionEventType)
    {
        if (InteractionComponent.TryGetNearestObject(out InteractableObject nearestInteractableObject))
        {
            nearestInteractableObject.Interact(PlayerCharacter);
        }
    }

    public void OnActionBarAction(EInputActionEventType actionEventType, int slotIndex)
    {
        //TODO: Testing purposes
        EquipmentComponent.EquipWeapon();
    }
}

