public class PlayerWalkState : PlayerStateBase
{
    public PlayerWalkState(PlayerCharacter playerCharacter, PlayerStateMachine playerStateMachine, string animationStateName) : base(playerCharacter, playerStateMachine, animationStateName)
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

        if (StateMachine.PlayerController.MovementInput.magnitude == 0)
        {
            StateMachine.ChangeState(PlayerCharacter.IdleState);
        }

        PlayerCharacter.LocomotionComponentOnFoot.Move(StateMachine.PlayerController.MovementInput);
    }

    public override void Exit()
    {
        base.Exit();

        StateMachine.PlayerController.OnLeftShiftAction -= RunAction;
    }

    public void RunAction(EInputActionEventType action)
    {
        if(action.Equals(EInputActionEventType.Performed))
        {
            StateMachine.ChangeState(PlayerCharacter.RunningState);
        }
    }
}