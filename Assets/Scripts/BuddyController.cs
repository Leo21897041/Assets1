using UnityEngine;

public class BuddyController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    public float moveSpeed = 4f;
    public float jumpForce = 10f;

    private float inputX = 0;
    private float facing = 1; // 1 = Right <<<>>> -1 = Left
    private bool isGrounded;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");

        //facing direction
        if (inputX > 0)
        {
            facing = 1;
        }
        else if (inputX < 0)
        {
            facing = -1;
        }

        if (facing >= 0.01)
        {
            spriteRenderer.flipX = false;
        }
        else if (facing < 0.01f)
        {
            spriteRenderer.flipX = true;
        }

        if (Input.GetButtonDown("Jump"))
        {
            rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        rigidBody.linearVelocityX = inputX * moveSpeed;
    }
}
