using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rigidBody;
    bool isJump;
    public float jumpPower = 1500f;
    public float moveSpeed = 5f;
    public float dragValue = 5f; // 추가: 가속도를 없애기 위한 drag 값

    void Awake()
    {
        isJump = false;
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.drag = dragValue; // 추가: 가속도를 없애기 위해 drag 값을 설정
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 vec = new Vector3(h, 0, v) * moveSpeed * Time.deltaTime; // 수정: 속도를 조절하기 위해 moveSpeed를 곱함
        rigidBody.AddForce(vec, ForceMode.Impulse);

        if (Input.GetButtonDown("Jump") && !isJump)
        {
            isJump = true;
            rigidBody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.parent.CompareTag("Ground"))
        {
            isJump = false;
        }
    }
}
