using UnityEngine;

public class PlayerController : AbstractSingleton<PlayerController>
{
    protected InputActions inputActions;

    [SerializeField] private LayerMask mouseAimLayerMask;

    public Vector3 MousePosition { get; private set; }
    public Vector3 MovementInput { get; private set; }

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

        inputActions = new InputActions();

        inputActions.CharacterOnFoot.Aim.performed += context => MousePosition = context.ReadValue<Vector2>();
        inputActions.CharacterOnFoot.Aim.canceled += context => MousePosition = Vector2.zero;

        inputActions.CharacterOnFoot.Movement.performed += context => MovementInput = context.ReadValue<Vector2>();
        inputActions.CharacterOnFoot.Movement.canceled += context => MovementInput = Vector2.zero;
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }
}