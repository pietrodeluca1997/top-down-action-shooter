/// <summary>
/// Represents the player's walk state when the player character is on the ground.
/// </summary>
public class PlayerWalkState : PlayerStateBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PlayerWalkState"/> class.
    /// </summary>
    /// <param name="playerCharacter">The player character.</param>
    /// <param name="playerStateMachine">The player state machine.</param>
    /// <param name="animationStateName">The name of the animation state.</param>
    public PlayerWalkState(PlayerCharacter playerCharacter, PlayerStateMachine playerStateMachine, string animationStateName) : base(playerCharacter, playerStateMachine, animationStateName)
    {
    }

    /// <summary>
    /// Called when entering this state.
    /// </summary>
    public override void Enter()
    {
        base.Enter();

        // Subscribe to the LeftShift action to handle running
        StateMachine.PlayerController.OnLeftShiftAction += RunAction;
    }

    /// <summary>
    /// Called every frame while in this state.
    /// </summary>
    public override void Update()
    {
        base.Update();

        // If there is no movement input, transition to the idle state
        if (StateMachine.PlayerController.MovementInput.magnitude == 0)
        {
            StateMachine.ChangeState(PlayerCharacter.IdleState);
        }

        // Move the player character based on the movement input
        PlayerCharacter.LocomotionComponentOnFoot.Move(StateMachine.PlayerController.MovementInput);
    }

    /// <summary>
    /// Called when exiting this state.
    /// </summary>
    public override void Exit()
    {
        base.Exit();

        // Unsubscribe from the LeftShift action when exiting the state
        StateMachine.PlayerController.OnLeftShiftAction -= RunAction;
    }

    /// <summary>
    /// Handles the action triggered when the LeftShift key is pressed.
    /// </summary>
    /// <param name="action">The type of action (Performed or Canceled).</param>
    public void RunAction(EInputActionEventType action)
    {
        // If the LeftShift key is pressed and the player is not already running, transition to the running state
        if (action == EInputActionEventType.Performed && !PlayerCharacter.LocomotionComponentOnFoot.IsRunning)
        {
            StateMachine.ChangeState(PlayerCharacter.RunningState);
        }
    }
}
