using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public GameObject spawnPoint;
    public GameObject player;
    public Text scoreText;
    public Text gameoverText;
    public Text restartText;
    public GameObject background;

    public bool gameOver;
    public bool restartAble;

    public float obstacleStartSpeed;
    public float obstacleSpeed;
    public float obstacleSpeedChangeRate;

    public float spawnStartDelay;
    public float spawnDelay;
    public float delayChangeRate;

    private int score;

    // Use this for initialization
    void Start () {
        gameOver = false;
        restartAble = false;
        score = 0;
        gameoverText.gameObject.SetActive(false);
        restartText.gameObject.SetActive(false);

        StartCoroutine(spawnObstacles());
        StartCoroutine(delayControl());
        StartCoroutine(obstacleSpeedControl());
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        scoreText.text = score.ToString();

        if (gameOver)
        {
            if (!restartAble)
            {
                background.GetComponent<ScollController>().gameOver = true;
                gameoverText.gameObject.SetActive(true);
                restartText.gameObject.SetActive(true);
                GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
                foreach (GameObject obj in obstacles)
                {
                    obj.GetComponent<ObstacleController>().gameOver = true;
                }
                restartAble = true;
            }
            else
            {
                if (Input.GetKey(KeyCode.R))
                {
                    SceneManager.LoadScene("MainGame");
                }
            }
        }
    }

    IEnumerator spawnObstacles()
    {
        while (!gameOver)
        {
            spawnPoint.GetComponent<ObstacleSpawn>().spawnObstacle();
            yield return new WaitForSeconds(Random.Range(spawnDelay/2, spawnDelay));
        }
        yield break;
    }

    IEnumerator delayControl()
    {
        while (!gameOver)
        {
            spawnDelay = spawnStartDelay - (score / 3.0f) * delayChangeRate;
            yield return new WaitForSeconds(1);
        }
        yield break;
    }

    IEnumerator obstacleSpeedControl()
    {
        while (!gameOver)
        {
            obstacleSpeed = obstacleStartSpeed + (score / 3.0f) * obstacleSpeedChangeRate;
            yield return new WaitForSeconds(0.1f);
        }
        yield break;
    }

    public void addScore()
    {
        score++;
    }
}
