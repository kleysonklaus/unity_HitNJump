using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public int scoreGive = 30;
    public int liveGive = 1;
    // Start is called before the first frame update
    void Start()
    {
        // en life no se usara
    }

    // Update is called once per frame
    void Update()
    {
        // en life no se usara
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Game.obj.addScore(scoreGive);
            Player.obj.addLives(liveGive);

            AudioManager.obj.playCoin();

            UIManager.obj.updateScore();
            UIManager.obj.updateLives();

            FXManager.obj.showPop(transform.position);
            gameObject.SetActive(false);
        }
    }
}
