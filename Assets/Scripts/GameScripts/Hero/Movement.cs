using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
    [SerializeField] private InputSubscription GetInput;
    [SerializeField] private float speed=10f;
    [SerializeField] private float smoothTime=0.3f;
    private Rigidbody rb;
    private Vector3 PlayerMovement;
    private Vector3 currentVelocity;
    private Vector2 currentInputVector;
    private Vector2 smoothInputVelocity;

    void Start()
    {
        rb= GetComponent<Rigidbody>();
    }

    void Update()
    {
        PlayerMovement = new Vector2(GetInput.MoveInput.x, GetInput.MoveInput.y);
        currentInputVector= Vector2.SmoothDamp(currentInputVector,PlayerMovement,ref smoothInputVelocity,smoothTime);

    }
    private void FixedUpdate()
    {
         rb.velocity = new Vector3(currentInputVector.x, 0, currentInputVector.y) * speed;
    }
}
