using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;

    public float inputHorizontal;
    public bool inputJump;

    public float speed;
    public float forceJump;

    public bool inGround;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        InputLogic();
        JumpLogic();
        FlipLogic();
        AnimatorLogic();
    }

    private void FixedUpdate()
    {
        MoveLogic();
    }

    public void InputLogic()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");

        inputJump = Input.GetKeyDown(KeyCode.Space);
    }

    public void MoveLogic()
    {
        rb.linearVelocity = new Vector2(inputHorizontal * speed, rb.linearVelocity.y);
    }

    public void JumpLogic()
    {
        if (inputJump && inGround)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, forceJump);
        }
    }

    public void FlipLogic()
    {
        if (inputHorizontal != 0)
        {
            transform.localScale = new Vector3(inputHorizontal, 1, 1);
        }
    }

    public void AnimatorLogic()
    {
        animator.SetFloat("Horizontal", rb.linearVelocity.x);
        animator.SetFloat("Vertical", rb.linearVelocity.y);
        animator.SetBool("InGround", inGround);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            inGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            inGround = false;
        }
    }
}
