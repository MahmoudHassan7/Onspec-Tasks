using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// add new scene
using UnityEngine.SceneManagement;


public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
