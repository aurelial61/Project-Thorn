using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public bool gameOver;
    public TextMeshProUGUI gameOverText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            gameOverText.text = "GAME OVER";
        }
    }
    public void GameOver()
    {
        gameOver = true;
    }
}
