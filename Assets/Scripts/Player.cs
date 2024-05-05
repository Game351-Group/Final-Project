using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rigidBody;
    bool isGrounded;
    public float jumpPower = 1500f;
    public float moveSpeed = 5f;
    public float dragValue = 5f;

    void Awake()
    {

        rigidBody = GetComponent<Rigidbody>();
        rigidBody.drag = dragValue;
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 vec = new Vector3(h, 0, v) * moveSpeed * Time.deltaTime;
        rigidBody.AddForce(vec, ForceMode.Impulse);

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
