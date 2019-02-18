using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	[SerializeField] float screenWidthUnits = 16f;
	[SerializeField] GameObject paddle;
	// Use this for initialization

	// Factoring out FindObjectOfType() (Caching references)
	Ball ball;
	GameStatus gameStatus;
	void Start () {
		ball = FindObjectOfType<Ball>();
		gameStatus = FindObjectOfType<GameStatus>();
		
	}
	
	// Update is called once per frame
	void Update () {
		// Debug.Log(Input.mousePosition);
		// Debug.Log("X Unit == " + screenWidthUnits * (Input.mousePosition.x / Screen.width));
		// float cameraUnitsX = screenWidthUnits * (Input.mousePosition.x / Screen.width);
		Vector3 paddlePos = new Vector3(GetXPos(), transform.position.y, -1.0f);
		transform.position = paddlePos;
		// There are 16 units, so multiply that number by the fraction the mouse
		// Is across the screen to get the x units
		// Debug.Log("paddle.transform.position == " + paddle.transform.position);
		// paddle.transform.SetPositionAndRotation(screenWidthUnits * (Input.mousePosition.x / Screen.width), paddle.transform.position.y, paddle.transform.position.z);
	}

	private float GetXPos() {
		if(gameStatus.IsAutoPlayEnabled()) {
			return ball.transform.position.x;
		}
        float cameraUnitsX = screenWidthUnits * (Input.mousePosition.x / Screen.width);
		return Mathf.Clamp(cameraUnitsX, 0.0f + 1, screenWidthUnits - 1);
	}
}
