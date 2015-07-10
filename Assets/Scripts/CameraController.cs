using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public float moveSpeed;

	void Update()
	{
		ProcessMove();
		ProcessZoom();
	}

	void ProcessMove(){

		if(Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate(new Vector3(moveSpeed * Time.deltaTime,0,0));
		}
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Translate(new Vector3(-moveSpeed * Time.deltaTime,0,0));
		}
		if(Input.GetKey(KeyCode.DownArrow))
		{
			transform.Translate(new Vector3(0,-moveSpeed * Time.deltaTime,0));
		}
		if(Input.GetKey(KeyCode.UpArrow))
		{
			transform.Translate(new Vector3(0,moveSpeed * Time.deltaTime,0));
		}

	}

	void ProcessZoom(){

		if (Input.GetAxisRaw ("Mouse ScrollWheel") > 0 && transform.position.y >= 6.0f) {

			transform.position = new Vector3(transform.position.x, transform.position.y - 1.0f, transform.position.z);

		}

		if (Input.GetAxisRaw ("Mouse ScrollWheel") < 0 && transform.position.y <= 100.0f) {
			
			transform.position = new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z);
			
		}

	}

}
