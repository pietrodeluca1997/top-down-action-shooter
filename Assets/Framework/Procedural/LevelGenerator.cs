using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelGenerator : AbstractSingleton<LevelGenerator>
{
    // List of map pieces to be used for level generation.
    [SerializeField]
    private List<MapPiece> mapPieces;

    // Generates a random map piece and instantiates it.
    [ContextMenu("Generate Random Map Piece")]
    public void GenerateLevelPart()
    {
        Instantiate(PickRandomMapPiece());
    }

    // Generates the main room map piece and instantiates it.
    [ContextMenu("Generate Main Room")]
    public void GenerateMainRoom()
    {
        Instantiate(mapPieces.First());
    }

    // Generates the main hall map piece and instantiates it.
    [ContextMenu("Generate Main Hall")]
    public void GenerateMainHall()
    {
        Instantiate(mapPieces.Last());
    }

    // Generates the main room and main hall map pieces, then snaps them together.
    [ContextMenu("Generate Main Room and Main Hall")]
    public void GenerateMainRoomAndHall()
    {
        MapPiece mainRoom = Instantiate(mapPieces.First());
        MapPiece mainHall = Instantiate(mapPieces.Last());

        MapPieceSnapPoint exitMainRoom = mainRoom.GetExitSnapPoint();
        MapPieceSnapPoint enterMainHall = mainHall.GetEntrySnapPoint();

        mainRoom.SnapBetween(exitMainRoom, enterMainHall);
    }

    // Picks a random map piece from the list.
    private MapPiece PickRandomMapPiece()
    {
        MapPiece chosenPart = mapPieces.PickRandom(out _);

        return chosenPart;
    }
}
