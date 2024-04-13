using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator playerAnim;
    public float w_speed, wb_speed, olw_speed, rn_speed, ro_speed;
    public bool walking;
    public Transform playerTrans;
    private float rotationSpeed = 3f;

    private bool isJumping = false;
    public float jumpForce = 50f; 
    private float gravity = 90.81f; 
    public Rigidbody rb;

    private RaycastHit hit;
    private float groundCheckDistance = 0.5f; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float rotationAmount = mouseX * rotationSpeed;
        transform.Rotate(Vector3.up, rotationAmount, Space.Self);
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance);

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping )
        {
            playerAnim.SetTrigger("Jump");
            playerAnim.ResetTrigger("idle");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = true;
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            playerAnim.ResetTrigger("Jump");
            //playerAnim.SetTrigger("idle");
        }

        if (isJumping)
        {
            Vector3 movement = Vector3.zero;
            movement += playerTrans.forward * w_speed * Time.deltaTime;
            playerTrans.position += movement;

            rb.AddForce(Vector3.down * gravity, ForceMode.Acceleration);
            if (isGrounded)
            {
               
                isJumping = false;
                rb.velocity = Vector3.zero;
            }

            
            if (Physics.Raycast(playerTrans.position, Vector3.down, out hit, groundCheckDistance))
            {
                Debug.Log("Hit detected: " + hit.point);

                
                isJumping = false;
                jumpForce = 100f; 
               
                playerTrans.position = new Vector3(playerTrans.position.x, hit.point.y, playerTrans.position.z);

                rb.velocity = Vector3.zero;
            }
            else
            {
                Debug.Log("No hit detected");
            }
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            playerAnim.SetTrigger("Walk");
            playerAnim.ResetTrigger("idle");
            walking = true;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            playerAnim.ResetTrigger("Walk");
            playerAnim.SetTrigger("idle");
            walking = false;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            playerAnim.SetTrigger("Walkback");
            playerAnim.ResetTrigger("idle");
            walking = true;
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            playerAnim.ResetTrigger("Walkback");
            playerAnim.SetTrigger("idle");
            walking = false;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            playerTrans.Rotate(0, -ro_speed * Time.deltaTime, 0);
            //playerAnim.SetTrigger("Left");
            //playerAnim.ResetTrigger("idle");
        }

        if (Input.GetKey(KeyCode.D))
        {
            playerTrans.Rotate(0, ro_speed * Time.deltaTime, 0);
        }

        if (walking)
        {
            Vector3 movement = Vector3.zero;
            if (Input.GetKey(KeyCode.W))
            {
                movement += playerTrans.forward * w_speed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.S))
            {
                movement -= playerTrans.forward * wb_speed * Time.deltaTime;
            }

            playerTrans.position += movement;
        }

        if (walking && Input.GetKeyDown(KeyCode.LeftShift))
        {
            w_speed += rn_speed;
            playerAnim.SetTrigger("Run");
            playerAnim.ResetTrigger("idle");
        }

        if (walking && Input.GetKeyUp(KeyCode.LeftShift))
        {
            w_speed = olw_speed;
            playerAnim.ResetTrigger("Run");
            playerAnim.SetTrigger("Walk");
        }
    }
}