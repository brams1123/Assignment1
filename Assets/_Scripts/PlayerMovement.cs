using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    float maxSpeed = 5f;
    float rotSpeed = 180f;

    float shipBoundRad = 0.5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //Rotation Movement

        Quaternion rot = transform.rotation;
        float z = rot.eulerAngles.z;
        z -= Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        rot = Quaternion.Euler(0, 0, z);
        transform.rotation = rot;


        //Up and Down Movement 

        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime, 0);
        pos += rot * velocity;

        //Ship Boundary inside of Main Camera
        if(pos.y+shipBoundRad > Camera.main.orthographicSize)
        {
            pos.y = Camera.main.orthographicSize - shipBoundRad;
        }
        if (pos.y-shipBoundRad < -Camera.main.orthographicSize)
        {
            pos.y = -Camera.main.orthographicSize + shipBoundRad;
        }

        float Scnratio = (float)Screen.width / (float)Screen.height;
        float widthOrtho = Camera.main.orthographicSize * Scnratio;

        if (pos.x+shipBoundRad > widthOrtho)
        {
            pos.x = widthOrtho - shipBoundRad;
        }

        if (pos.x-shipBoundRad < -widthOrtho)
        {
            pos.x = -widthOrtho + shipBoundRad;
        }
        transform.position = pos;

        
	
	}
}
