using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    //public Text scoreText;
    private int score;
    public float jumpVal;
    public float rotationSpeed;
    //public Animator anim;
    //public Animator danim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        score = 0;
        //ScoreText();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Movement
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        //Rotation
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * -rotationSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.down * Time.deltaTime * -rotationSpeed);
        }
        //jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpVal, ForceMode.Impulse);
        }

        /*
        //Animation for movement
        //forward
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("walkf", true);
        }
        //back
        else if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("walkb", true);
        }
        //idle
        else
        {
            anim.SetBool("walkf", false);
            anim.SetBool("walkb", false);
        }
        //left
        if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("walkl", true);
        }
        //right
        else if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("walkr", true);
        }
        //idle
        else
        {
            anim.SetBool("walkl", false);
            anim.SetBool("walkr", false);
        }

        //Door anim
        if(score == 3)
        {
            danim.SetInteger("score", 3);
        }
        */
    }

   
}

