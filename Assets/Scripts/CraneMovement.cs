using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
//using static UnityEditor.PlayerSettings;

public class CraneMovement: MonoBehaviour
{
    public GameObject camera1;
    public GameObject camera2;

    //Arm pivot objects for rotating
    public GameObject Arm1;
    public GameObject Arm2;
    public GameObject Arm3;

    //Variables to control the "movement phase" of the crane
    private bool x_movement = true;
    private bool z_movement = false;
    private bool y_movement_down = false;
    private bool y_movement_up = false;
    private bool movement_end = false;
    private bool flag = false;
    private bool front_view = true;

    //The crane's starting position
    private Vector3 origin = new Vector3(0.35f, 1.45f, 0.35f);

    public float speed = 0.3f;

    void Update()
    {
        //Camera control
        if (front_view)
        {
            camera1.SetActive(true);
            camera2.SetActive(false);
            Vector3 cameraPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, camera1.transform.position.y, Camera.main.nearClipPlane));
            float clamp = Mathf.Clamp(cameraPosition.z * 0.5f, -0.3f, 0.3f);
            camera1.transform.position = new Vector3(camera1.transform.position.x, camera1.transform.position.y, clamp);
        }
        if (!front_view)
        {
            camera1.SetActive(false);
            camera2.SetActive(true);
            Vector3 cameraPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, camera2.transform.position.y, Camera.main.nearClipPlane));
            float clamp = Mathf.Lerp(0.3f, 1.0f, cameraPosition.x);
            camera2.transform.position = new Vector3(clamp, camera2.transform.position.y, camera2.transform.position.z);
        }


        if (x_movement)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                //Moves crane on the x axis
                transform.Translate(Vector3.left * Time.deltaTime * speed);
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                //Stops movement when user lets go of the spacebar
                z_movement = true;
                x_movement = false;
            }
        }
        if (z_movement)
        {
            front_view = false;
            if (Input.GetKey(KeyCode.Space))
            {
                //Moves crane on the z axis
                transform.Translate(Vector3.back * Time.deltaTime * speed);
                flag = true;
            }
            if (Input.GetKeyUp(KeyCode.Space) && flag)
            {
                //Stops movement when user lets go of the spacebar
                //A bool flag has been used to ensure that user input is handled correctly
                y_movement_down = true;
                z_movement = false;
                flag = false;
            }
        }
        if (y_movement_down)
        {
            front_view = true;
            Vector3 bottom = new Vector3(transform.position.x, 0.95f, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, bottom, Time.deltaTime * speed);
            if (transform.position == bottom)
            {
                y_movement_down = false;
                y_movement_up = true;
            }
        }
        if (y_movement_up)
        {
            if (flag == false) 
            {
                //A flag boolean has been used to ensure the closeClaw function only runs once
                closeClaw();
                flag = true;
            }

            //Moves crane back up
            Vector3 top = new Vector3(transform.position.x, 1.45f, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, top, Time.deltaTime * speed);
            if (transform.position == top)
            {
                movement_end = true;
                y_movement_up = false;
            }
        }

        if (movement_end)
        {
            //Moves crane back to origin
            transform.position = Vector3.MoveTowards(transform.position, origin, Time.deltaTime * speed);
            if (transform.position == origin)
            {
                //A flag boolean has been used to ensure the openClaw function only runs once
                if (flag == true)
                {
                    openClaw();
                    flag = false;
                }
                x_movement = true;
                movement_end = false;
            }
        }
    }

    private void closeClaw()
    {
        //Closes the claw
        Arm1.transform.Rotate(0, 0, 30);
        Arm2.transform.Rotate(-30, 0, 0);
        Arm3.transform.Rotate(0, 0, -30);
    }

    private void openClaw()
    {
        //Opens the claw
        Arm1.transform.Rotate(0, 0, -30);
        Arm2.transform.Rotate(30, 0, 0);
        Arm3.transform.Rotate(0, 0, 30);
    }

}
