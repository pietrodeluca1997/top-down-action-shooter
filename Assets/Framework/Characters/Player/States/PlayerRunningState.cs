public class PlayerRunningState : PlayerGroundedState
{
    public PlayerRunningState(PlayerCharacter playerCharacter, PlayerStateMachine playerStateMachine, string animationStateName) : base(playerCharacter, playerStateMachine, animationStateName)
    {

    }

    public override void Enter()
    {
        base.Enter();

        StateMachine.PlayerController.OnLeftShiftAction += RunAction;
    }

    public override void Update()
    {
        base.Update();

        PlayerCharacter.LocomotionComponentOnFoot.Run(StateMachine.PlayerController.MovementInput);
    }

    public override void Exit()
    {
        base.Exit();

        StateMachine.PlayerController.OnLeftShiftAction -= RunAction;
    }

    public void RunAction(EInputActionEventType action)
    {
        if(action.Equals(EInputActionEventType.Canceled))
        {
            if (StateMachine.PlayerController.MovementInput.magnitude == 0)
            {
                StateMachine.ChangeState(PlayerCharacter.IdleState);
            }
            else
            {
                StateMachine.ChangeState(PlayerCharacter.WalkState);
            }
        }
    }
}