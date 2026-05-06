using System;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    public float minFov = 1f;
    public float maxFov = 15f;
    public float zoomSpeed = 1.0f;
    public float border_x = 10.0f;
    public float border_y = 10.0f;
    private Camera _camera;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        float distance = moveSpeed * Time.deltaTime;
        
        if (mousePos.x <= 0 || Input.GetKey(KeyCode.A))
            transform.position = new Vector3(
                Math.Clamp(transform.position.x - distance, -border_x, border_x), 
                transform.position.y, 
                transform.position.z);
        if (mousePos.x >= Screen.width - 1 || Input.GetKey(KeyCode.D))
            transform.position = new Vector3(
                Math.Clamp(transform.position.x + distance, -border_x, border_x), 
                transform.position.y, 
                transform.position.z);
        if (mousePos.y <= 0 ||  Input.GetKey(KeyCode.S))
            transform.position = new Vector3(
                transform.position.x, 
                Math.Clamp(transform.position.y - distance, -border_y, border_y), 
                transform.position.z);
        if (mousePos.y >= Screen.height - 1 ||  Input.GetKey(KeyCode.W))
            transform.position = new Vector3(
                transform.position.x, 
                Math.Clamp(transform.position.y + distance, -border_y, border_y), 
                transform.position.z);
        
        
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            float fov = _camera.orthographicSize;
            fov -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
            fov = Mathf.Clamp(fov, minFov, maxFov);
            _camera.orthographicSize = fov;
        }
    }
}
