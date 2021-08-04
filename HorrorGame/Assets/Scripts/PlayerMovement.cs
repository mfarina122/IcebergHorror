using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    public CharacterController controller;

    [SerializeField]
    public float speed = 0f;
    [SerializeField]
    public float gravity = -9.81f;

    [SerializeField]
    Vector3 velocity;
    [SerializeField]
    public float slowSpeed = 12f;
    [SerializeField]
    public float normalSpeed = 25f;
    [SerializeField]
    public float fastSpeed = 50f;
    [SerializeField]
    public Transform groundCheck;
    [SerializeField]
    public float groundDistance = 0.4f;
    [SerializeField]
    public LayerMask groundMask;
    [SerializeField]
    bool isGrounded;
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (Input.GetKey(KeyCode.LeftControl))
        {
            speed = slowSpeed;
            Debug.Log("Sto andando a " + speed + " km/h");
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = fastSpeed;
            Debug.Log("Sto andando a " + speed + " km/h");
        }
        if(!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.LeftControl))
        {
            speed = normalSpeed;
            Debug.Log("Sto andando a " + speed + " km/h");
        }
        
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
       
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
