using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Access UI of unity to handel screen
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    int coins = 0;

    // handle coins counter in the UI
    [SerializeField] Text coinsText;

    // add sound of collect coins
    [SerializeField] AudioSource collectionSound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coins++;
            Debug.Log("Coins added");
            // connect them using drag and drop in unity
            coinsText.text = "Coins: " + coins;
            collectionSound.Play();
        }
    }
}
