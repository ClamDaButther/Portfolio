using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public bool isGrounded;
    public bool invertedWalking;

    [SerializeField]
    private float speed;
    [SerializeField]
    private float Jump;

    AudioSource Jump1s;

    void Start()
    {
        Jump1s = GetComponent<AudioSource>();
    }

    void Update()
    {
        //controlls
        if (Input.GetKey("a"))
        {
            if(invertedWalking)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
            if(invertedWalking == false)
            {
                transform.position += Vector3.forward * speed * Time.deltaTime;
            }       
        }
        if (Input.GetKey("d"))
        {
            if(invertedWalking)
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
            if (invertedWalking == false)
            {
                transform.position += Vector3.back * speed * Time.deltaTime;
            }
            
        }
        //Jumping
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded || transform.position.y == 1)
            {
                GetComponent<Rigidbody>().AddForce(Vector3.up * Jump);
                Jump1s.Play();
            }
        }

        //Player turns at ..., and walking directions switches
        if (transform.position.z > 47.9f && transform.position.z < 48.1f && transform.position.y < 4.0f && transform.position.y >= 1.0f)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
            invertedWalking = true;
        }
    }
  
    //Collision detection
    void OnCollisionEnter()
    {
        isGrounded = true;
    }

    void OnCollisionExit()
    {
        isGrounded = false;
    }

}
