using UnityEngine;

public class movementforfps : MonoBehaviour
{
    public CharacterController cont;
    public Transform gc;
    public float gd = 0.4f;
    public LayerMask gmask;
    float speed = 10f;
    public float h = 3f;
    public float gravity =-16.5f;
    Vector3 velocity;
    bool isg;
    void FixedUpdate()
    {
        isg = Physics.CheckSphere(gc.position, gd, gmask);
        if (isg && velocity.y < 0)
        {
            cont.slopeLimit = 45.0f;
            velocity.y = -2f;
        }
        float x = Input.GetAxisRaw("Horizontal");
      float y = Input.GetAxisRaw("Vertical");
        Vector3 input = transform.right * x + transform.forward * y;
        Vector3 direction = input.normalized;
       Vector3 v = direction * speed;
        Vector3 moveAmount = v * Time.deltaTime;
        cont.Move(moveAmount);
        if(Input.GetKeyDown(KeyCode.Space)&&isg)
        {
            cont.slopeLimit = 100.0f;
            velocity.y = Mathf.Sqrt(-2f * h * gravity);
        }
        if ((cont.collisionFlags & CollisionFlags.Above) != 0)

        {

            velocity.y = -2f;
        }

            velocity.y += gravity * Time.deltaTime;
        cont.Move(velocity*Time.deltaTime);
    }
}
