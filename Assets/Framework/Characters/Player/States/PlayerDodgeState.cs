using UnityEngine;

/// <summary>
/// Represents the player's state when performing a dodge action.
/// </summary>
public class PlayerDodgeState : PlayerGroundedState
{
    private float animationLength;
    private float animationStartTime;
    private Vector3 movementDirectionWhenStartDodging;

    /// <summary>
    /// Initializes a new instance of the <see cref="PlayerDodgeState"/> class.
    /// </summary>
    /// <param name="playerCharacter">The player character.</param>
    /// <param name="playerStateMachine">The player state machine.</param>
    /// <param name="animationStateName">The name of the animation state.</param>
    public PlayerDodgeState(PlayerCharacter playerCharacter, PlayerStateMachine playerStateMachine, string animationStateName) : base(playerCharacter, playerStateMachine, animationStateName)
    {
    }

    /// <summary>
    /// Called when the player enters the dodge state.
    /// </summary>
    public override void Enter()
    {
        base.Enter();
        PlayerCharacter.LocomotionComponentOnFoot.IsDodging = true;
        // Start the animation timer
        animationStartTime = Time.time;
        // Get the length of the current animation
        animationLength = PlayerCharacter.Animator.GetCurrentAnimatorStateInfo(0).length;
        // Store the movement direction when the dodge starts
        movementDirectionWhenStartDodging = PlayerCharacter.LocomotionComponentOnFoot.MovementDirection;        
    }

    /// <summary>
    /// Called every frame while the player is in the dodge state.
    /// </summary>
    public override void Update()
    {
        // Move the character in the dodge direction
        PlayerCharacter.LocomotionComponentOnFoot.Move(new Vector2(movementDirectionWhenStartDodging.x, movementDirectionWhenStartDodging.z));

        // Check if the dodge animation has finished
        if (Time.time - animationStartTime >= animationLength - 0.1f) // Add a 0.1 second margin of error
        {
            // Change to the walk state
            StateMachine.ChangeState(PlayerCharacter.WalkState);
        }
        else
        {
            // Turn the character towards the dodge direction
            PlayerCharacter.LocomotionComponentOnFoot.Turn(movementDirectionWhenStartDodging);
        }
    }

    /// <summary>
    /// Called when the player exits the dodge state.
    /// </summary>
    public override void Exit()
    {
        base.Exit();
        PlayerCharacter.LocomotionComponentOnFoot.IsDodging = false;
    }
}
