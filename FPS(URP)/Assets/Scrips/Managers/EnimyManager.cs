using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnimyManager : MonoBehaviour
{
    public GameObject player;
    public Animator animator;
    public float dmg = 5f;
    public float health = 100f;
    public GameManager GameManager;
    public AudioClip deadClip;
    private uint destroyFlag = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<NavMeshAgent>().destination = player.transform.position;
        if(GetComponent<NavMeshAgent>().velocity.magnitude > 1)
        {
            animator.SetBool("isRunning", true);
        } 
        else
        {
            animator.SetBool("isRunning", false);
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            //animator.SetBool("isRunning", false);
            animator.SetBool("isAttackingBool", true);
            player.GetComponent<PlayerManager>().hit(dmg);
            //Debug.Log("player hit");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            animator.SetBool("isAttackingBool", false);
            //animator.SetBool("isRunning", true);
            
            //Debug.Log("exit");
        }

    }

    public void hit(float dmg)
    {
        
        if (health <= 0)
        {
            if(destroyFlag == 0)
            {
                this.GetComponent<AudioSource>().clip = deadClip;
                this.GetComponent<AudioSource>().Play();
                GameManager.enemiesAlive--;
                animator.SetTrigger("isDead");
                Destroy(this.gameObject, 1);
                destroyFlag = 1;
                GameManager.score += 5;
            }
            
            
        }
        else
        {
            health = health - dmg;
        }
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    //if (collision.gameObject == player)
    //    //{
    //    //    animator.SetBool("isAttackingBool", true);
    //    //    player.GetComponent<PlayerManager>().hit(dmg);
    //    //    Debug.Log("player hit");
    //    //}
    //    if (collision.gameObject == player)
    //    {
    //        animator.SetBool("isRunning", false);
    //        animator.SetBool("isAttackingBool", true);
    //        player.GetComponent<PlayerManager>().hit(dmg);
    //        Debug.Log("player hit");
    //    }
    //}

    //private void OnCollisionExit(Collision collision)
    //{
    //    //animator.SetBool("isAttackingBool", false);
    //    //Debug.Log("exit");
    //    if (collision.gameObject == player)
    //    {
    //        animator.SetBool("isRunning", true);
    //        animator.SetBool("isAttackingBool", false);
    //        Debug.Log("exit");
    //    }
    //}
}
