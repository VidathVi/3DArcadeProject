using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FlappyBirdController : MonoBehaviour
{
    public  GameObject Bird;
    public GameObject PipePrefab;
    public GameObject WingsLeft;
    public GameObject WingsRight;
    public Text ScoreText;
    public float Gravity = 30;
    public float Jump = 10;
    public float PipeSpawnInterval = 2;
    public float PipeSpeed = 5;

    private float VerticalSpeed ;
    private float PipeSpawnCountDown ;
    private GameObject PipesHolder;
    private int PipeCount ;
    private int Score ;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //reset score
        Score = 0;
        ScoreText.text = "SCORE =" + Score.ToString();
        // reset Pipes
        PipeCount = 0;
        Destroy(PipesHolder);
        PipesHolder = new GameObject("PipesHolder");
        PipesHolder.transform.position = Vector3.zero;
        PipesHolder.transform.parent = this.transform;

        // reset Bird
        VerticalSpeed = 0;
        Bird.transform.position = Vector3.up * 5;

        // reset Pipe spawn timer
        PipeSpawnCountDown = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainHub");
        }
        // step-1: Bird Movement
        VerticalSpeed -= Gravity * Time.deltaTime;

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            VerticalSpeed = 0;
            VerticalSpeed += Jump;
        }
        Bird.transform.position += Vector3.up * (VerticalSpeed * Time.deltaTime);
        
        // step-2: Pipe 
        PipeSpawnCountDown -= Time.deltaTime;
        if (PipeSpawnCountDown <= 0)
        {
            PipeSpawnCountDown = PipeSpawnInterval;
            // create pipe
            GameObject pipe = Instantiate(PipePrefab);
            pipe.transform.parent = PipesHolder.transform;
            pipe.transform.name = (++PipeCount).ToString();

            // set initial pipe position relative to the holder/world
            pipe.transform.position += Vector3.right * 30;
            pipe.transform.position += Vector3.up * Mathf.Lerp(4,9,Random.value);
        }

        // move all pipes by moving the PipesHolder
        PipesHolder.transform.position += Vector3.left * PipeSpeed * Time.deltaTime;

       // wings
        float flapSpeed= (VerticalSpeed > 0) ? 30 : 5;
        float angle = Mathf.Sin(Time.time * flapSpeed) * 45;
        WingsLeft.transform.localRotation = Quaternion.Euler(Vector3.left * angle);
        WingsRight.transform.localRotation = Quaternion.Euler(Vector3.right * angle);

        foreach (Transform pipe in PipesHolder.transform)
        {
            // score check
            if (pipe.position.x < 0)
            {
                int pipeId = int.Parse(pipe.name);
                if (pipeId > Score)
                {
                    Score = pipeId;
                    ScoreText.text = "SCORE =" + Score.ToString();

                }
                
            }
            if (pipe.position.x < -30)
            {
                Destroy(pipe.gameObject);
            }
        }



        
    }
    private void OnTriggerEnter(Collider collider)
    {
        // reset game
        Start();
    }
}
