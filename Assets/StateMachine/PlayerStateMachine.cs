using UnityEngine;

/// <summary>
/// A state machine for controlling the player's behavior.
/// </summary>
[RequireComponent(typeof(PlayerController))]
public class PlayerStateMachine : StateMachineBase
{
    /// <summary>
    /// Reference to the PlayerController component attached to the same GameObject.
    /// </summary>
    public PlayerController PlayerController { get; private set; }

    private void Awake()
    {
        PlayerController = GetComponent<PlayerController>();
    }

    public override void Initialize(IStateBase initialState)
    {
        base.Initialize(initialState);
    }

    public override void Update()
    {
        base.Update();
    }

    public override void ChangeState(IStateBase newState)
    {
        base.ChangeState(newState);
    }
}
