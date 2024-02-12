/// <summary>
/// Represents the player's idle state when the player character is on the ground.
/// </summary>
public class PlayerIdleState : PlayerGroundedState
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PlayerIdleState"/> class.
    /// </summary>
    /// <param name="playerCharacter">The player character.</param>
    /// <param name="playerStateMachine">The player state machine.</param>
    /// <param name="animationStateName">The name of the animation state.</param>
    public PlayerIdleState(PlayerCharacter playerCharacter, PlayerStateMachine playerStateMachine, string animationStateName) : base(playerCharacter, playerStateMachine, animationStateName)
    {
    }

    /// <summary>
    /// Updates the player's idle state.
    /// </summary>
    public override void Update()
    {
        base.Update();

        // If there is any movement input, transition to the walk state
        if (StateMachine.PlayerController.MovementInput.magnitude > 0)
        {
            StateMachine.ChangeState(PlayerCharacter.WalkState);
        }
    }
}
