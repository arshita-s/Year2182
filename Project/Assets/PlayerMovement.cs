using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public Animator anim;
    public RuntimeAnimatorController walk;
    public RuntimeAnimatorController idle;
    public RuntimeAnimatorController sprint;
    public RuntimeAnimatorController jump;
    public bool isSprinting = false;
    public Rigidbody body;

    public float speed = 6f;

    public float turnSmoothTime = 0.1f;
    public float gravity = 8;
    private float turnSmoothVelocity;
    public float jumpSpeed = 10f;
    public bool isJumping = false;
    public float vspeed = 0f;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        // When the player wants to move
        if (direction.magnitude >= 0.1f)
        {
            // Adjust the angle of the avatar based on the camera
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);

            // Sprinting logic
            if (Input.GetMouseButtonDown(1))
            {
                if (!isSprinting)
                {
                    isSprinting = true;
                }
                else
                {
                    isSprinting = false;
                }
            }

            if (isSprinting)
            {
                anim.runtimeAnimatorController = sprint as RuntimeAnimatorController;
                speed = 11;
            }
            else
            {
                anim.runtimeAnimatorController = walk as RuntimeAnimatorController;
                speed = 6;
            }
        }
        else
        {
            anim.runtimeAnimatorController = idle as RuntimeAnimatorController;
        }
        if(controller.isGrounded)
        {
            vspeed = -1;
            if(Input.GetKeyDown(KeyCode.Space))
            {
                anim.runtimeAnimatorController = jump as RuntimeAnimatorController;
                vspeed = jumpSpeed;
            }
        }
        vspeed -= gravity * Time.deltaTime;
        direction.y = vspeed;
        controller.Move(direction * Time.deltaTime);
    }
}