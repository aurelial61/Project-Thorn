using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public bool gameOver;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI HPText;
    public Health playerHealth;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            gameOverText.text = "GAME OVER";
            HPText.text = "HP: 0/20";
        }
        else
        {
            HPText.text = "HP: " + playerHealth.currentHP + "/" + playerHealth.maxHP;
        }
    }
    public void GameOver()
    {
        gameOver = true;
    }
}
