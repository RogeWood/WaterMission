//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] private bool isCanMove = true;



	[SerializeField] private bool isGrounded;  // 是否在地面上
	[SerializeField] private float moveSpeed = 5f;  // 移動速度
	[SerializeField] private float jumpForce = 8f;  // 跳躍力度
	private Rigidbody2D rb;
	private Animator animator;

	public void SetPlayerCanMove(bool status)
    {
        isCanMove = status;
        return;
    }
    
	public bool isPalyerOnGround()
	{
		return isGrounded;
	}

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
		if (isCanMove)
		{
			Move();
			Jump();
		}
		UpdateAnimation();
	}


	private void Move()
	{
		float moveInput = Input.GetAxis("Horizontal"); // A/D 或 左/右 鍵
		rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

		// 翻轉角色方向
		if (moveInput*rb.transform.localScale.x > 0)
			rb.transform.localScale = new Vector3(rb.transform.localScale.x*-1, rb.transform.localScale.y, rb.transform.localScale.z);
	}

	private void Jump()
	{
		//if (Input.GetKeyDown() && Input.GetKeyDown(KeyCode.W))
		//	Debug.Log("jump");
		if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) && isGrounded)
		{
			rb.velocity = new Vector2(rb.velocity.x, jumpForce);
			isGrounded = false;
		}
	}

	// 檢測角色是否著地
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Ground"))
		{
			isGrounded = true;
		}
		else
		{
			isGrounded = false;
		}
	}

	private void UpdateAnimation()
	{
		animator.SetBool("isMove", rb.velocity.x != 0);
		animator.SetBool("jump", !isGrounded);
	}
}
