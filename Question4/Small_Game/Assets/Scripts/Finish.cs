using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// add next level scence
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    // add sound of finishing phase
    [SerializeField] AudioSource finishingSound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            finishingSound.Play();

            // freeze player
            other.GetComponent<Rigidbody>().isKinematic = true;
            other.GetComponent<MeshRenderer>().enabled = false;
            other.GetComponent<Player_Movement>().enabled = false;

            Invoke(nameof(LoadNewLlvl), 1f);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    void LoadNewLlvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
