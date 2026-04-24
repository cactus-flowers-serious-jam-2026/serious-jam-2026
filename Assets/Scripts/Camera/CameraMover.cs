using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    public float minFov = 1f;
    public float maxFov = 15f;
    public float zoomSpeed = 1.0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        
        if (mousePos.x <= 0)
            transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        if (mousePos.x >= Screen.width - 1)
            transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        if (mousePos.y <= 0)
            transform.position = new Vector3(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime, transform.position.z);
        if (mousePos.y >= Screen.height - 1)
            transform.position = new Vector3(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime, transform.position.z);

        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            float fov = Camera.main.orthographicSize;
            fov -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
            fov = Mathf.Clamp(fov, minFov, maxFov);
            Camera.main.orthographicSize = fov;
        }
    }
}
