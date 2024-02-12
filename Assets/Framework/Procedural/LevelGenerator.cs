using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Singleton class responsible for generating levels by assembling map pieces.
/// </summary>
public class LevelGenerator : AbstractSingleton<LevelGenerator>
{
    /// <summary>
    /// List of map pieces to be used for level generation.
    /// </summary>
    [SerializeField]
    private List<MapPiece> mapPieces;

    /// <summary>
    /// Generates a random map piece and instantiates it.
    /// </summary>
    [ContextMenu("Generate Random Map Piece")]
    public void GenerateRandomMapPiece()
    {
        Instantiate(PickRandomMapPiece());
    }

    /// <summary>
    /// Generates the main room map piece and instantiates it.
    /// </summary>
    [ContextMenu("Generate Main Room")]
    public void GenerateMainRoom()
    {
        Instantiate(mapPieces.First());
    }

    /// <summary>
    /// Generates the main hall map piece and instantiates it.
    /// </summary>
    [ContextMenu("Generate Main Hall")]
    public void GenerateMainHall()
    {
        Instantiate(mapPieces.Last());
    }

    /// <summary>
    /// Generates the main room and main hall map pieces, then snaps them together.
    /// </summary>
    [ContextMenu("Generate Main Room and Main Hall")]
    public void GenerateMainRoomAndHall()
    {
        MapPiece mainRoom = Instantiate(mapPieces.First());
        MapPiece mainHall = Instantiate(mapPieces.Last());

        MapPieceSnapPoint exitMainRoom = mainRoom.GetExitSnapPoint();
        MapPieceSnapPoint enterMainHall = mainHall.GetEntrySnapPoint();

        mainRoom.SnapBetween(exitMainRoom, enterMainHall);
    }

    /// <summary>
    /// Picks a random map piece from the list.
    /// </summary>
    private MapPiece PickRandomMapPiece()
    {
        MapPiece chosenPart = mapPieces.PickRandom(out _);

        return chosenPart;
    }

    // Add property to access mapPieces if needed
    // public List<MapPiece> MapPieces => mapPieces;
}
