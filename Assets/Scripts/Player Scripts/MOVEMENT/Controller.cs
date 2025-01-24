using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class Controller : MonoBehaviour
{


    public float BaseSpeed = 10f;
    public float Speed { 
      get {
        if (isDashing) {
          return BaseSpeed + Dashing;
        } else {
          return BaseSpeed;
        } 
      } 
    }
    public float JumpHeight = 3f;
    //Dash Variables  
    public bool isDashing = false;
    public float Dashing = 10f; 
    private Vector3 _movementVector = Vector3.zero;
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
        _movementVector = x * transform.right + z * transform.forward;//uses x and z axis for movement direction

        if (Input.GetMouseButtonDown(1) && !isDashing)//if player clicks right click
          StartCoroutine(Dash());
    }

    private void FixedUpdate()
    {
      rb.MovePosition(transform.position + Speed * Time.deltaTime * new Vector3(_movementVector.x, 0, _movementVector.z));//speed is calculated at every frame

    }

  private bool GameobjectIsGroundLayer(GameObject go) {
      return go.layer == LayerMask.NameToLayer("Ground");
    }

    public void OnCollisionStay(Collision collision)
      {
        if (GameobjectIsGroundLayer(collision.gameObject))//if player is on ground
        {
          if (Input.GetButton("Jump"))//if player presses space
            rb.AddForce(Vector3.up * JumpHeight, ForceMode.Impulse);//player jumps
        }
      }


    //Dash Enumerator 
      public IEnumerator Dash()//Enumerator for Dash button
      {
        isDashing = true;//dash is enabled
        yield return new WaitForSeconds(0.4f);//WAITS FOR 0.4 SECONDS BEFORE SPEED RETURNS TO NORMAL
        isDashing = false;//dash is disabled
      }
}