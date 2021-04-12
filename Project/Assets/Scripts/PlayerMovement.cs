using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public Animator anim;
    public RuntimeAnimatorController walk;
    public RuntimeAnimatorController idle;
    public RuntimeAnimatorController sprint;
    public RuntimeAnimatorController jump;
    public WarningNotification w;
    public bool isSprinting = false;
    public Rigidbody body;
    Vector3 playerVelocity = new Vector3(0,0,0);
    public ProgressBar progressBar;

    public float speed = 6f;

    public float turnSmoothTime = 0.1f;
    public float gravity = 10;
    private float turnSmoothVelocity;
    public float jumpSpeed = 6f;
    public bool isJumping = false;
    public float vspeed = 0f;
    public int numMoney = 0;
    public float gameTime = 0;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;


        // Track time
        gameTime += Time.deltaTime;


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

            if (isSprinting && !isJumping)
            {
                anim.runtimeAnimatorController = sprint as RuntimeAnimatorController;
                speed = 11;
            }
            else if(!isJumping)
            {
                anim.runtimeAnimatorController = walk as RuntimeAnimatorController;
                speed = 6;
            }
        }
        else if(!isJumping)
        {
            anim.runtimeAnimatorController = idle as RuntimeAnimatorController;
        }
        if (controller.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            playerVelocity.y += Mathf.Sqrt(jumpSpeed * -3.0f * -gravity);

            anim.runtimeAnimatorController = jump as RuntimeAnimatorController;
        }
        playerVelocity.y -= gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        // Checking for win condition and switching to game screen
        if (numMoney == 20)
        {
            WaitForATime(3);
            SceneManager.LoadScene(2);
        }
    }

    // Collision detection logic for barriers and money
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.layer == 3)
        {
            return;
        }

        Debug.Log("Here");

        if (hit.gameObject.CompareTag("Barrier"))
        {
            Debug.Log("bruh");
            w.playWarning();
        }
        else if (hit.gameObject.CompareTag("Money"))
        {
            Debug.Log("hi");
            Object.Destroy(hit.gameObject);
            numMoney++;
            progressBar.setProgress(numMoney);
        }
    }

    IEnumerator WaitForATime(float t)
    {
        yield return new WaitForSeconds(t);

        // Code to execute after the delay
    }
}