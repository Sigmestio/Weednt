using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LawnmowerMover : MonoBehaviour
{
    [SerializeField] public float speed = 1.0f;
    [SerializeField] public float maxSpeed = 3.0f;
    public Rigidbody rb;
    [SerializeField] private bool isMoving = false;
    [SerializeField] private LayerMask wall;
    [SerializeField] private LayerMask charger;
    [SerializeField] private LayerMask asphodel;

    //[SerializeField] private AudioSource roombaStart; - podmienic na kosiarke


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
            isMoving = !Physics.CheckSphere(transform.position, 0.1f, wall);
            if (isMoving == false) { rb.velocity = Vector3.zero; }

        }
    }


    public void RotateLawnmower(Vector3 newRotation)
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
                //roombaStart.Play(); tba
            }
        }
    }
    
    public void StopAndCharge()
    {
        isMoving = !Physics.CheckSphere(transform.position, 0.1f, charger);
        if (isMoving == false) { rb.velocity = Vector3.zero; }
        
    }
    
    public void StopAndDie()
    {
        isMoving = !Physics.CheckSphere(transform.position, 0.1f, asphodel);
        if (isMoving == false) { rb.velocity = Vector3.zero; }
    }
}
