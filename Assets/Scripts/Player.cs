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

        if (Game.obj.gamePaused) { movHor = 0f; return; }

        movHor = Input.GetAxisRaw("Horizontal");
        if (movHor < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (movHor > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        isMoving = movHor != 0f;
        isGrounded = Physics2D.CircleCast(transform.position, radius, Vector3.down, groundRayDist, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (isImmune)
        {
            sprite.enabled = !sprite.enabled;
            immuneTimecount -= Time.deltaTime;
            if (immuneTimecount <= 0)
            {
                isImmune = false;
                sprite.enabled = true;
            }
        }

        anim.SetBool("isMooving", isMoving);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isImmune", isImmune);

        // flip(movHor);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(movHor * speed, rb.velocity.y);
    }

    private void goImmune()
    {
        isImmune = true;
        immuneTimecount = immuneTime;
    }

    public void Jump()
    {
        if (isGrounded == false) return;
        rb.velocity = Vector2.up * jumpForce;

        AudioManager.obj.playJump();
    }

    public void getDamage()
    {
        lives--;
        AudioManager.obj.playHit();

        UIManager.obj.updateLives();

        goImmune();

        if (lives <= 0)
        {
            FXManager.obj.showPop(transform.position);
            Game.obj.gameOver();
            // this.gameObject.SetActive(false);
        }
    }
    public void addLives(int _lives)
    {
        lives += _lives;
        if (lives >= Game.obj.maxLive)
        {
            lives = Game.obj.maxLive;
        }
    }

    private void OnDestroy()
    {
        obj = null;
    }
}
