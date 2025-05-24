using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;
    public float runSpeed = 9f;
    public bool canRun = true;
    public bool isRunning;
    float targetSpeed;
    public KeyCode runKey = KeyCode.LeftShift;
    Rigidbody rb;
    void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        isRunning = canRun && Input.GetKey(runKey);
        targetSpeed = isRunning ? runSpeed : speed;
        rb.velocity = transform.rotation * new Vector3(Input.GetAxis("Horizontal"), rb.velocity.y, Input.GetAxis("Vertical") * targetSpeed);
        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * (100f * Time.deltaTime), Space.Self);
    }
}
