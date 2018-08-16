using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public float desiredDistance; // Camera Desired Distance from Target
    public float cameraRotateSpeed = 1; // Mouse Sensitivity for Rotation of Camera
    private Transform cameraTarget; // Target Point for Camera
    private Vector3 prevMousePos; // For calculating mouse drag distance
	
	void Start () {
        cameraTarget = transform.parent.Find("CameraTarget"); // Find Camera Target
	}
	
	// Update is called once per frame
	void Update () {
        CheckInput(); // Check Camera + Player Rotation (Facing)
        MoveCamera(); // Move Camera
    }

    private void MoveCamera()
    {
        // Check if Camera Clips then place either at desired distance or
        //    closer if clips
        RaycastHit hitInfo;
        if (Physics.Raycast(new Ray(cameraTarget.position, -transform.forward),
            out hitInfo, desiredDistance))
            transform.position = cameraTarget.position - transform.forward * (hitInfo.distance);
        else
            transform.position = cameraTarget.position - transform.forward * desiredDistance;
    }

    private void CheckInput()
    {
        if (Input.GetMouseButtonDown(1)) prevMousePos = Input.mousePosition;
        if (Input.GetMouseButton(1))
        {
            Vector2 newMousePos = Input.mousePosition;
            // up down rotation of camera
            transform.Rotate(Vector3.right * (prevMousePos.y - newMousePos.y) * cameraRotateSpeed);
            // left right rotation of player forward
            transform.parent.Rotate(Vector3.up * (newMousePos.x - prevMousePos.x) * cameraRotateSpeed);
            prevMousePos = newMousePos;
        }
    }
}
