using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpSpeed = 9f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundRadius = 0.12f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float fallLimit = -7f;
    [SerializeField] private int points;

    private Rigidbody2D body;
    private Vector2 startPosition;
    private float moveInput;
    private bool jumpRequested;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        startPosition = body.position;
    }

    private void Update()
    {
        moveInput = 0f;
        if (Keyboard.current == null) return;

        if (Keyboard.current.aKey.isPressed ||
            Keyboard.current.leftArrowKey.isPressed)
            moveInput -= 1f;

        if (Keyboard.current.dKey.isPressed ||
            Keyboard.current.rightArrowKey.isPressed)
            moveInput += 1f;

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
            jumpRequested = true;
    }

    private void FixedUpdate()
    {
        bool grounded = groundCheck != null &&
            Physics2D.OverlapCircle(
                groundCheck.position,
                groundRadius, groundLayer) != null;

        body.linearVelocity = new Vector2(
            moveInput * moveSpeed,
            body.linearVelocity.y);

        if (jumpRequested && grounded &&
            body.linearVelocity.y <= 0.1f)
        {
            body.linearVelocity = new Vector2(
                body.linearVelocity.x, jumpSpeed);
        }
        jumpRequested = false;

        if (body.position.y < fallLimit)
        {
            body.position = startPosition;
            body.linearVelocity = Vector2.zero;
            body.angularVelocity = 0f;
        }
    }

    public void AddPoints(int amount)
    {
        points += amount;
        Debug.Log("Punkty: " + points);
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(
            groundCheck.position, groundRadius);
    }

    public int GetPoints()
    {
        return points;
    }
}