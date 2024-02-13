using System;
using System.Collections.Generic;
using UnityEngine;

public class InteractionComponent : MonoBehaviour
{
    private struct InteractableDistance : IComparable<InteractableDistance>
    {
        public InteractableObject interactableObject;
        public float distance;

        public InteractableDistance(InteractableObject interactableObject, float distance)
        {
            this.interactableObject = interactableObject;
            this.distance = distance;
        }

        public readonly int CompareTo(InteractableDistance other)
        {
            return distance.CompareTo(other.distance);
        }
    }

    [SerializeField]
    private List<InteractableObject> objectsAvailableForInteraction;

    private SortedList<float, InteractableObject> sortedInteractablesByDistance;

    private void Awake()
    {
        objectsAvailableForInteraction = new List<InteractableObject>();
        sortedInteractablesByDistance = new SortedList<float, InteractableObject>();
    }

    public void AddInteractable(InteractableObject interactableObject, Collider interactor)
    {
        objectsAvailableForInteraction.Add(interactableObject);

        float distance = Vector3.Distance(interactor.transform.position, interactableObject.transform.position);
        sortedInteractablesByDistance.Add(distance, interactableObject);
    }

    public void RemoveInteractable(InteractableObject interactableObject, Collider interactor)
    {
        objectsAvailableForInteraction.Remove(interactableObject);

        float distance = Vector3.Distance(interactor.transform.position, interactableObject.transform.position);
        sortedInteractablesByDistance.Remove(distance);
    }

    public bool TryGetNearestObject(out InteractableObject nearestInteractableObject)
    {
        if (sortedInteractablesByDistance.Count > 0)
        {
            nearestInteractableObject = sortedInteractablesByDistance.Values[0];
            return true;
        }

        nearestInteractableObject = null;
        return false;
    }
}
