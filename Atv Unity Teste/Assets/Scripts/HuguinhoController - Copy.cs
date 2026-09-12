using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class HuguinhoController : MonoBehaviour
{
    [Header("Movement Configs")]
    public float speed = 5f;
    private bool isWalking = false;
    private Vector3 current_direction = Vector3.zero;
    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);

        Vector3 input_direction = Vector3.zero;

        if (Keyboard.current != null)
        {
            //coloca a direção da movimentação
            if (Keyboard.current.wKey.isPressed) input_direction += Vector3.forward;
            if (Keyboard.current.aKey.isPressed) input_direction += Vector3.left;
            if (Keyboard.current.sKey.isPressed) input_direction += Vector3.back;
            if (Keyboard.current.dKey.isPressed) input_direction += Vector3.right;
        }

        //se houver uma direção de movimentação, calcula para onde huguinho deve ir
        if (input_direction != Vector3.zero)
        {
            isWalking = true;
            current_direction = input_direction;
        }
        else
        {
            isWalking = false;
            current_direction = Vector3.zero;
        }
    }

    void FixedUpdate()
    {
        if (isWalking)
        {
            //move o huguinho na direção calculada
            current_direction = Vector3.ClampMagnitude(current_direction, 1f); //normaliza a direção para não ultrapassar a velocidade máxima
            rb.MovePosition(rb.position + current_direction * speed * Time.fixedDeltaTime);
        }
    }


    
}
