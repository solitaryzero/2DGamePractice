using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScollController : MonoBehaviour {
    public float scrollSpeed;
    private float startXAxis;
    private float inWorldWidth;
    public bool gameOver;

    // Use this for initialization
    void Start () {
        Transform transform = GetComponent<Transform>();
        inWorldWidth = transform.localScale.x * GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        float cameraWidth = Camera.main.orthographicSize * Camera.main.aspect * 2;
        startXAxis = (inWorldWidth - cameraWidth) / 2;
        transform.position = new Vector3(startXAxis, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {
        if (!gameOver)
        {
            Transform transform = GetComponent<Transform>();
            float xAxis = -Mathf.Repeat(Time.time * scrollSpeed, inWorldWidth) + startXAxis;
            transform.position = new Vector3(xAxis, 0, 0);
        }
	}
}
