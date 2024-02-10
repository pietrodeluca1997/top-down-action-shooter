using UnityEngine;

public class PlayerControllerOnFoot : PlayerController
{    
    private Vector2 movementInput;
    private Vector2 aimInput;

    [SerializeField] private LayerMask mouseAimLayerMask;

    protected override void Awake()
    {
        base.Awake();
        
        inputActions.CharacterOnFoot.Movement.performed += context => movementInput = context.ReadValue<Vector2>();
        inputActions.CharacterOnFoot.Movement.canceled += context => movementInput = Vector2.zero;

        inputActions.CharacterOnFoot.Aim.performed += context => aimInput = context.ReadValue<Vector2>();
        inputActions.CharacterOnFoot.Aim.canceled += context => aimInput = Vector2.zero;
    }

    public void Update()
    {        
        playerCharacter.LocomotionComponentOnFoot.Move(movementInput);
        
        CalculateMouseWorldPosition();
    }

    private void CalculateMouseWorldPosition()
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(aimInput);

        if(Physics.Raycast(cameraRay, out RaycastHit hitInfo, Mathf.Infinity, mouseAimLayerMask))
        {
            Vector3 mouseDirection = hitInfo.point - transform.position;
            mouseDirection.y = 0f;
            mouseDirection.Normalize();

            playerCharacter.LocomotionComponentOnFoot.LookAt(mouseDirection);
        }
    }
}

