using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Shooter))]
[RequireComponent (typeof(Health))]
public class PlayerMovement : MonoBehaviour
{
    private PlayerInput playerInput;
    private Rigidbody2D rb;
    private SpriteRenderer rbSprite;
    private Animator animator;
    private Shooter shooter;
    [Header("On death message panel")]
    [SerializeField] GameObject deathMessagePanel;
    [Header("Movement")]
    [SerializeField] private float jumpForce = 2;
    [SerializeField] private float speed = 1;
    [SerializeField] private AnimationCurve speedCurve;
    private float accelerationTime = 0f;
    private float maxAccelerationTime = 1.0f;
    [Header("Jumping")]
    [SerializeField] private float overlapCircleRadius = 0.1f;
    [SerializeField] private Transform groundColliderTransform;
    private bool isJumping = false;
    private bool isRunning = false;
    private bool isFire = false;
    float direction = 0;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
        rbSprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        shooter = GetComponent<Shooter>();
    }

    void Update()
    {
        if (isRunning)
        {
            accelerationTime += Time.deltaTime;
            if (accelerationTime > maxAccelerationTime)
            {
                accelerationTime = maxAccelerationTime;
            }
        }
        else
        {
            accelerationTime = 0;
        }
        speed = speedCurve.Evaluate(accelerationTime / maxAccelerationTime) * Mathf.Sign(direction);
    }

    private void FixedUpdate()
    {

        rb.velocity = new Vector2(speed, rb.velocity.y);

        if (isFire)
        {
            animator.SetBool("isKicking", true);
            shooter.Shoot(direction);
            isFire = false;
        }
    }

    //HorizontalMovement
    public void PlayerMove(InputAction.CallbackContext context)
    {
        isRunning = true;
        direction = context.ReadValue<float>();
        if (context.performed)
        {
            rbSprite.flipX = direction < 0;
        }
        if (context.canceled)
        {
            direction = rbSprite.flipX == false? 1 : -1;
            isRunning = false;
        }

        animator.SetBool("isRunning",isRunning);
    }

    //IsGroundedCheck
    private bool IsGroundedCheck()
    {
        Vector2 playerPosition = groundColliderTransform.position;
        Vector2 direction = Vector2.down;
        float distance = overlapCircleRadius;
        LayerMask groundLayer = LayerMask.GetMask("Ground");
        Collider2D hit = Physics2D.OverlapCircle(playerPosition, overlapCircleRadius,groundLayer);
        return (hit != null);
    }

    public void PlayerJump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGroundedCheck())
        {
            animator.SetBool("isJumping", true);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    public void PlayerFire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            animator.SetBool("isKicking", true);
            shooter.Shoot(direction);
            isFire = false;
        }
    }

    private void ResetJump()
    {
        isJumping = false;
        animator.SetBool("isJumping", false);
    }

    private void ResetFire()
    {
        animator.SetBool("isKicking", false);
    }

}
