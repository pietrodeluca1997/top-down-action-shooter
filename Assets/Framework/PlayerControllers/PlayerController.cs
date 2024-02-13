using UnityEngine;

/// <summary>
/// Singleton class that handles player input and actions.
/// </summary>
public class PlayerController : AbstractSingleton<PlayerController>
{
    /// <summary>
    /// The input actions associated with the player.
    /// </summary>
    public InputActions InputActions { get; private set; }

    [SerializeField] private LayerMask mouseAimLayerMask;

    /// <summary>
    /// The position of the mouse in screen coordinates.
    /// </summary>
    public Vector3 MousePosition { get; private set; }

    /// <summary>
    /// The input for player movement.
    /// </summary>
    public Vector3 MovementInput { get; private set; }

    /// <summary>
    /// Calculates the world position of the mouse based on screen coordinates.
    /// </summary>
    public Vector3 CalculateMouseWorldPosition()
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(MousePosition);

        if (Physics.Raycast(cameraRay, out RaycastHit hitInfo, Mathf.Infinity, mouseAimLayerMask))
        {
            Vector3 mouseDirection = hitInfo.point - transform.position;
            mouseDirection.y = 0f;
            mouseDirection.Normalize();

            return mouseDirection;
        }

        return Vector3.zero;
    }

    protected override void Awake()
    {
        base.Awake();

        InputActions = new InputActions();

        InputActions.PlayerActions.MousePosition.performed += context => MousePosition = context.ReadValue<Vector2>();
        InputActions.PlayerActions.MousePosition.canceled += context => MousePosition = Vector2.zero;

        InputActions.PlayerActions.WASD.performed += context => MovementInput = context.ReadValue<Vector2>();
        InputActions.PlayerActions.WASD.canceled += context => MovementInput = Vector2.zero;

        InputActions.PlayerActions.LeftShift.performed += context => OnLeftShiftAction?.Invoke(EInputActionEventType.Performed);
        InputActions.PlayerActions.LeftShift.canceled += context => OnLeftShiftAction?.Invoke(EInputActionEventType.Canceled);

        InputActions.PlayerActions.Space.performed += context => OnSpaceAction?.Invoke(EInputActionEventType.Performed);

        InputActions.PlayerActions.E.performed += context => OnEAction?.Invoke(EInputActionEventType.Performed);

        InputActions.PlayerActions.One.performed += context => OnOneKeyAction?.Invoke(EInputActionEventType.Performed, 1);
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        InputActions.Enable();
    }

    private void OnDisable()
    {
        InputActions.Disable();
    }

    public delegate void PlayerControllerActionDelegateSignature(EInputActionEventType eventType);
    public delegate void PlayerControllerActionBarDelegateSignature(EInputActionEventType eventType, int slowIndex);

    /// <summary>
    /// Event delegate for Left Shift action.
    /// </summary>
    public event PlayerControllerActionDelegateSignature OnLeftShiftAction;

    /// <summary>
    /// Event delegate for Space action.
    /// </summary>
    public event PlayerControllerActionDelegateSignature OnSpaceAction;

    /// <summary>
    /// Event delegate for E action.
    /// </summary>
    public event PlayerControllerActionDelegateSignature OnEAction;

    /// <summary>
    /// Event delegate for 1 action.
    /// </summary>
    public event PlayerControllerActionBarDelegateSignature OnOneKeyAction;
}
