using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    public float movHor = -1f;
    public float speed = 1f;

    public bool isGrundedFloor = true;
    public bool isGrundedfront = false;

    public LayerMask groundLayer;
    public float frontGrndRayDist = 0.25f;

    public float floorCheckY = 0.52f;
    public float frontCheck = 0.51f;
    public float frontDist = 0.001f;
    public int scoreGive = 50;

    private RaycastHit2D hit;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // groundLayer = GetComponent<LayerMask>();
    }

    // Update is called once per frame
    void Update()
    {
        // evitar caer precipicio
        isGrundedFloor = Physics2D.Raycast(
            new Vector3(transform.position.x, transform.position.y - floorCheckY, transform.position.z),
            new Vector3(movHor, 0, 0),
            frontGrndRayDist,
            groundLayer
        );

        if (!isGrundedFloor)
        {
            movHor = movHor * -1;
        }

        // choque con pared
        if (Physics2D.Raycast(transform.position, new Vector3(movHor, 0, 0), frontCheck, groundLayer))
        {
            movHor = movHor * -1;
        }
        // choque con otro enemigo
        hit = Physics2D.Raycast(
            new Vector3(transform.position.x + movHor * frontCheck, transform.position.y, transform.position.z),
            new Vector3(movHor, 0, 0), frontDist
        );

        if (hit != null)
            if (hit.transform != null)
                if (hit.transform.CompareTag("Enemy")) movHor = movHor * -1;

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(movHor * speed, rb.velocity.y);
    }

    private void getKilled()
    {
        gameObject.SetActive(false);
    }
}
