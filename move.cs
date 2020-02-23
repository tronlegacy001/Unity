using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class move : MonoBehaviour
{
    Rigidbody rig;
    float speed = 10f;
    public Text txt;
    int score = 00000000;
    public int jf;
    bool isgameover = false;
    public GameObject panel;
    AudioSource aud;
    public static int timer = 100;
    public Text time;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        aud = GetComponent<AudioSource>();
        timers();

    }

    // Update is called once per frame
    void Update()
    {
        if (!isgameover)
        {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");
            Vector3 move = new Vector3(y, 0, -x);
            Vector3 move1 = move.normalized;
            rig.AddForce(move1 * speed);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rig.AddForce(Vector3.up * jf);
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "coins")
        {
            aud.Play();
            Destroy(other.gameObject);
            score += 1;
            txt.text = "Score:" + score;
        }
        if(other.gameObject.tag=="enemy")
        {
            isgameover = true;
            rig.velocity=Vector3.zero;
            rig.isKinematic = true;
            
            panel.SetActive(true);

        }


    }
    public void timers()
    {
        if(timer<0)
        {
            time.color = Color.red;
            isgameover = true;
            rig.velocity = Vector3.zero;
            rig.isKinematic = true;
            panel.SetActive(true);
        }
        else
        {
            TimeSpan t = TimeSpan.FromSeconds(timer);
            timer--;
            time.text= t.Minutes + ":" + t.Seconds;
            Invoke("timers",1f);
        }
    }
    public void Bc()
    {
        SceneManager.LoadScene("practise");
    }
}
