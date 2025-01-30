using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    //LOOK SCRIPT: Calculates the camera movement when moving the mouse in first person
    public float mouseSense = 100f;//tracks mouse sensitivity 
    public Transform playerBody;//tracks player movement 


    float X_Rotation;//calculate the horizontal rotation of the camera

    void Start()
    {
            Cursor.lockState = CursorLockMode.Locked;//locks cursor onto game screen
            Cursor.visible = false; //cursor is not visible
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();
       if (PauseMenu.IsPaused)//if the game is paused 
       {

           Cursor.lockState = CursorLockMode.None;//unlock cursor
            Cursor.visible = true;//mouse is visible
       }

    }

    public void MoveCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSense * Time.deltaTime;//allows the player to control the camera sideways 
        float mouseY = Input.GetAxis("Mouse Y") * mouseSense * Time.deltaTime;//allows the player to control the camera Upwards
        //calculation for X and Y camera rotation
        X_Rotation -= mouseY;
        X_Rotation = Mathf.Clamp(X_Rotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(X_Rotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);
    }

}
