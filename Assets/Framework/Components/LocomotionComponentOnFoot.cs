using UnityEngine;

/// <summary>
/// Handles locomotion and rotation for a character controller on foot.
/// </summary>
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
    private Vector3 movementDirectionRelativeToOrientation;
    public Vector3 MovementDirectionRelativeToOrientation { get => movementDirectionRelativeToOrientation; private set => movementDirectionRelativeToOrientation = value; }

    private Vector3 movementDirection;
    public Vector3 MovementDirection { get => movementDirection; private set => movementDirection = value; }

    public bool IsRunning { get; set; }
    public bool IsDodging { get; set; }

    private const float gravityYScaleOnAir = 9.81f;
    private const float defaultVerticalVelocity = -0.5f;
    private const float backwardsThreshold = -0.3f; 


    private float verticalVelocity = defaultVerticalVelocity;

    public CharacterController CharacterController { get; set; }

    /// <summary>
    /// Moves the character based on the given movement input.
    /// </summary>
    public void Move(Vector2 movementInputAxes)
    {
        CalculateDirection(movementInputAxes);
        ApplyGravity();

        float moveSpeedByDirection = MovementDirectionRelativeToOrientation.z <= backwardsThreshold ? movementSpeed * reducedSpeedWhenBackwards : movementSpeed;
        MoveWithSpeed(moveSpeedByDirection);
    }

    /// <summary>
    /// Runs the character based on the given movement input.
    /// </summary>
    public void Run(Vector2 movementInputAxes)
    {
        CalculateDirection(movementInputAxes);
        ApplyGravity();

        float runningSpeedByDirection = MovementDirectionRelativeToOrientation.z <= backwardsThreshold ? runningSpeed * reducedSpeedWhenBackwards : runningSpeed;
        MoveWithSpeed(runningSpeedByDirection);
    }

    private void MoveWithSpeed(float speed)
    {
        if (MovementDirection.magnitude > 0)
        {
            CharacterController.Move(speed * Time.deltaTime * MovementDirection);
        }
    }

    /// <summary>
    /// Rotates the character to look at the specified direction.
    /// </summary>
    public void LookAt(Vector3 direction)
    {
        Quaternion lookAtDirection = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookAtDirection, rotationSpeed * Time.deltaTime);
    }

    /// <summary>
    /// Turns the character to face the specified direction instantly.
    /// </summary>
    public void Turn(Vector3 direction)
    {
        transform.forward = direction;
    }

    private void CalculateDirection(Vector2 movementInputAxes)
    {
        MovementDirection = new Vector3(movementInputAxes.x, 0.0f, movementInputAxes.y);
        MovementDirectionRelativeToOrientation = new Vector3(Vector3.Dot(MovementDirection.normalized, transform.right), 0f, Vector3.Dot(MovementDirection.normalized, transform.forward));
    }

    private void ApplyGravity()
    {
        if (!CharacterController.isGrounded)
        {
            verticalVelocity -= gravityYScaleOnAir * Time.deltaTime;
            movementDirection.y = verticalVelocity; // Fixed typo here
        }
        else
        {
            verticalVelocity = defaultVerticalVelocity;
        }
    }
}
