using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponswitching : MonoBehaviour
{
    public int weaponhandling = 0;
    // Start is called before the first frame update
    void Start()
    {
        selweapon();
    }

    // Update is called once per frame
    void Update()
    {
        int prevs = weaponhandling;
        if(Input.GetAxis("Mouse ScrollWheel")>0f)
        {   if (weaponhandling >=transform.childCount - 1)
                weaponhandling = 0;
            else
                weaponhandling++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (weaponhandling <= 0)
                weaponhandling = transform.childCount - 1;
            else
                weaponhandling--;
        }
        if(prevs!=weaponhandling)
        {
            selweapon();
        }
    }
    void selweapon()
    {
        int i = 0;
        foreach(Transform w in transform)
        {
            if(i==weaponhandling)
            {
                w.gameObject.SetActive(true);
            }
            else
            {
                w.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
