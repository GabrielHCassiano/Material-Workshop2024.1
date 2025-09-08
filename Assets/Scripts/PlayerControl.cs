using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rb;

    public float inputHorizontal;
    public bool inputJump;

    public float speed;
    public float forceJump;

    public bool inGround;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        InputLogic();
        JumpLogic();
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

    public  void JumpLogic()
    {
        if (inputJump && inGround)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, forceJump);
        }
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
