using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject firePoint;
    public float dmg = 35f;
    public Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerAnimator.GetBool("isShooting"))
        {
            playerAnimator.SetBool("isShooting", false);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot(dmg);
        }
    }

    void Shoot(float dmg)
    {
        this.GetComponent<AudioSource>().Play();
        playerAnimator.SetBool("isShooting", true);
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 7;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(firePoint.transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            //Debug.DrawRay(firePoint.transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green,3);
            
            if(hit.transform.gameObject.layer == 8)
            {
                EnimyManager e = hit.transform.GetComponent<EnimyManager>();
                e.hit(dmg);
                //Debug.Log("Did Hit 25 dmg");
            }
        }
        //else
        //{
        //    Debug.DrawRay(firePoint.transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.red,3);
        //    //Debug.Log("Did not Hit");
        //}
    }
}
