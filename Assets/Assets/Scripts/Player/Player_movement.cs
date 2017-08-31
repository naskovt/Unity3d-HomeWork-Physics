using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System;

public class Player_movement : MonoBehaviour {

    private Vector3 horizontalVector;
    private Vector3 verticalVector;
    private Vector3 rotateVector;
    private Rigidbody rb;
    private bool isPlayerOnGround = true;

    public GameObject player;
    public Camera cameraObject;
    public float movingSpeed = 1;
    public float rotationSpeed = 1;
    public float jumpPower = 2f;


    void Start()
    {
        rb = GetComponentInChildren<Rigidbody>();
    }

    void Update() {

        #region Rotation vector

        rotateVector = new Vector3(Input.GetAxisRaw("Mouse Y"), Input.GetAxisRaw("Mouse X"), 0);

        #endregion

        #region Creating vectors for moving forward/backward

            if (Input.GetKey("up") || Input.GetKey("w"))
            {
                verticalVector = transform.forward;
            }
            else if(Input.GetKey("down") || Input.GetKey("s"))
            {
                verticalVector = -transform.forward;
            }
            else
            {
                verticalVector = Vector3.zero;
            }

        #endregion

        #region Creating vectors for moving left/right

            if (Input.GetKey("left") || Input.GetKey("a"))
            {
                horizontalVector = -transform.right;
            }
            else if (Input.GetKey("right") || Input.GetKey("d"))
            {
                horizontalVector = transform.right;
            }
            else
            {
                horizontalVector = Vector3.zero;
            }

        #endregion
    }

    private void Jump()
    {
        //check if the player touches the ground in order to disable jumping in air
        if (isPlayerOnGround)
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }

    void FixedUpdate () {

        #region Jump listen

        if (Input.GetKeyDown("space"))
        {
            Jump();
        }

        #endregion

        var movingVector = (verticalVector + horizontalVector) * Time.deltaTime * movingSpeed;

        // check if slow motion is enabled and speed up the player
        if (Time.timeScale < 1)
        {
            movingVector *= 4;    
        }

        //move player to sides
        rb.MovePosition(movingVector + transform.position);

        //rotate player left/right
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, rotateVector.y * rotationSpeed, 0));

        //rotate camera up/down
        cameraObject.transform.Rotate(new Vector3(-rotateVector.x * rotationSpeed, 0, 0));
    }

    private void OnCollisionExit(Collision collision)
    {

        if (collision.collider.tag == "ground")
        {
            isPlayerOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "ground")
        {
            isPlayerOnGround = true;
        }
    }
}
