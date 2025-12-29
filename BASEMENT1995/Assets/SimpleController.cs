using UnityEngine;

public class SimpleController : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float lookSpeed = 2f;
    public Camera playerCamera;

    private float rotationX = 0f;
    private CharacterController controller;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float mouseX = UnityEngine.Input.GetAxis("Mouse X") * lookSpeed;
        float mouseY = UnityEngine.Input.GetAxis("Mouse Y") * lookSpeed;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

        float x = UnityEngine.Input.GetKey(KeyCode.D) ? 1f : UnityEngine.Input.GetKey(KeyCode.A) ? -1f : 0f;
        float z = UnityEngine.Input.GetKey(KeyCode.W) ? 1f : UnityEngine.Input.GetKey(KeyCode.S) ? -1f : 0f;

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * moveSpeed * Time.deltaTime);

        controller.Move(Vector3.down * 9.8f * Time.deltaTime);

        if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}