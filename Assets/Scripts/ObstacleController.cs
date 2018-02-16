using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour {
    public bool gameOver;
    public float scoreDistanceOffset;
    private bool counted;
    private GameController gameController;

    // Use this for initialization
    void Start()
    {
        gameOver = false;
        counted = false;
        GameObject gameControllerObj = GameObject.FindWithTag("GameController");
        if (gameControllerObj == null)
        {
            Debug.Log("Controller not found!");
        }
        else
        {
            gameController = gameControllerObj.GetComponent<GameController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            Transform transform = GetComponent<Transform>();
            transform.position = transform.position - new Vector3(gameController.obstacleSpeed, 0, 0);
        }

        if (transform.position.x < -50)
        {
            Destroy(this.gameObject);
        }

        if (transform.position.x+ scoreDistanceOffset < gameController.player.GetComponent<Transform>().position.x)
        {   
            if (!counted)
            {
                gameController.addScore();
                counted = true;
            }
        }
    }
}
