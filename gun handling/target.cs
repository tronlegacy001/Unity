using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    public float health = 100;
    // Start is called before the first frame update
    public void TakeDamage(float amount)
    {
        health -= amount;
        if(health<=0f)
        {
            Destroy(gameObject);
        }
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
