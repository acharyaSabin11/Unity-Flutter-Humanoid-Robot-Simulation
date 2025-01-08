using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public Transform target; // The object the camera will orbit around
    public float distance = 5.0f; // Distance from the target
    public float rotationSpeed = 100.0f; // Speed of rotation
    public float zoomSpeed = 2.0f; // Speed of zooming
    public float minDistance = 2.0f; // Minimum zoom distance
    public float maxDistance = 10.0f; // Maximum zoom distance
    public float minYAngle = -20f; // Minimum vertical angle
    public float maxYAngle = 80f; // Maximum vertical angle

    private float currentX = 0.0f; // Horizontal rotation
    private float currentY = 0.0f; // Vertical rotation
    private Vector3 offset; // Offset from the target

    void Start()
    {
        // Set the initial offset based on the distance
        offset = new Vector3(0, 0, -distance);
    }

    void Update()
    {
        // Input for dragging with mouse or touch
        if (Input.GetMouseButton(0)) // Left mouse button or touch
        {
            currentX += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            currentY -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

            // Clamp the vertical rotation to the specified angles
            currentY = Mathf.Clamp(currentY, minYAngle, maxYAngle);
        }

        // Input for zooming (scroll wheel for desktop)
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0.0f)
        {
            distance -= scroll * zoomSpeed;
            distance = Mathf.Clamp(distance, minDistance, maxDistance);
        }

        // Input for pinch-to-zoom (for touch devices)
        if (Input.touchCount == 2)
        {
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            // Find the position in the previous frame of each touch
            Vector2 touch0PrevPos = touch0.position - touch0.deltaPosition;
            Vector2 touch1PrevPos = touch1.position - touch1.deltaPosition;

            // Find the magnitude of the distance between the touches in each frame
            float prevMagnitude = (touch0PrevPos - touch1PrevPos).magnitude;
            float currentMagnitude = (touch0.position - touch1.position).magnitude;

            // Find the difference in the distances between frames
            float difference = currentMagnitude - prevMagnitude;

            // Adjust the distance based on the pinch gesture
            distance -= difference * zoomSpeed * Time.deltaTime;
            distance = Mathf.Clamp(distance, minDistance, maxDistance);
        }
    }

    void LateUpdate()
    {
        // Calculate the new position and rotation
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        offset = new Vector3(0, 0, -distance);
        transform.position = target.position + rotation * offset;
        transform.LookAt(target); // Always look at the target
    }
}
