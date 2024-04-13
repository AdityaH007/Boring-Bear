using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float sensitivity = 5.0f; // Mouse sensitivity for camera rotation
    public float maxYAngle = 100.0f; // Maximum rotation angle in the Y direction

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    void Update()
    {
        //float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // Calculate new rotation angles
        //rotationX += mouseX;
        rotationY -= mouseY;

        // Clamp rotation angles to the specified limits
        rotationY = Mathf.Clamp(rotationY, -maxYAngle, maxYAngle);
        //rotationX = Mathf.Clamp(rotationX, -maxYAngle, maxYAngle);

        // Apply rotations
        transform.localRotation = Quaternion.Euler(rotationY, rotationX, 0.0f);
    }
}
