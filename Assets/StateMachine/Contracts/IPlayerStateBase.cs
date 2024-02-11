public interface IPlayerStateBase : IStateBase<PlayerStateMachine>
{
    PlayerCharacter PlayerCharacter { get; }
    string AnimationStateName { get; }
}