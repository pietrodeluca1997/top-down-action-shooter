/// <summary>
/// Enumeration representing types of snap points in a map piece system.
/// </summary>
public enum EMapPieceSnapPointType
{
    /// <summary>
    /// Represents a snap point where another map piece snap point of type Exit can connect.
    /// </summary>
    Enter,

    /// <summary>
    /// Represents a snap point where another map piece snap point of type Enter can connect.
    /// </summary>
    Exit
}