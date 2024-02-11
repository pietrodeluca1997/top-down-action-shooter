public class PlayerWalkState : PlayerStateBase
{
    public override string AnimationStateName { get; }

    public PlayerWalkState(PlayerCharacter playerCharacter, PlayerStateMachine playerStateMachine, string animationStateName) : base(playerCharacter, playerStateMachine)
    {
        AnimationStateName = animationStateName;
    }

    public override void Update()
    {
        base.Update();

        if (StateMachine.PlayerController.MovementInput.magnitude == 0)
        {
            StateMachine.ChangeState(PlayerCharacter.IdleState);
        }

        PlayerCharacter.LocomotionComponentOnFoot.Move(StateMachine.PlayerController.MovementInput);
    }
}