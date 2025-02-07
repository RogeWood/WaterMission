//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] private bool isCanMove = true;



	[SerializeField] private bool isGrounded;  // �O�_�b�a���W
	[SerializeField] private float moveSpeed = 5f;  // ���ʳt��
	[SerializeField] private float jumpForce = 8f;  // ���D�O��
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
		float moveInput = Input.GetAxis("Horizontal"); // A/D �� ��/�k ��
		rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

		// ½�ਤ���V
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

	// �˴�����O�_�ۦa
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
