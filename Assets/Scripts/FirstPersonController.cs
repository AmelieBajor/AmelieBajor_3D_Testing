using UnityEngine;

public class FirstPersonController : MonoBehaviour
{

    private CharacterController characterController;
    public float walkSpeed = 25;
    public float mouseSensitivity = 2;
    float verticalRotation;
    float upDownRange = 80;

    private Camera cam;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        cam = Camera.main;
    }

    void Update()
    {

        Movement();
        MouseLook();

    }

    void Movement()
    {
        
        float verInput = Input.GetAxis("Vertical");
        float horInput = Input.GetAxis("Horizontal");
        float verSpeed = verInput * walkSpeed;
        float horSpeed = horInput * walkSpeed;

        Vector3 horizontalMovement = new Vector3(horSpeed, 0, verSpeed);
        horizontalMovement = transform.rotation * horizontalMovement;

        characterController.Move(horizontalMovement * Time.deltaTime);

        

    }

    void MouseLook()
    {
        float mouseXRotation = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, mouseXRotation, 0);

        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
        cam.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0); 
        //local rotation rotates object in relation to the parent
        

    }
}
