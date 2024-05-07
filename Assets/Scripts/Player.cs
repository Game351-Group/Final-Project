using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rigidBody;
    private bool isGrounded;
    private bool isCloud;
    public float jumpPower = 100f;
    public float moveSpeed = 100f;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MovePlayer();
        Jump();
    }

    // Character will move based on cam's location
    private void MovePlayer()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;
        cameraForward.y = 0;
        cameraRight.y = 0;
        cameraForward.Normalize();
        cameraRight.Normalize();

        Vector3 direction = (cameraForward * v + cameraRight * h).normalized;

        Vector3 moveVector = direction * moveSpeed * Time.deltaTime;
        rigidBody.AddForce(moveVector, ForceMode.Impulse);

        if (direction != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(direction);
            rigidBody.rotation = Quaternion.Slerp(rigidBody.rotation, newRotation, Time.deltaTime * 10);
        }
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            if(isCloud){
                rigidBody.AddForce(Vector3.up * jumpPower * 2f, ForceMode.Impulse);
            }else{
                rigidBody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            }
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.transform.parent.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        
        if(collision.transform.parent.name == "Clouds"){
            isCloud = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.transform.parent.CompareTag("Ground"))
        {
            isGrounded = false;
        }

        if(collision.transform.parent.name == "Clouds"){
            isCloud = false;
        }
    }
}
