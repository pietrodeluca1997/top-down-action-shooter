using UnityEngine;

public abstract class PlayerStateBase : IPlayerStateBase
{
    public PlayerCharacter PlayerCharacter { get; }
    public PlayerStateMachine StateMachine { get; }

    public string AnimationStateName { get; }
    private string XVelocityAnimationKey { get; }
    private string ZVelocityAnimationKey { get; }

    public PlayerStateBase(PlayerCharacter playerCharacter, PlayerStateMachine playerStateMachine, string animationStateName)
    {
        PlayerCharacter = playerCharacter;
        StateMachine = playerStateMachine;
        XVelocityAnimationKey = "xVelocity";
        ZVelocityAnimationKey = "zVelocity";
        AnimationStateName = animationStateName;
    }

    public virtual void Enter()
    {
        PlayerCharacter.Animator.SetBool(AnimationStateName, true);
    }

    public virtual void Update()
    {
        PlayerCharacter.Animator.SetFloat(XVelocityAnimationKey, PlayerCharacter.LocomotionComponentOnFoot.MovementDirectionRelativeToOrientation.x, .1f, Time.deltaTime);
        PlayerCharacter.Animator.SetFloat(ZVelocityAnimationKey, PlayerCharacter.LocomotionComponentOnFoot.MovementDirectionRelativeToOrientation.z, .1f, Time.deltaTime);

        Vector3 mouseWorldPosition = StateMachine.PlayerController.CalculateMouseWorldPosition();

        if (mouseWorldPosition != Vector3.zero)
        {
            PlayerCharacter.LocomotionComponentOnFoot.LookAt(mouseWorldPosition);
        }
    }

    public virtual void Exit()
    {
        PlayerCharacter.Animator.SetBool(AnimationStateName, false);
    }
}