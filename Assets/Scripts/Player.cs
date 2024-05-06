using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rigidBody;
    bool isGrounded;
    public float jumpPower = 100f;
    public float moveSpeed = 100f;
    public float dragValue = 5f;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.drag = dragValue;
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
            rigidBody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.transform.parent.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.transform.parent.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
