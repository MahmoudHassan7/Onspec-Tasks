using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static float health;

    public GameManager gameManager;

    private void Start()
    {
        health = 100f;
    }
    public void hit(float dmg)
    {
        health -= dmg;

        if (health <= 0)
        {
            gameManager.endGame();
        }
    }
}
