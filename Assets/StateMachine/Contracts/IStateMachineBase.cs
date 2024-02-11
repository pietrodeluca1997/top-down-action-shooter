public interface IStateMachineBase
{
    IStateBase CurrentState { get; set; }
    void Initialize(IStateBase initialState);
    void Update();
    void ChangeState(IStateBase newState);
}