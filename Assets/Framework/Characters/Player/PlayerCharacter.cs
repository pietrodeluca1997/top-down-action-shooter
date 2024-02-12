using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(LocomotionComponentOnFoot))]
[RequireComponent(typeof(InteractionComponent))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerStateMachine))]
public class PlayerCharacter : CharacterBase
{
    public CharacterController Controller { get; private set; }
    public LocomotionComponentOnFoot LocomotionComponentOnFoot { get; private set; }
    public InteractionComponent InteractionComponent { get; private set; }
    public Animator Animator { get; private set; }
    public PlayerStateMachine StateMachine { get; private set; }
    public IPlayerStateBase IdleState { get; private set; }
    public IPlayerStateBase WalkState { get; private set; }
    public IPlayerStateBase RunningState { get; private set; }

    protected void Awake()
    {
        Controller = GetComponent<CharacterController>();

        LocomotionComponentOnFoot = GetComponent<LocomotionComponentOnFoot>();
        LocomotionComponentOnFoot.CharacterController = Controller;

        InteractionComponent = GetComponent<InteractionComponent>();

        Animator = GetComponent<Animator>();

        StateMachine = GetComponent<PlayerStateMachine>();
        IdleState = new PlayerIdleState(this, StateMachine, "IsIdle");
        WalkState = new PlayerWalkState(this, StateMachine, "IsWalking");
        RunningState = new PlayerRunningState(this, StateMachine, "IsRunning");
    }

    private void Start()
    {
        StateMachine.Initialize(IdleState);
    }
}