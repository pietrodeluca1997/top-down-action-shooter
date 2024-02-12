using System.Collections.Generic;
using UnityEngine;

public class InteractionComponent : MonoBehaviour
{
    [SerializeField]
    private List<InteractableObject> objectsAvailableForInteraction;

    private void Awake()
    {
        objectsAvailableForInteraction = new();
    }

    public void AddInteractable(InteractableObject interactableObject)
    {
        objectsAvailableForInteraction.Add(interactableObject);
    }

    public void RemoveInteractable(InteractableObject interactableObject)
    {
        objectsAvailableForInteraction.Remove(interactableObject);
    }
}