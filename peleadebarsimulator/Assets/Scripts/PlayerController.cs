using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables de movimienrto

    public float horizontalMove;
    public float verticalMove;
    private Vector3 playerInput;

    //Variable de controlador
    public CharacterController player;

    //Variables de movimiento del personaje
    public float playerSpeed;
    private Vector3 movePlayer;

    //Variables de Gravedad y salto
    public float gravity = 9.8f;
    public float fallVelocity;
    public float jumpForce;

    //Variables de Control de camara
    public Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRight;

    // Start is called before the first frame update
    void Start() {
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame

    // Actualizacion del personaje por Frame
    void Update() {

        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
        
        playerInput = new Vector3(horizontalMove, 0, verticalMove);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);

        camDirection();

        movePlayer = playerInput.x * camRight + playerInput.z * camForward;

        movePlayer = movePlayer * playerSpeed;

        player.transform.LookAt(player.transform.position + movePlayer);

        SetGravity();

        PlayerSkills();

        player.Move(movePlayer * Time.deltaTime);
        //player.Move(new Vector3(horizontalMove,0,verticalMove) * playerSpeed * Time.deltaTime);
        //Debug.Log(player.velocity.magnitude);
        
    }


    //Funcion de giro de camara del personaje

    void camDirection() 
    {
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }


    //Funcion para las habilidadesde del personaje

    public void PlayerSkills()

    {
        if (player.isGrounded && Input.GetButtonDown("Jump"))
        {
            fallVelocity = jumpForce;
            movePlayer.y = fallVelocity;
        }
    }

    //Funcion de gravedad

    void SetGravity() {

        

        if (player.isGrounded) 
        {
            fallVelocity = -gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
        }

        else
        {
            fallVelocity -= gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
        }

    }

    
}
