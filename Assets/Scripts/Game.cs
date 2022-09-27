using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{

    public static Game obj;
    public int maxLive = 3;
    public bool gamePaused = false;
    public int score = 0;

    private void Awake()
    {
        obj = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        gamePaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        // no la utilizaremos para esta clase
    }

    public void addScore(int scoreGive)
    {
        score += scoreGive;
    }

    public void gameOver()
    {
        // reiniciar la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnDestroy()
    {
        obj = null;
    }
}
