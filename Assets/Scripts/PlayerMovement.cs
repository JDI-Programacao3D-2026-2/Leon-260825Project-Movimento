using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 5f;
    private Rigidbody rb;
    public GameObject elevator;
    private Vector3 elevatorDirection = Vector3.up;
    private bool isElevatorMoving = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 direction = Vector3.zero;

        //pega a direção do movimento do jogador
        if (Keyboard.current[Key.W].isPressed)
        {
            direction += transform.forward;
        }
        if (Keyboard.current[Key.D].isPressed)
        {
            direction += transform.right;
        }
        if (Keyboard.current[Key.S].isPressed)
        {
            direction -= transform.forward;
        }
        if (Keyboard.current[Key.A].isPressed)
        {
            direction -= transform.right;
        }

        //usa waspressedthisframe para fazer o jogador pular
        if (Keyboard.current[Key.Space].wasPressedThisFrame)
        {
            rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);
        }

        //usa wasreleasedthisframe para fazer uma plataforma se mover
        if (Keyboard.current[Key.E].wasReleasedThisFrame)
        {
            if (isElevatorMoving)
            {
                isElevatorMoving = false;
                SwitchDirection();
            }
            else
            {
                isElevatorMoving = true;
            }
        }

        direction = Vector3.ClampMagnitude(direction, 1f);

        //faz o jogador se mover na direção correta
        rb.linearVelocity = new Vector3(direction.x * speed, rb.linearVelocity.y, direction.z * speed);

        //faz a plataforma se mover na direção correta
        if (isElevatorMoving)
        {
            elevator.transform.Translate(elevatorDirection * speed * Time.fixedDeltaTime);
        }
    }

    //troca a direção da plataforma
    private void SwitchDirection()
    {
        if (elevatorDirection == Vector3.up)
        {
            elevatorDirection = Vector3.down;
        }
        else
        {
            elevatorDirection = Vector3.up;
        }
    }
}
