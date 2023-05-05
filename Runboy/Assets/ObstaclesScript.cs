using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesScript : MonoBehaviour
{
    public GameObject spike;
    public GameObject monster;
    public GameObject coin;

    public float obstaclesRate = 5;
    private float obstaclesTimer = 0;
    private float[] coinHights = new float[] { 3, 3.2f, 3.5f, 4 };
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (obstaclesTimer < obstaclesRate)
        {
            obstaclesTimer += Time.deltaTime;
        }
        else
        {
            CreateObstacles();
            obstaclesTimer = 0;
        }
    }

    void CreateObstacles()
    {
        GameObject[] obstacles = new GameObject[] { spike, monster };

        Instantiate(obstacles[Random.Range(0, 2)], transform.position + new Vector3(0, 2.2f, 0), transform.rotation);
        Instantiate(coin, transform.position + new Vector3(0, coinHights[Random.Range(0, 4)], 0), transform.rotation);

    }
}
