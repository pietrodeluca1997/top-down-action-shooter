public abstract class PlayerGroundedState : PlayerStateBase
{
    public PlayerGroundedState(PlayerCharacter playerCharacter, PlayerStateMachine playerStateMachine, string animationStateName) : base(playerCharacter, playerStateMachine, animationStateName)
    {
       
    }

    public override void Update()
    {
        base.Update();
    }
}