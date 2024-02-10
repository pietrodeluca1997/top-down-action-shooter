
using UnityEngine;

[RequireComponent(typeof(PlayerCharacter))]
public class PlayerController : AbstractSingleton<PlayerController>
{
    protected InputActions inputActions;
    protected PlayerCharacter playerCharacter;

    protected override void Awake()
    {
        base.Awake();
                
        inputActions = new InputActions();
        playerCharacter = GetComponent<PlayerCharacter>();
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