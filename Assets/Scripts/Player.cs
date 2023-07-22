using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpSpeed = 50f;
    [SerializeField] private float maxSpeed = 50f;
    private float xSpeed = 0, zSpeed = 0;

    public static event Action OnDeath;
    public static event Action OnHitGoal;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Input.GetKey("space"))
        {
            rb.AddForce(transform.up * jumpSpeed);
        }

        if (Input.GetKey(KeyCode.RightArrow) & xSpeed < maxSpeed)
        {
            rb.AddForce(new Vector3(moveSpeed,0,0) * moveSpeed);
            xSpeed += moveSpeed;
        }

        if (Input.GetKey(KeyCode.LeftArrow) & xSpeed > -maxSpeed)
        {
            rb.AddForce(new Vector3(-moveSpeed, 0, 0) * moveSpeed);
            xSpeed -= moveSpeed;
        }

        if (Input.GetKey(KeyCode.UpArrow) & xSpeed < maxSpeed)
        {
            rb.AddForce(new Vector3(0, 0, moveSpeed) * moveSpeed);
            zSpeed += moveSpeed;
        }

        if (Input.GetKey(KeyCode.DownArrow) & xSpeed > -maxSpeed)
        {
            rb.AddForce(new Vector3(0, 0, -moveSpeed) * moveSpeed);
            zSpeed -= moveSpeed;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Kills")
        {
            OnDeath?.Invoke();
        }

        if (collision.gameObject.tag == "Goal")
        {
            OnHitGoal?.Invoke();
        }
    }
}
