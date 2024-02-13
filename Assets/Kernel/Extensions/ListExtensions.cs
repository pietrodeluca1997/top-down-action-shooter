using System;
using System.Collections.Generic;

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
    /// <param name="randomIndex">Output parameter to hold the index of the randomly picked item.</param>
    /// <returns>The randomly picked item. If the list is empty, returns default value for the type.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the collection is null.</exception>
    public static TCollectionItem PickRandom<TCollectionItem>(this List<TCollectionItem> collection, out int randomIndex)
    {
        if (collection == null)
        {
            throw new ArgumentNullException(nameof(collection));
        }

        if (collection.Count == 0)
        {
            randomIndex = -1;
            return default;
        }

        randomIndex = UnityEngine.Random.Range(0, collection.Count);
        return collection[randomIndex];
    }
}