using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Static class that contains extension methods for the List<TCollectionItem> class.
/// </summary>
public static class ListExtensions
{
    /// <summary>
    /// Extension method that allows picking a random item from a list.
    /// </summary>
    /// <typeparam name="TCollectionItem">The type of items stored in the list.</typeparam>
    /// <param name="collection">The list from which the item will be picked randomly.</param>
    /// <param name="randomIndex">The index of the randomly picked item.</param>
    /// <returns>The randomly picked item.</returns>
    public static TCollectionItem PickRandom<TCollectionItem>(this List<TCollectionItem> collection, out int randomIndex)
    {
        randomIndex = Random.Range(0, collection.Count);

        return collection[randomIndex];
    }
}