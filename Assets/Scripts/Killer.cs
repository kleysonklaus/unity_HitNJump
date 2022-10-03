using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // no se usara
    }

    // Update is called once per frame
    void Update()
    {
        // no se usara
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FXManager.obj.showPop(transform.position);
            Game.obj.gameOver();
        }
    }
}
