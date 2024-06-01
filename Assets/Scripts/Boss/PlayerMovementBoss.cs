using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBoss : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed; //Velocidad de movimiento

    public float groundDrag; //Parametro para evitar que nos deslicemos mucho en el suelo para hacerlo mas realista

    [Header("Ground Check")] //Verificar si el jugador está en el suelo para aplicar arrastre (movimiento menos resbaladizo)
    public float playerHeight; //Altura de jugador
    public LayerMask whatIsGround; //La layer para verificar cual será el suelo
    bool grounded; //Booleano que marcará cuando el jugador esté en el suelo

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;


    //Audio
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>(); //Obtenemos los componentes de audio de nuestro audioManager
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); //Obtenemos el rigidbody
        rb.freezeRotation = true; //Congelamos su rotacion
    }

    private void Update()
    {
        //ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround); //checar con el raycast si hay un piso debajo del jugador
        MyInput();
        SpeedControl();

        //handle drag

        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }

    private void FixedUpdate() //Este es lo mismo que el update pero más enfocado en el framerate y en las físicas
    {
        MovePlayer(); //Movemos al jugador

    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal"); //Mover al personaje en horizontal
        verticalInput = Input.GetAxisRaw("Vertical"); //Mover al personaje en vertical
    }

    public void MovePlayer()
    {
        //calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput; //Moverte en la direccion que estás viendo
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force); //Le damos velocidad al jugador



        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.AddForce(moveDirection.normalized * (moveSpeed * 7f) * 10f, ForceMode.Force); //Aumentamos la velocidad al jugador al correr
        }

    }

    private void SpeedControl() //Funcion para limitar la velocidad y evitar que el jugador vaya más rapido de como lo esperabamos
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //Limitar la velocidad

        if (flatVel.magnitude > moveSpeed) //Si vas a velocidad que tu velocida normal
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed; //Calcula cual sería la velocidad maxima
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z); //Y la aplicamos
        }
    }

}