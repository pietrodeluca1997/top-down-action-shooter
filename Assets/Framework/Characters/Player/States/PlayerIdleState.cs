public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(PlayerCharacter playerCharacter, PlayerStateMachine playerStateMachine, string animationStateName) : base(playerCharacter, playerStateMachine, animationStateName)
    {

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