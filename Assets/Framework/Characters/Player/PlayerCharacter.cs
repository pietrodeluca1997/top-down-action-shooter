using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(LocomotionComponentOnFoot))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerStateMachine))]
public class PlayerCharacter : CharacterBase
{
    public CharacterController Controller { get; private set; }
    public LocomotionComponentOnFoot LocomotionComponentOnFoot { get; private set; }
    public Animator Animator { get; private set; }
    public PlayerStateMachine StateMachine { get; private set; }
    public IPlayerStateBase IdleState { get; private set; }
    public IPlayerStateBase WalkState { get; private set; }

    protected void Awake()
    {
        StateMachine = GetComponent<PlayerStateMachine>();

        Controller = GetComponent<CharacterController>();

        LocomotionComponentOnFoot = GetComponent<LocomotionComponentOnFoot>();
        LocomotionComponentOnFoot.CharacterController = Controller;

        Animator = GetComponent<Animator>();

        IdleState = new PlayerIdleState(this, StateMachine, "IsIdle");
        WalkState = new PlayerWalkState(this, StateMachine, "IsWalking");
    }

    private void Start()
    {
        StateMachine.Initialize(IdleState);
    }
}