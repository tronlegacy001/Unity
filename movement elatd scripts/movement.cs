﻿using UnityEngine;

public class movement : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }
    float speed = 10;
    // Update is called once per frame
    void Update()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 direction = input.normalized;
        Vector3 velocity = direction * speed;
        Vector3 moveAmount = velocity * Time.deltaTime;
        transform.position += moveAmount;
    }
}
