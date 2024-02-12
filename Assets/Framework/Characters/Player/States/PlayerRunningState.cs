/// <summary>
/// Represents the player's running state when the player character is on the ground.
/// </summary>
public class PlayerRunningState : PlayerGroundedState
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PlayerRunningState"/> class.
    /// </summary>
    /// <param name="playerCharacter">The player character.</param>
    /// <param name="playerStateMachine">The player state machine.</param>
    /// <param name="animationStateName">The name of the animation state.</param>
    public PlayerRunningState(PlayerCharacter playerCharacter, PlayerStateMachine playerStateMachine, string animationStateName) : base(playerCharacter, playerStateMachine, animationStateName)
    {
    }

    /// <summary>
    /// Called when the player enters the running state.
    /// </summary>
    public override void Enter()
    {
        base.Enter();

        // Subscribe to the LeftShift action to handle running
        StateMachine.PlayerController.OnLeftShiftAction += RunAction;
    }

    /// <summary>
    /// Updates the player's running state.
    /// </summary>
    public override void Update()
    {
        base.Update();

        // Execute the running behavior based on player input
        PlayerCharacter.LocomotionComponentOnFoot.Run(StateMachine.PlayerController.MovementInput);
    }

    /// <summary>
    /// Called when the player exits the running state.
    /// </summary>
    public override void Exit()
    {
        base.Exit();

        // Unsubscribe from the LeftShift action when exiting the state
        StateMachine.PlayerController.OnLeftShiftAction -= RunAction;
    }

    /// <summary>
    /// Handles the action triggered when the LeftShift key is pressed or released.
    /// </summary>
    /// <param name="action">The type of action (Performed or Canceled).</param>
    public void RunAction(EInputActionEventType action)
    {
        // If the LeftShift key is released...
        if (action == EInputActionEventType.Canceled)
        {
            // If there is no movement input, transition to the idle state
            if (StateMachine.PlayerController.MovementInput.magnitude == 0)
            {
                StateMachine.ChangeState(PlayerCharacter.IdleState);
            }
            else // Otherwise, transition to the walk state
            {
                StateMachine.ChangeState(PlayerCharacter.WalkState);
            }
        }
    }
}