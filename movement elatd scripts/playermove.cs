using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{
    Animator zomb;
    public float speed = 6;
    // Rigidbody myr;
    Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        //myr = GetComponent<Rigidbody>();
        zomb = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 dir = input.normalized;
        velocity = dir * speed;
        transform.position += dir * speed * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            zomb.SetTrigger("walk");
        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            zomb.SetTrigger("stop");
        }
        void FixedUpdate()
        {
            //myr.position += velocity * Time.deltaTime;
        }
    }
}