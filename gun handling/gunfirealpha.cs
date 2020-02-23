using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gunfirealpha : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float hr = 15f;
    public Camera fps;
    public ParticleSystem p;//muzzle flash controller
    /// </summary>
    public GameObject impacteff;//impact on ground
    //AudioClip aud=transform.GetComponent<AudioSource>();
    // Start is called before the first frame update
    private float next = 0f;
    AudioSource bulletaud;//gunshot
    public float bulletSpeed = 1100;
    public GameObject bullet;
    public GameObject bs;//bullet spawn
    public float reloadt = 1f;//reload time
    public int currentammo;
    private bool isreloading = false;
    AudioSource reloadings;
    public Animator anim;
    public Text gunui;
    public int ammo = 10;//max ammo
    void Start()
    {
        bulletaud = GetComponent<AudioSource>();
        reloadings = GetComponent<AudioSource>();
            currentammo = ammo;
        
    }
    private void OnEnable()
    {
        isreloading = false;
        anim.SetBool("reloading", false);
    }

    // Update is called once per frame
    void Update()
    {if(isreloading)
        {
            return;
        }
        if (currentammo<=0)
        {
            StartCoroutine(reload());
            return;
        }
        if (Input.GetButton("Fire1") && Time.time >= next)
        {
            next = Time.time + (1 / hr);
            p.Play();
            shoot();
            Fire();
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(reload());
            return;
        }
        gunui.text = currentammo.ToString() + '/' + ammo.ToString();

    }
    IEnumerator reload()
    {
        Debug.Log(isreloading);
        isreloading = true;
        Debug.Log("reloading");
        anim.SetBool("reloading", true);
        //reloadings.Play();
        yield return new WaitForSeconds(reloadt-0.25f);
        anim.SetBool("reloading", false);
        yield return new WaitForSeconds(0.25f);
        currentammo = ammo;
        isreloading = false;
        Debug.Log(isreloading);
    }
    void shoot()
    {
        //p.Play();
        RaycastHit hit;
        if (Physics.Raycast(fps.transform.position, fps.transform.forward, out hit, range))
        {
           
            Debug.Log(hit.transform.name);
            target t = hit.transform.GetComponent<target>();
            if (t != null)
            {
                t.TakeDamage(damage);
            }
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddExplosionForce(5f, hit.point, 1f);
            }
        }
        GameObject eff = Instantiate(impacteff, hit.point, Quaternion.LookRotation(hit.normal));
        //eff.GetComponent<ParticleSystem>().Play();
        Destroy(eff,2f);
    }
    void Fire()
    {
        currentammo--;
        //Shoot
        GameObject tempBullet = Instantiate(bullet,bs.transform.position, transform.rotation) as GameObject;
        Rigidbody tempRigidBodyBullet = tempBullet.GetComponent<Rigidbody>();
        tempRigidBodyBullet.AddForce(tempRigidBodyBullet.transform.forward * bulletSpeed);
        Destroy(tempBullet, 0.5f);

        //Play Audio
        bulletaud.Play();

    }
}
