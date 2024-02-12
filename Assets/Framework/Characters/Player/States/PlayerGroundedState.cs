/// <summary>
/// Represents the base class for player states when the player character is grounded.
/// </summary>
public abstract class PlayerGroundedState : PlayerStateBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PlayerGroundedState"/> class.
    /// </summary>
    /// <param name="playerCharacter">The player character.</param>
    /// <param name="playerStateMachine">The player state machine.</param>
    /// <param name="animationStateName">The name of the animation state.</param>
    public PlayerGroundedState(PlayerCharacter playerCharacter, PlayerStateMachine playerStateMachine, string animationStateName) : base(playerCharacter, playerStateMachine, animationStateName)
    {
        // Subscribe to the Space action to handle dodging
        playerStateMachine.PlayerController.OnSpaceAction += DodgeAction;
    }

    /// <summary>
    /// Called when entering this state.
    /// </summary>
    public override void Enter()
    {
        base.Enter();
    }

    /// <summary>
    /// Called every frame while in this state.
    /// </summary>
    public override void Update()
    {
        base.Update();
    }

    /// <summary>
    /// Called when exiting this state.
    /// </summary>
    public override void Exit()
    {
        base.Exit();
    }

    /// <summary>
    /// Handles the action triggered when the Space key is pressed to initiate a dodge.
    /// </summary>
    /// <param name="action">The type of action (Performed or Canceled).</param>
    public void DodgeAction(EInputActionEventType action)
    {
        // If the Space key is pressed and the player is not already dodging, transition to the dodge state
        if (action == EInputActionEventType.Performed && !PlayerCharacter.LocomotionComponentOnFoot.IsDodging)
        {
            StateMachine.ChangeState(PlayerCharacter.DodgeState);
        }
    }
}
