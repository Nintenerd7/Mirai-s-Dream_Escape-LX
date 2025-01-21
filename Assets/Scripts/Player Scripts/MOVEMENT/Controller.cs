using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    public CharacterController controller;
    public float speed = 12f;

    //rigid body
    Vector3 velocity;
    public float Gravity = -9.81f;
    //Ground Check and Jump Variables
    public Transform Ground_Check;
    public float groundDistance = 0.4f;
    public LayerMask GroundLayer;
    public float JumpHeight = 3f;
    bool isOnGround;
 //Dash Variables  
 public bool isDashing = false;
 public float Dashing = 5f; 

 
    // Update is called once per frame
    private void Update()
    {
        isOnGround = Physics.CheckSphere(Ground_Check.position, groundDistance, GroundLayer);//draws a physics collision to check the player is grounded

        if(isOnGround && velocity != null) velocity.y = -2f;//for walking on pro-builder enviorments

        float x = Input.GetAxis("Horizontal");//gets inputs A + D for moving left and right
        float z = Input.GetAxis("Vertical");//Gets inputs W+S for moving up and down
        
        //movement speed calculation 
        Vector3 move = transform.right * x + transform.forward * z;//uses x and z axis for movement direction
        controller.Move(move * speed * Time.deltaTime);//speed is calculated at every frame

        StartCoroutine(Dash());

        //Jumping Mechanic
        if(Input.GetButton("Jump")&& isOnGround)velocity.y = Mathf.Sqrt(JumpHeight -2f * Gravity);//Jump uses velocity to calculate the square route of the force and gravity

        //Gravity Calculation of freefall
        velocity.y += Gravity * Time.deltaTime;//freefall is calculated at every frame
        controller.Move(velocity * Time.deltaTime);
    }

//Dash Enumerator 
    public IEnumerator Dash()//Enumerator for Dash button
    {
      if(!isDashing && Input.GetMouseButtonDown(1))//if player clicks right click
      {
        isDashing = true;//dash is enabled
        speed += Dashing;//dash is added onto speed
        yield return new WaitForSeconds(0.4f);//WAITS FOR 0.4 SECONDS BEFORE SPEED RETURNS TO NORMAL
        speed = 12f;//speed returns to normal
        isDashing = false;//dash is disabled
      }
    }
}