using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out InteractionComponent interactionComponent))
        {
            interactionComponent.AddInteractable(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out InteractionComponent interactionComponent))
        {
            interactionComponent.RemoveInteractable(this);
        }
    }
}