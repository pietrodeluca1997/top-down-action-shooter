using UnityEngine;

/// <summary>
/// Represents the base class for all player states.
/// </summary>
public abstract class PlayerStateBase : IPlayerStateBase
{
    /// <summary>
    /// The player character associated with this state.
    /// </summary>
    public PlayerCharacter PlayerCharacter { get; }

    /// <summary>
    /// The state machine managing player states.
    /// </summary>
    public PlayerStateMachine StateMachine { get; }

    /// <summary>
    /// The name of the animation state associated with this state.
    /// </summary>
    public string AnimationStateName { get; }

    private string XVelocityAnimationKey { get; }
    private string ZVelocityAnimationKey { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="PlayerStateBase"/> class.
    /// </summary>
    /// <param name="playerCharacter">The player character.</param>
    /// <param name="playerStateMachine">The player state machine.</param>
    /// <param name="animationStateName">The name of the animation state.</param>
    public PlayerStateBase(PlayerCharacter playerCharacter, PlayerStateMachine playerStateMachine, string animationStateName)
    {
        PlayerCharacter = playerCharacter;
        StateMachine = playerStateMachine;
        XVelocityAnimationKey = "xVelocity";
        ZVelocityAnimationKey = "zVelocity";
        AnimationStateName = animationStateName;
    }

    /// <summary>
    /// Called when entering this state.
    /// </summary>
    public virtual void Enter()
    {
        PlayerCharacter.Animator.SetBool(AnimationStateName, true);
    }

    /// <summary>
    /// Called every frame while in this state.
    /// </summary>
    public virtual void Update()
    {
        // Update animation parameters based on player movement
        PlayerCharacter.Animator.SetFloat(XVelocityAnimationKey, PlayerCharacter.LocomotionComponentOnFoot.MovementDirectionRelativeToOrientation.x, .1f, Time.deltaTime);
        PlayerCharacter.Animator.SetFloat(ZVelocityAnimationKey, PlayerCharacter.LocomotionComponentOnFoot.MovementDirectionRelativeToOrientation.z, .1f, Time.deltaTime);

        // Look at the mouse cursor position
        Vector3 mouseWorldPosition = StateMachine.PlayerController.CalculateMouseWorldPosition();
        if (mouseWorldPosition != Vector3.zero)
        {
            PlayerCharacter.LocomotionComponentOnFoot.LookAt(mouseWorldPosition);
        }
    }

    /// <summary>
    /// Called when exiting this state.
    /// </summary>
    public virtual void Exit()
    {
        PlayerCharacter.Animator.SetBool(AnimationStateName, false);
    }
}
