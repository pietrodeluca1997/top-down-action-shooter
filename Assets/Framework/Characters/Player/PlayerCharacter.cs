using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(LocomotionComponentOnFoot))]
public class PlayerCharacter : MonoBehaviour
{
    public CharacterController Controller { get; private set; }
    public LocomotionComponentOnFoot LocomotionComponentOnFoot { get; private set; }

    private void Awake()
    {
        Controller = GetComponent<CharacterController>();
        LocomotionComponentOnFoot = GetComponent<LocomotionComponentOnFoot>();
        LocomotionComponentOnFoot.CharacterController = Controller;
    }
}