using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager obj;
    public Text livesLabel;
    public Text scoreLabel;

    public Transform UIPanel;

    private void Awake()
    {
        obj = this;
    }

    public void updateLives()
    {
        livesLabel.text = "" + Player.obj.lives;
    }
    public void updateScore()
    {
        scoreLabel.text = "" + Game.obj.score;
    }

    public void starGame()
    {
        AudioManager.obj.playGui();

        Game.obj.gamePaused = true;

        UIPanel.gameObject.SetActive(true);
    }

    public void hideInitPanel()
    {
        AudioManager.obj.playGui();
        Game.obj.gamePaused = false;
        UIPanel.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        obj = null;
    }
}
