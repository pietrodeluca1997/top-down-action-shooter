using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapPiece : MonoBehaviour
{
    // Returns one entry snap point of the map piece.
    public MapPieceSnapPoint GetEntrySnapPoint() => GetSnapPointByType(EMapPieceSnapPointType.Enter);

    // Returns one exit snap point of the map piece.
    public MapPieceSnapPoint GetExitSnapPoint() => GetSnapPointByType(EMapPieceSnapPointType.Exit);

    // Retrieves a random snap point by the specified type.
    private MapPieceSnapPoint GetSnapPointByType(EMapPieceSnapPointType type)
    {
        // Retrieves all child snap points of the specified type.
        List<MapPieceSnapPoint> mapPieceSnapPoints = GetComponentsInChildren<MapPieceSnapPoint>()
            .Where(snapPoint => snapPoint.SnapPointType.Equals(type))
            .ToList();

        // Returns the found snap point based on the count.
        return mapPieceSnapPoints.Count switch
        {
            0 => null,
            1 => mapPieceSnapPoints[0],
            _ => mapPieceSnapPoints.PickRandom(out _),
        };
    }

    // Snaps the map piece to the entry snap point of another map piece.
    public void SnapBetween(MapPieceSnapPoint ownExitPoint, MapPieceSnapPoint targetEntrySnapPoint)
    {
        // Calculates the offset between the snap points.
        Vector3 offset = transform.position - ownExitPoint.transform.position;

        // Calculates the new position based on the target entry snap point.
        Vector3 newPosition = targetEntrySnapPoint.transform.position + offset;

        // Moves the map piece to the new position.
        transform.position = newPosition;
    }
}