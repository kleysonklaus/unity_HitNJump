using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    public int scoreGive = 100;

    // Start is called before the first frame update
    void Start()
    {
        // no se usa
    }

    // Update is called once per frame
    void Update()
    {
        // no se usa
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Game.obj.addScore(scoreGive);

            AudioManager.obj.playCoin();

            UIManager.obj.updateScore();

            // antes de que se destruya se muestra el pop
            FXManager.obj.showPop(transform.position);
            gameObject.SetActive(false);
        }
    }
}
