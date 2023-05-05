using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    public float outOfCame = -13;
    
    public LogicScript logic;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3.left * logic.movingSpeed) * Time.deltaTime;

        if (transform.position.x < outOfCame)
        {
            Destroy(gameObject);
        }
    }
}
