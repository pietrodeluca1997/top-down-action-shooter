/// <summary>
/// Interface for states in a state machine.
/// </summary>
/// <typeparam name="TStateMachineClass">The type of the state machine associated with the state.</typeparam>
public interface IStateBase<TStateMachineClass> : IStateBase where TStateMachineClass : StateMachineBase
{
    /// <summary>
    /// Gets the state machine associated with this state.
    /// </summary>
    TStateMachineClass StateMachine { get; }
}

/// <summary>
/// Interface for defining state behavior.
/// </summary>
public interface IStateBase
{
    /// <summary>
    /// Called when entering the state.
    /// </summary>
    void Enter();

    /// <summary>
    /// Called every frame while the state is active.
    /// </summary>
    void Update();

    /// <summary>
    /// Called when exiting the state.
    /// </summary>
    void Exit();
}