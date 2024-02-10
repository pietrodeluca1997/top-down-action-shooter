using UnityEngine;

public class MapPieceSnapPoint : MonoBehaviour
{
    // Enum representing the type of snap point.
    [SerializeField] private EMapPieceSnapPointType snapPointType;

    // Property to access the snap point type.
    public EMapPieceSnapPointType SnapPointType { get => snapPointType; }
}
