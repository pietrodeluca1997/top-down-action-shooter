using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerStateMachine : StateMachineBase
{
    public PlayerController PlayerController { get; private set; }

    private void Awake()
    {
        PlayerController = GetComponent<PlayerController>();
    }
    public override void Initialize(IStateBase initialState)
    {
        base.Initialize(initialState);
    }

    public override void Update()
    {
        base.Update();
    }

    public override void ChangeState(IStateBase newState)
    {
        base.ChangeState(newState);
    }
}
