using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour {
    public GameObject obstacle;
    public bool gameOver;

	// Use this for initialization
	void Start () {
        gameOver = false;
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void spawnObstacle()
    {
        Instantiate(obstacle, GetComponent<Transform>());
    }
}
