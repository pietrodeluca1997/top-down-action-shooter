using UnityEngine;

/// <summary>
/// Base class for implementing a state machine.
/// </summary>
public class StateMachineBase : MonoBehaviour, IStateMachineBase
{
    /// <summary>
    /// The current state of the state machine.
    /// </summary>
    public IStateBase CurrentState { get; set; }

    /// <summary>
    /// Initializes the state machine with an initial state.
    /// </summary>
    /// <param name="initialState">The initial state of the state machine.</param>
    public virtual void Initialize(IStateBase initialState)
    {
        CurrentState = initialState;
        CurrentState.Enter();
    }

    /// <summary>
    /// Updates the current state of the state machine.
    /// </summary>
    public virtual void Update()
    {
        CurrentState.Update();
    }

    /// <summary>
    /// Changes the current state of the state machine to a new state.
    /// </summary>
    /// <param name="newState">The new state to set.</param>
    public virtual void ChangeState(IStateBase newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
}
