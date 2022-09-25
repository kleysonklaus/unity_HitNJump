using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player obj;

    public int lives = 3;

    public bool isGrounded = false;
    public bool isMoving = false;
    public bool isImmune = false;

    public float speed = 5f;
    public float jumpForce = 3f;
    public float movHor;

    public float immuneTimecount = 0f;
    public float immuneTime = 0.5f;

    public LayerMask groundLayer;
    public float radius = 0.3f;
    public float groundRayDist = 0.5f;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;

    void Awake()
    {
        obj = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        movHor = Input.GetAxisRaw("Horizontal");
        if (movHor < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (movHor > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        isMoving = movHor != 0f;
        isGrounded = Physics2D.CircleCast(transform.position, radius, Vector3.down, groundRayDist, groundLayer);

        anim.SetBool("isMooving", isMoving);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isImmune", isImmune);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }


    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(movHor * speed, rb.velocity.y);
    }

    public void Jump()
    {
        if (isGrounded == false) return;
        rb.velocity = Vector2.up * jumpForce;

    }

    private void OnDestroy()
    {
        obj = null;
    }
}
