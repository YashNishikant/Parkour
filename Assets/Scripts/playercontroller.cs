using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playercontroller : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private Camera cam;
    [SerializeField] private bool grounded;
    [SerializeField] private float jumpStrength;
    [SerializeField] private Rigidbody playerrigidbody;


    Vector3 moveVec1;
    Vector3 moveVec2;
    
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    private void Update()
    {
        movement();
        jump();
        jumpcheck();
        deathCheck();
    }

    void deathCheck() {

        if (transform.position.y < -30f) {
            transform.position = new Vector3(0, 10f, 0);

            playerrigidbody.constraints = RigidbodyConstraints.FreezePosition;
        }

        playerrigidbody.constraints = RigidbodyConstraints.None;
    }

    void jumpcheck() {

        if (Physics.Raycast(transform.position, Vector3.down, 1.1f))
        {
            grounded = true;
        }
        else {
            grounded = false;
        }
    }

    void jump() {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            transform.gameObject.GetComponent<Rigidbody>().AddForce(0, jumpStrength * Time.fixedDeltaTime, 0, ForceMode.Impulse);
        }
    }

    void movement() {

        if (grounded)
        {

            if (Input.GetKey(KeyCode.W))
            {
                moveVec1 = new Vector3(cam.transform.forward.x, 0f, cam.transform.forward.z);
                transform.gameObject.GetComponent<Rigidbody>().AddForce(moveVec1 * Time.fixedDeltaTime * speed, ForceMode.Impulse);
            }



            if (Input.GetKey(KeyCode.S))
            {
                moveVec2 = new Vector3(-cam.transform.forward.x, 0f, -cam.transform.forward.z);
                transform.gameObject.GetComponent<Rigidbody>().AddForce(moveVec2 * Time.fixedDeltaTime * speed, ForceMode.Impulse);
            }



            if (Input.GetKey(KeyCode.A))
            {
                transform.gameObject.GetComponent<Rigidbody>().AddForce(-cam.transform.right.normalized * Time.fixedDeltaTime * speed, ForceMode.Impulse);
            }



            if (Input.GetKey(KeyCode.D))
            {
                transform.gameObject.GetComponent<Rigidbody>().AddForce(cam.transform.right.normalized * Time.fixedDeltaTime * speed, ForceMode.Impulse);
            }

        }
    }
}
