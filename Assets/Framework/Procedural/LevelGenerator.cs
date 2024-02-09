using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : AbstractSingleton<LevelGenerator>
{
    [SerializeField]
    private List<Transform> levelParts;

    [ContextMenu("Generate Level Part")]
    public void GenerateLevelPart()
    {
        Instantiate(PickRandomLevelPart());
    }

    private Transform PickRandomLevelPart()
    {
        Transform choosenPart = levelParts.PickRandom(out _);

        return choosenPart;
    }
}
