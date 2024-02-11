public interface IStateBase<TStateMachineClass> : IStateBase where TStateMachineClass : StateMachineBase
{
    TStateMachineClass StateMachine { get; }
}

public interface IStateBase
{
    void Enter();
    void Update();
    void Exit();
}