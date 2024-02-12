/// <summary>
/// Interface for defining a player state in a player state machine.
/// </summary>
public interface IPlayerStateBase : IStateBase<PlayerStateMachine>
{
    /// <summary>
    /// Gets the player character associated with this state.
    /// </summary>
    PlayerCharacter PlayerCharacter { get; }

    /// <summary>
    /// Gets the name of the animation state associated with this state.
    /// </summary>
    string AnimationStateName { get; }
}
