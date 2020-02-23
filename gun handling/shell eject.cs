using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{ public Rigidbody rigid;
    public float min=5f;
    public float max=7f;
    // Start is called before the first frame update
    void Start()
    { float force = Random.Range(min, max);
        rigid.AddForce(transform.right * force);
        rigid.AddTorque(Random.insideUnitCircle * force);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
