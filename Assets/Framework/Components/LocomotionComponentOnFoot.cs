using UnityEngine;
public class LocomotionComponentOnFoot : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;

    [SerializeField]
    private float rotationSpeed;

    private Vector3 movementDirection;
    public Vector3 MovementDirection {  get => movementDirection; private set => movementDirection = value; }

    private const float gravityYScaleOnAir = 9.81f;
    private const float defaultVerticalVelocity = -0.5f;

    private float verticalVelocity = defaultVerticalVelocity;

    public CharacterController CharacterController { get; set; }

    public void Move(Vector2 movementInput)
    {
        MovementDirection = new Vector3(movementInput.x, 0.0f, movementInput.y);

        ApplyGravity();

        if (MovementDirection.magnitude > 0)
        {
            CharacterController.Move(movementSpeed * Time.deltaTime * MovementDirection);
        }
    }

    public void LookAt(Vector3 direction)
    {
        transform.forward = direction;
    }

    private void ApplyGravity()
    {
        if (!CharacterController.isGrounded)
        {
            verticalVelocity -= gravityYScaleOnAir * Time.deltaTime;
            movementDirection.y = verticalVelocity;
        }
        else
        {
            verticalVelocity = defaultVerticalVelocity;
        }
    }
}