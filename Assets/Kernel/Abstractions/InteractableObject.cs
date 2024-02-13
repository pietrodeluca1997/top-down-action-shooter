using UnityEngine;

public abstract class InteractableObject : MonoBehaviour
{
    /// <summary>
    /// Called when another Collider enters this object's trigger.
    /// Adds this object to the list of interactable objects if the other object has an InteractionComponent.
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out InteractionComponent interactionComponent))
        {
            interactionComponent.AddInteractable(this, other);
        }
    }

    /// <summary>
    /// Called when another Collider exits this object's trigger.
    /// Removes this object from the list of interactable objects if the other object has an InteractionComponent.
    /// </summary>
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out InteractionComponent interactionComponent))
        {
            interactionComponent.RemoveInteractable(this, other);
        }
    }

    public abstract void Interact(CharacterBase interactor);
}