using UnityEngine;

public class MouseMovementScript : MonoBehaviour
{
    public float mouseSensitivity =1000;

    float xRotation;
    float yRotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity*Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity*Time.deltaTime;
        
        xRotation -= mouseY; //looking up and down(Rotation around x axis)
        xRotation = Mathf.Clamp(xRotation, -90, 90);//stops from rotating too much
        
        yRotation += mouseX;
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
        
    }
}
