/// <summary>
/// Interface for defining a state machine.
/// </summary>
public interface IStateMachineBase
{
    /// <summary>
    /// Gets or sets the current state of the state machine.
    /// </summary>
    IStateBase CurrentState { get; set; }

    /// <summary>
    /// Initializes the state machine with an initial state.
    /// </summary>
    /// <param name="initialState">The initial state of the state machine.</param>
    void Initialize(IStateBase initialState);

    /// <summary>
    /// Updates the current state of the state machine.
    /// </summary>
    void Update();

    /// <summary>
    /// Changes the current state of the state machine to a new state.
    /// </summary>
    /// <param name="newState">The new state to set.</param>
    void ChangeState(IStateBase newState);
}
