using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunfire : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float hr = 15f;
    public Camera fps;
    public ParticleSystem p;
    public GameObject impacteff;
    //AudioClip aud=transform.GetComponent<AudioSource>();
    // Start is called before the first frame update
    private float next = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1")&&Time.time>=next)
        {
            next = Time.time + (1 / hr);
            shoot();
        }
    
    }
    void shoot()
    {
        p.Play();
        RaycastHit hit;
        if(Physics.Raycast(fps.transform.position, fps.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            target t = hit.transform.GetComponent<target>();
            if (t != null)
            {
                t.TakeDamage(damage);
            }
            if(hit.rigidbody!=null)
            {
                hit.rigidbody.AddExplosionForce(5f, hit.point, 1f);
            }
            }
        GameObject eff=Instantiate(impacteff,hit.point,Quaternion.LookRotation(hit.normal));
        Destroy(eff, 2f);
    }
}
