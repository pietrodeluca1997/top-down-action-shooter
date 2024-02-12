using UnityEngine;
public class LocomotionComponentOnFoot : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;

    [SerializeField]
    private float runningSpeed;

    [SerializeField]
    private float reducedSpeedWhenBackwards;

    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private Vector3 moventDirectionRelativeToOrientation;
    public Vector3 MovementDirectionRelativeToOrientation {  get => moventDirectionRelativeToOrientation; private set => moventDirectionRelativeToOrientation = value; }

    private Vector3 movementDirection;
    public Vector3 MovementDirection {  get => movementDirection; private set => movementDirection = value; }

    private const float gravityYScaleOnAir = 9.81f;
    private const float defaultVerticalVelocity = -0.5f;

    private float verticalVelocity = defaultVerticalVelocity;

    public CharacterController CharacterController { get; set; }

    public void Move(Vector2 movementInput)
    {
        CalculateDirection(movementInput);
        ApplyGravity();

        if (MovementDirection.magnitude > 0)
        {
            float moveSpeedByDirection = MovementDirectionRelativeToOrientation.z <= -0.3 ? movementSpeed * reducedSpeedWhenBackwards : movementSpeed;
            
            CharacterController.Move(moveSpeedByDirection * Time.deltaTime * MovementDirection);
        }
    }

    public void Run(Vector2 movementInput)
    {
        CalculateDirection(movementInput);
        ApplyGravity();

        if (MovementDirection.magnitude > 0)
        {
            float runningSpeedByDirection = MovementDirectionRelativeToOrientation.z <= -0.3 ? runningSpeed * reducedSpeedWhenBackwards : runningSpeed;

            CharacterController.Move(runningSpeedByDirection * Time.deltaTime * MovementDirection);
        }
    }

    public void LookAt(Vector3 direction)
    {
        Quaternion lookAtMouseRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookAtMouseRotation, rotationSpeed * Time.deltaTime);
    }

    private void CalculateDirection(Vector2 movementInput)
    {
        MovementDirection = new Vector3(movementInput.x, 0.0f, movementInput.y);
        MovementDirectionRelativeToOrientation = new Vector3(Vector3.Dot(MovementDirection.normalized, transform.right), 0f, Vector3.Dot(MovementDirection.normalized, transform.forward));
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