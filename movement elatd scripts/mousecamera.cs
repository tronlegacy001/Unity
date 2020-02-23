using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousecamera : MonoBehaviour
{
    public float ms = 100f;
    public Transform body;
    float xR = 0;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mX = Input.GetAxis("Mouse X") * ms * Time.deltaTime;
        float mY = Input.GetAxis("Mouse Y") * ms * Time.deltaTime;
        xR -= mY;
        xR = Mathf.Clamp(xR, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xR, 0f, 0f);
        body.Rotate(Vector3.up*mX);
    }
}
