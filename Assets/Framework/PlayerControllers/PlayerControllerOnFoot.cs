using UnityEngine;

public class PlayerControllerOnFoot : PlayerController
{    
    private Vector2 movementInput;    

    protected override void Awake()
    {
        base.Awake();
        
        inputActions.CharacterOnFoot.Movement.performed += context => movementInput = context.ReadValue<Vector2>();
        inputActions.CharacterOnFoot.Movement.canceled += context => movementInput = Vector2.zero;
    }

    public void Update()
    {        
        playerCharacter.LocomotionComponentOnFoot.Move(movementInput);
    }
}

