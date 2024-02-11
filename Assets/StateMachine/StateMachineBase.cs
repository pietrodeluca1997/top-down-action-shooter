using UnityEngine;

public class StateMachineBase : MonoBehaviour, IStateMachineBase
{
    public IStateBase CurrentState { get; set; }

    public virtual void Initialize(IStateBase initialState)
    {
        CurrentState = initialState;
        CurrentState.Enter();
    }

    public virtual void Update()
    {
        CurrentState.Update();
    }

    public virtual void ChangeState(IStateBase newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
}
