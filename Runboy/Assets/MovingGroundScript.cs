using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingGroundScript : MonoBehaviour
{
    public GameObject ground;
    public LogicScript logic;

    public float generatingRate = 2;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        Instantiate(ground, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < logic.movingSpeed)
        {
            timer += Time.deltaTime;
        }
        else
        {
            Instantiate(ground, transform.position, transform.rotation);
            timer = 0;
        }
        
    }
}
