using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour {
    public float jumpSpeed;
    public float jumpForce;
    private Rigidbody2D r2d;
    private bool gameOver;
    private GameController gameController;

    // Use this for initialization
    void Start () {
        r2d = GetComponent<Rigidbody2D>();
        gameOver = false;
        GameObject gameControllerObj = GameObject.FindWithTag("GameController");
        if (gameControllerObj == null)
        {
            Debug.Log("Controller not found!");
        } else
        {
            gameController = gameControllerObj.GetComponent<GameController>();
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (gameOver)
        {
            r2d.velocity = Vector2.zero;
            r2d.bodyType = RigidbodyType2D.Static;

            return;
        }
            
		if (Input.GetKey(KeyCode.UpArrow))
        {
            if (r2d.velocity == Vector2.zero)
            {
                r2d.velocity = new Vector2(0, jumpSpeed);
            }
            r2d.AddForce(Vector2.up * jumpForce);   //延滞效果
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            gameController.gameOver = true;
        }
    }
}
