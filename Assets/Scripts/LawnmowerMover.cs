using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LawnmowerMover : MonoBehaviour
{
    [SerializeField] public float speed = 1.0f;
    [SerializeField] public float maxSpeed = 3.0f;
    public Rigidbody rb;
    [SerializeField] private bool isMoving = false;
    [SerializeField] private LayerMask Wall;

    //[SerializeField] private AudioSource roombaStart; - podmieniæ na kosiarke


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            rb.AddForce(transform.forward * speed, ForceMode.VelocityChange);
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
            isMoving = !Physics.CheckSphere(transform.position, 0.1f, Wall);
            if (isMoving == false) { rb.velocity = Vector3.zero; }

        }
    }


    public void RotateRoomba(Vector3 newRotation)
    {
        rb.velocity = Vector3.zero;
        rb.isKinematic = true;
        rb.transform.forward = newRotation;
        rb.isKinematic = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isMoving)
            {
                isMoving = true;
                //roombaStart.Play();
            }
        }
    }
}
