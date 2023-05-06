using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// access unity scences
using UnityEngine.SceneManagement;


public class PlayerLife : MonoBehaviour
{
    public bool dead = false;


    // add sound of Player Dead
    [SerializeField] AudioSource deathSound;

    // Game over Panel
    [SerializeField] GameObject GameOverScreen;

    private void Start()
    {
        // Hide the game over object at the start of the game
        if (GameOverScreen != null)
        {
            GameOverScreen.SetActive(false);
        }
    }

    private void Update()
    {
        //Debug.Log(dead);
        // if player fall from the surface
        if (transform.position.y < 0.01f && !dead)
        {
            Die();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Body"))
        {
            Die();
        }
    }


    void Die()
    {
        Debug.Log("Player Died");
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Player_Movement>().enabled = false;
        dead = true;

        // sound 
        deathSound.Play();

        // show game over screen
        GameOverScreen.SetActive(true);

        // we want to wait to call methed, so using a delayer 1.3 seconds
        //Invoke(nameof(ReloadLevel), 1.3f);
    }


    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // GAME OVER settings
    public void PlayAgainBtn()
    {
        ReloadLevel();
    }

    public void GameQuitBtn()
    {
        Application.Quit();
    }
}
