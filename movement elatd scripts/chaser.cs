using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chaser : MonoBehaviour {

    public Transform targettransform;
    float speed = 7;
    // Update is called once per frame
    void Update()
    {
        Vector3 displacement = targettransform.position - transform.position;
        Vector3 dir = displacement.normalized;
        Vector3 velocity = speed * dir;
        Vector3 move = velocity * Time.deltaTime;
        float dist = displacement.magnitude;
        if ( dist > 1.5f)
        {
            transform.position += move;
        }
    }
}
