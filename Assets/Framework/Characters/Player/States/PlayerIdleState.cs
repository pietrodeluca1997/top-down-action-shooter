public class PlayerIdleState : PlayerStateBase
{
    public override string AnimationStateName { get; }

    public PlayerIdleState(PlayerCharacter playerCharacter, PlayerStateMachine playerStateMachine, string animationStateName) : base(playerCharacter, playerStateMachine)
    {
        AnimationStateName = animationStateName;
    }

    public override void Update()
    {
        base.Update();

        if (StateMachine.PlayerController.MovementInput.magnitude > 0)
        {
            StateMachine.ChangeState(PlayerCharacter.WalkState);
        }
    }
}