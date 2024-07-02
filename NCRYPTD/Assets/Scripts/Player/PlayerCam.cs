using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;
    public Transform playerBody; // Referencia al modelo 3D del jugador

    float xRot;
    float yRot;

    private void Start()
    {
        // Locks the Cursor on the center of the screen and makes it invisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // Mouse inputs
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRot += mouseX;
        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f); // X cam rotation will not pass the 90º rotation in each direction

        // Cam rotation and orientation
        transform.rotation = Quaternion.Euler(xRot, yRot, 0);
        orientation.rotation = Quaternion.Euler(0, yRot, 0);

        // Rotar el cuerpo del jugador solo sobre el eje Y basado en la rotación de la cámara
        playerBody.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
    }
}
