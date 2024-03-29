using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvements : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    [SerializeField]
    Rigidbody2D rb;
    float force = 7f;
    bool canJump;
    bool jumpButtonPressed;
    float speed = 5f;

    [SerializeField]
    Transform playerSprite;
    bool rotateSprite;

    private float distanceRaycast = 1.5f;
    [SerializeField]
    LayerMask groundLayerMask;
    [SerializeField]
    bool isGrounded = true;

    [SerializeField]
    Transform CheckGrounded;

    [SerializeField]
    Transform RespawnPoint;

    int idle = Animator.StringToHash("Idle");
    int running = Animator.StringToHash("Running");

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (jumpButtonPressed)
        {
            rb.AddForce(new Vector2(0, force), ForceMode2D.Impulse);
            canJump = false;
            jumpButtonPressed = false;
        }

        rb.MovePosition(gameObject.transform.position + new Vector3(horizontalInput * Time.deltaTime * speed, 0));
    }
    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("Runspeed", Mathf.Abs(horizontalInput));
        animator.SetFloat("rbVelocityy", rb.velocity.y);

        
        //transform.position += new Vector3(horizontalInput * Time.deltaTime * speed, 0,0);

        Debug.DrawLine(CheckGrounded.position, new Vector3(transform.position.x, transform.position.y - distanceRaycast, transform.position.z), UnityEngine.Color.red);
        isGrounded = Physics2D.Raycast(CheckGrounded.position, Vector3.down, distanceRaycast, groundLayerMask);



        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded && canJump)
        {
            jumpButtonPressed = true;
        }

        if (horizontalInput <0 || horizontalInput > 0)
        {
            playerSprite.localScale = new Vector3(Mathf.Sign(horizontalInput) * Mathf.Abs(playerSprite.localScale.x), playerSprite.localScale.y, playerSprite.localScale.z);
        }

        if (Physics2D.Raycast(CheckGrounded.transform.position, Vector3.down, distanceRaycast, LayerMask.GetMask("Slope")))
        {
            rb.sharedMaterial.friction = 1f;
        }
        else
        {
            rb.sharedMaterial.friction = 0.6f;
        }

        Debug.Log(rb.velocity.x);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Ground") || collision.collider.gameObject.layer == LayerMask.NameToLayer("Slope"))
        {
            canJump = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DeathZone"))
        {
            transform.position = RespawnPoint.position;
            rb.velocity = new Vector2(rb.velocity.x, 0f);
        }
    }
}