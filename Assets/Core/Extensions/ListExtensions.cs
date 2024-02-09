using System.Collections.Generic;
using UnityEngine;

public static class ListExtensions
{
    public static TCollectionItem PickRandom<TCollectionItem>(this List<TCollectionItem> collection, out int randomIndex)
    {
        randomIndex = Random.Range(0, collection.Count);

        return collection[randomIndex];
    }
}