using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody rigidBody;
    bool isJump;
    public float jumpPower;
    public float impulseForce = 170000.0f;
    public float impulseTorque = 3000.0f;
    void Awake()
    {
        isJump = false;
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 input = new Vector3(0, Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (input.magnitude > 0.001)
        {
            rigidBody.AddRelativeTorque(new Vector3(0, input.y * impulseTorque * Time.deltaTime, 0));
            rigidBody.AddRelativeForce(new Vector3(0, 0, input.z * impulseForce * Time.deltaTime));
        }

        if(Input.GetButtonDown("Jump") && !isJump){
            isJump = true;
            rigidBody.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
        }
    }
}
