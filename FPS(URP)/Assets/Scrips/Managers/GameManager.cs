using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int enemiesAlive = 0;
    public int round = 0;
    public static int score = 0;
    public GameObject[] spawners;
    public GameObject enemyPrefab;
    public GameObject endScreen;
    public Text roundText;
    public Text healthText;
    public Text scoreText;
    public Text FinalscoreText;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemiesAlive == 0)
        {
            round++;
            nextWave(round);
            roundText.text = "Round : " + round.ToString();
        }
        healthText.text = PlayerManager.health.ToString();
        scoreText.text = "Score : " + score.ToString();
        
    }

    public void nextWave(int round)
    {
        for(int i =0; i < round ; i++)
        {
            GameObject spawn = spawners[Random.Range(0, spawners.Length)];
            //Instantiate(enemyPrefab, spawn.transform.position, Quaternion.identity);
            GameObject o = Instantiate(enemyPrefab, spawn.transform.position, Quaternion.identity);
            o.GetComponent<EnimyManager>().GameManager = GetComponent<GameManager>();
            enemiesAlive++;
        }
        
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void endGame()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        endScreen.SetActive(true);
        FinalscoreText.text = "Final Score : " + score.ToString();
    }
}
