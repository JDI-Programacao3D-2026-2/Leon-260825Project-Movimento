using UnityEngine;
using UnityEngine.InputSystem;

public class MouseOrbit : MonoBehaviour
{

    public Transform player;
    public float distance = 5f;
    public float mouseSensitivity = 0.2f;
    private float rotX, rotY;
    
    void LateUpdate()
    {
        if (player == null) return;

        Vector2 delta = Mouse.current.delta.ReadValue() * mouseSensitivity;
        rotX += delta.x;
        rotY -= delta.y;
        rotY = Mathf.Clamp(rotY, -10f, 60f);

        Quaternion rotation = Quaternion.Euler(rotY, rotX, 0);
        transform.position = player.position - rotation * Vector3.forward * distance;
        transform.rotation = rotation;
    }
}
