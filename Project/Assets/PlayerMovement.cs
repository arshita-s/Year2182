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
    public float isSprinting = 0;

    public float speed = 6f;

    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
           
            if(Input.GetMouseButtonDown(1))
            {
                if(isSprinting == 0)
                {
                    isSprinting = 1;
                }
                else
                {
                    isSprinting = 0;
                }
            }

            if(isSprinting == 1)
            {
                anim.runtimeAnimatorController = sprint as RuntimeAnimatorController;
                speed = 9;
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

    }
}