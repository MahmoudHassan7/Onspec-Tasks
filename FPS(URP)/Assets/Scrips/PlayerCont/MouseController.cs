using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{

    public float mouseSpeed = 100f;
    public Transform playerTrans;
    public float clamp = 0f;
    float mouseX, mouseY;

    // Start is called before the first frame update
    void Start()
    {
        // make mouse dose not leave game window
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // get mouse inputs from InputManger
        mouseX = Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSpeed * Time.deltaTime;

        // use clamping consept to make it realistec
        clamp -= mouseY;
        clamp = Mathf.Clamp(clamp, -75, 75);
        transform.localRotation = Quaternion.Euler(clamp, 0, 0);
        playerTrans.Rotate(Vector3.up * mouseX);
        

    }
}
