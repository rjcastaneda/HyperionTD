using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector3 camPos;
    private float zoom;

    public float panSpeed = 30f;
    public float camBorder = 10f;
    public float zoomSpeed = 1f;

    //Camera Clamp Boundaries
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float minZ;
    public float maxZ;

    void Update()
    {
        DirectionalMove();
        CamZoom();
    }
    private void DirectionalMove()
    {
        //Directional Camera Movement
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0, 0, panSpeed * Time.deltaTime), Space.World);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, 0, -panSpeed * Time.deltaTime), Space.World);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-panSpeed * Time.deltaTime, 0, 0), Space.World);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(panSpeed * Time.deltaTime, 0, 0), Space.World);
        }
    }
    private void CamZoom()
    {
        //ScrollWheel Camera Zoom
        camPos = transform.position;
        zoom = Input.GetAxis("Mouse ScrollWheel");
        camPos.y -= zoom * 100 * zoomSpeed * Time.deltaTime;
        transform.position = camPos;
    }
    void LateUpdate()
    {
        //Camera Bounds
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, minX, maxX),
            Mathf.Clamp(transform.position.y, minY, maxY),
            Mathf.Clamp(transform.position.z, minZ, maxZ));
    }
}
