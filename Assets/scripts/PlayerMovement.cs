using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float moveSpeed = 5f;
	public float dashSpeed = 15f;
	public float dashTime = 0.5f;
	public float dashCooldown = 1f;
	public bool canDash = false;

	private Rigidbody2D rb;

	private Vector2 moveInput;
	private Vector2 dashDirection;

	private bool isDashing;
	private float dashTimer;
	private float dashCooldownTimer;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void Update()
	{

		float moveX = Input.GetAxisRaw("Horizontal");
		float moveY = Input.GetAxisRaw("Vertical");

		moveInput = new Vector2(moveX, moveY).normalized;

		if (Input.GetKeyDown(KeyCode.LeftShift) && dashCooldownTimer <= 0 && !isDashing && canDash)
		{
			isDashing = true;
			dashTimer = dashTime;
			dashCooldownTimer = dashCooldown;

			dashDirection = moveInput;

			if (dashDirection == Vector2.zero)
				dashDirection = Vector2.right * Mathf.Sign(transform.localScale.x);

			GetComponentInChildren<SpearKill>().durability++;
		}

		if (dashCooldownTimer > 0)
			dashCooldownTimer -= Time.deltaTime;
	}

	void FixedUpdate()
	{
		if (isDashing)
		{
			rb.linearVelocity = dashDirection * dashSpeed;

			dashTimer -= Time.fixedDeltaTime;

			if (dashTimer <= 0)
			{
				isDashing = false;
			}
		}
		else
		{

			rb.linearVelocity = moveInput * moveSpeed;
		}
	}
}