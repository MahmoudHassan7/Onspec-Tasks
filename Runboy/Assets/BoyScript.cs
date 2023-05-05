using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyScript : MonoBehaviour
{
    public Rigidbody2D boyRigidbody;
    public Animator boyAnimator;
    public LogicScript logic;
    
    public float jumpPower;
    public float jumpOffset;
    private int keyDownLimiter = 0;
    private bool lose = false;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        boyAnimator.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = new Quaternion(0, 0, 0, 0);
      
        if (keyDownLimiter < 1 && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && !lose)
        {
            boyRigidbody.velocity = Vector2.up * jumpPower;
            boyAnimator.enabled = true;
            keyDownLimiter++;
        }
        

        if (transform.position.y > jumpOffset)
        {
            boyAnimator.enabled = false;
        }
        else if (!lose)
        {
            boyAnimator.enabled = true;
            keyDownLimiter = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Spike(Clone)" || collision.gameObject.name == "Monster(Clone)")
        {
            boyAnimator.enabled = false;
            logic.gameOver();
            lose = true;
        }
    }
}
