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
    public Transform player;
    public GameObject fishPrefab;
    public GameObject enemyPrefab;
    public Health playerHealth;
    public float spawnDivisor;
    public float originalSpawnValue;
    public float spawnTimer;
    public int numEnemies;
    void Start()
    {
        spawnDivisor = 1;
        originalSpawnValue = 15;
        spawnTimer = originalSpawnValue;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer >= (originalSpawnValue / spawnDivisor))
        {
            Vector3 dir = Random.insideUnitSphere;
            GameObject spawningEnemy;
            if (Random.value > 0.75f)
            {
                spawningEnemy = Instantiate(fishPrefab, player.transform.position + dir.normalized * 5 + dir * 5, Quaternion.identity);
                spawningEnemy.GetComponent<boomfish>().gm = this;
            }
            else
            {
                spawningEnemy = Instantiate(enemyPrefab, player.transform.position + dir.normalized * 5 + dir * 5, Quaternion.identity);
                spawningEnemy.GetComponent<BasicEnemyScript>().gm = this;
            }
            numEnemies++;
            spawnTimer = 0;
        }
        spawnTimer += Time.deltaTime;
        if (gameOver)
        {
            gameOverText.text = "GAME OVER";
            HPText.text = "HP: 0/20";
        }
        else
        {
            HPText.text = "HP: " + playerHealth.currentHP + "/" + playerHealth.maxHP + '\n' +
                          "Stamina: " + PlayerMovementScript.stamina + "/" + PlayerMovementScript.maxStamina;
        }
    }
    public void GameOver()
    {
        gameOver = true;
    }

    public void EnemyDeath()
    {
        spawnDivisor += 0.1f;
        numEnemies--;
    }
}
