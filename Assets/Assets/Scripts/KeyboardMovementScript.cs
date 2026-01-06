using UnityEngine;

public class KeyboardMovementScript : MonoBehaviour
{
    private CharacterController characterController;
    public float velocity = 10;
    public float gravity = 10;
    public float jumpHeight = 10;
    
    public Transform groundCheck;
    public float groundDistance = 0.4f; 
    public LayerMask groundMask;
    
    Vector3 velocityVector;
    
    bool isGrounded;  
    bool isMoving;
    
    private Vector3 lastPosition = new Vector3(0, 0, 0);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         characterController = GetComponent<CharacterController>(); 
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocityVector.y < 0)
        {
            velocityVector.y = -2;
        }
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        Vector3 move = transform.right * x + transform.forward * z;
        
        characterController.Move(move * velocity * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocityVector.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
        
        velocityVector.y += gravity * Time.deltaTime;
        
        characterController.Move(velocityVector * Time.deltaTime);

        if (lastPosition != gameObject.transform.position && isGrounded == true)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
        
        lastPosition = gameObject.transform.position; 
    }
}
