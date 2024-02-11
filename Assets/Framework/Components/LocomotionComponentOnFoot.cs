using UnityEngine;
public class LocomotionComponentOnFoot : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;

    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private Vector3 movementDirection;

    private const float gravityYScaleOnAir = 9.81f;
    private const float defaultVerticalVelocity = -0.5f;

    private float verticalVelocity = defaultVerticalVelocity;

    public CharacterController CharacterController { get; set; }

    public void Move(Vector2 movementInput)
    {
        movementDirection = new Vector3(movementInput.x, 0.0f, movementInput.y);

        ApplyGravity();

        if (movementDirection.magnitude > 0)
        {
            CharacterController.Move(movementSpeed * Time.deltaTime * movementDirection);
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