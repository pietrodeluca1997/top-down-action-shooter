using UnityEngine;

public abstract class PlayerStateBase : IPlayerStateBase
{
    public PlayerCharacter PlayerCharacter { get; }
    public PlayerStateMachine StateMachine { get; }

    public abstract string AnimationStateName { get; }

    public PlayerStateBase(PlayerCharacter playerCharacter, PlayerStateMachine playerStateMachine)
    {
        PlayerCharacter = playerCharacter;
        StateMachine = playerStateMachine;
    }

    public virtual void Enter()
    {
        PlayerCharacter.Animator.SetBool(AnimationStateName, true);
    }

    public virtual void Update()
    {
        Vector3 mouseWorldPosition = StateMachine.PlayerController.CalculateMouseWorldPosition();

        if (mouseWorldPosition != Vector3.zero)
        {
            PlayerCharacter.LocomotionComponentOnFoot.LookAt(mouseWorldPosition);
        }
    }

    public void Exit()
    {
        PlayerCharacter.Animator.SetBool(AnimationStateName, false);
    }
}