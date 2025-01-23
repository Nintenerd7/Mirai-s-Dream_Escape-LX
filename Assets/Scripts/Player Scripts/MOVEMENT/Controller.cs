using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class Controller : MonoBehaviour
{

    public float speed = 120f;
    public float JumpHeight = 3f;
    //Dash Variables  
    public bool isDashing = false;
    public float Dashing = 5f; 
    private Rigidbody rb;

    void Awake() {
        rb = GetComponent<Rigidbody>();
    }
 
    // Update is called once per frame
    private void Update()
    {
        float x = Input.GetAxis("Horizontal");//gets inputs A + D for moving left and right
        float z = Input.GetAxis("Vertical");//Gets inputs W+S for moving up and down
        
        //movement speed calculation 
        Vector3 move = transform.right * x * speed + transform.forward * z * speed;//uses x and z axis for movement direction
        rb.velocity = new Vector3(move.x, rb.velocity.y, move.z);//speed is calculated at every frame

        if (Input.GetMouseButtonDown(1) && !isDashing)//if player clicks right click
          StartCoroutine(Dash());
    }

    public void OnCollisionStay(Collision collision)
    {
      Debug.Log("Collided with: " + collision.gameObject.name);
        int groundLayer = LayerMask.NameToLayer("Ground");
      if (collision.gameObject.layer == groundLayer)//if player is on ground
      {
        if (Input.GetButton("Jump"))//if player presses space
          rb.AddForce(Vector3.up * JumpHeight, ForceMode.VelocityChange);//player jumps
      }
    }

  //Dash Enumerator 
    public IEnumerator Dash()//Enumerator for Dash button
    {
      isDashing = true;//dash is enabled
      speed += Dashing;//dash is added onto speed
      yield return new WaitForSeconds(0.4f);//WAITS FOR 0.4 SECONDS BEFORE SPEED RETURNS TO NORMAL
      speed = 12f;//speed returns to normal
      isDashing = false;//dash is disabled
    }
}