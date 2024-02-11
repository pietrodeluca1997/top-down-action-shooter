using UnityEngine;

public class PlayerController : AbstractSingleton<PlayerController>
{
    public InputActions InputActions { get; private set; }

    [SerializeField] private LayerMask mouseAimLayerMask;

    public Vector3 MousePosition { get; private set; }
    public Vector3 MovementInput { get; private set; }

    public delegate void PlayerControllerActionDelegateSignature(EInputActionEventType eventType);

    public event PlayerControllerActionDelegateSignature OnLeftShiftAction;

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
    }

    private void OnEnable()
    {
        InputActions.Enable();
    }

    private void OnDisable()
    {
        InputActions.Disable();
    }
}