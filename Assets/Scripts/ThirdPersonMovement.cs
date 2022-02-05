/*
# Unity Game - Bob's Adventure | Ydays Ynov
# Script for third person movement
# Léo Séry ~ 2021
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public Transform groundCheck;
    public LayerMask groundMask;

    public float speed = 5f;
    public float turnSmoothTime = 0.1f;
    public float gravity = -9.81f;
    public float groundDistance = 0.4f;
    public float jumpHeight = 3f;

    private float m_turnSmoothVelocity;
    private Vector3 m_velocity;
    private bool m_isGrounded;
   
    void Start()
    {
        // Uncomment this line to lock the player cursor once the scene is launched
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref m_turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        m_isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (m_isGrounded && m_velocity.y < 0)
            m_velocity.y = -2f;

        if (Input.GetButtonDown("Jump") && m_isGrounded)
            m_velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            
        m_velocity.y += gravity * Time.deltaTime;
        controller.Move(m_velocity * Time.deltaTime);
    }
}