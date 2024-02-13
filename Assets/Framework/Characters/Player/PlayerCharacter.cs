using UnityEngine;

/// <summary>
/// Represents the main player character in the game.
/// </summary>
[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(LocomotionComponentOnFoot))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerStateMachine))]
[RequireComponent(typeof(PlayerComponentCommunicationProxy))]
public class PlayerCharacter : CharacterBase
{
    /// <summary>
    /// The character controller component.
    /// </summary>
    public CharacterController Controller { get; private set; }

    /// <summary>
    /// The locomotion component controlling movement on foot.
    /// </summary>
    public LocomotionComponentOnFoot LocomotionComponentOnFoot { get; private set; }

    /// <summary>
    /// The animator component controlling character animations.
    /// </summary>
    public Animator Animator { get; private set; }

    /// <summary>
    /// The state machine managing player states.
    /// </summary>
    public PlayerStateMachine StateMachine { get; private set; }

    /// <summary>
    /// The state representing the idle state of the player.
    /// </summary>
    public IPlayerStateBase IdleState { get; private set; }

    /// <summary>
    /// The state representing the walking state of the player.
    /// </summary>
    public IPlayerStateBase WalkState { get; private set; }

    /// <summary>
    /// The state representing the running state of the player.
    /// </summary>
    public IPlayerStateBase RunningState { get; private set; }

    /// <summary>
    /// The state representing the dodging state of the player.
    /// </summary>
    public IPlayerStateBase DodgeState { get; private set; }

    /// <summary>
    /// Called when the script instance is being loaded.
    /// </summary>
    protected override void Awake()
    {
        base.Awake();
        // Get required components
        Controller = GetComponent<CharacterController>();
        LocomotionComponentOnFoot = GetComponent<LocomotionComponentOnFoot>();
        LocomotionComponentOnFoot.CharacterController = Controller;
        Animator = GetComponent<Animator>();
        StateMachine = GetComponent<PlayerStateMachine>();

        // Initialize player states
        IdleState = new PlayerIdleState(this, StateMachine, "IsIdle");
        WalkState = new PlayerWalkState(this, StateMachine, "IsWalking");
        RunningState = new PlayerRunningState(this, StateMachine, "IsRunning");
        DodgeState = new PlayerDodgeState(this, StateMachine, "IsDodging");
    }

    /// <summary>
    /// Called before the first frame update.
    /// </summary>
    private void Start()
    {
        // Initialize the player state machine with the idle state
        StateMachine.Initialize(IdleState);
    }
}
