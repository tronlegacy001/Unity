using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timer : MonoBehaviour
{ public int count=20;
    public GameObject panel;
    public GameObject player;
    move m;
    // Start is called before the first frame update
    void Start()
    {
        m = player.GetComponent<move>();
        Counter();
    }
    void Counter()
    {if(count>0)
        {
            count--;
            Invoke("Count", 1.0f);
        }
        else
        {
            m.panel.SetActive(true);
           
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
