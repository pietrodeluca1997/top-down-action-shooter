using System.Linq;
using UnityEngine;

/// <summary>
/// Represents the player's state when performing a dodge action.
/// </summary>
public class PlayerDodgeState : PlayerGroundedState
{
    private readonly float animationLengthBySpeed;
    private float animationStartTime;
    private Vector3 movementDirectionWhenStartDodging;
    private const string animationClipName = "Dive Forward";

    /// <summary>
    /// Initializes a new instance of the <see cref="PlayerDodgeState"/> class.
    /// </summary>
    /// <param name="playerCharacter">The player character.</param>
    /// <param name="playerStateMachine">The player state machine.</param>
    /// <param name="animationStateName">The name of the animation state.</param>
    public PlayerDodgeState(PlayerCharacter playerCharacter, PlayerStateMachine playerStateMachine, string animationStateName) : base(playerCharacter, playerStateMachine, animationStateName)
    {
        // Get the length of the dodge animation
        RuntimeAnimatorController runtimeAnimator = playerCharacter.Animator.runtimeAnimatorController;

        animationLengthBySpeed = runtimeAnimator.animationClips.Where(animClip => animClip.name == animationClipName).First().length / 1.5f;
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

        // Store the movement direction when the dodge starts
        float movementDirectionMagnitude = PlayerCharacter.LocomotionComponentOnFoot.MovementDirection.magnitude;
        if(movementDirectionMagnitude > 0.9 || movementDirectionMagnitude < -0.9)
        {
            movementDirectionWhenStartDodging = PlayerCharacter.LocomotionComponentOnFoot.MovementDirection;
        }
        else
        {
            StateMachine.ChangeState(PlayerCharacter.IdleState);
        }
    }

    /// <summary>
    /// Called every frame while the player is in the dodge state.
    /// </summary>
    public override void Update()
    {
        // Check if the dodge animation has finished
        if (Time.time - animationStartTime > animationLengthBySpeed - 0.2f)
        {
            // Change to the walk state
            StateMachine.ChangeState(PlayerCharacter.WalkState);
        }
        else
        {
            PlayerCharacter.LocomotionComponentOnFoot.Turn(movementDirectionWhenStartDodging);
        }

        // Move the character in the dodge direction
        PlayerCharacter.LocomotionComponentOnFoot.Move(new Vector2(movementDirectionWhenStartDodging.x, movementDirectionWhenStartDodging.z));
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
