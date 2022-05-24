using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    [Tooltip("RigidBody asociado al player")]
    Rigidbody m_rigidBody;
    [SerializeField]
    [Tooltip("Velocidad a la que se movera el personaje")]
    float speed = 5;
    [SerializeField]
    [Tooltip("Distancia del rayo que se traza para detectar el suelo")]
    float rayLenght = 1;
    [SerializeField]
    [Tooltip("Fuerza con la que es impulsado el personaje al saltar")]
    float jumpForce = 1;
    [Tooltip("Vector que sirve para recibir el imput del usuario y pasarlo como parametro al movimiento del personaje")]
    Vector3 movement;
    [SerializeField]
    [Tooltip("Define el layer con el que va a interactuar al raycast del metodo IsTouchingTheGround()")]
    LayerMask groundMask;
    [SerializeField]
    [Tooltip("Offset para posicionar el inicio del Raycast utilizado en el metodo IsTouchingTheGround()")]
    Vector3 pivotOffset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Jump(IsTouchingTheGround());
    }

    private void FixedUpdate()
    {
        MoveCharacter(GetHorizontalInput());
        Debug.DrawRay(this.transform.position - pivotOffset, Vector3.down * rayLenght, Color.red);
    }

    /*
     * Los siguientes metodos hacen parte de la mecanica de salto del personaje.
     */

    //Este metodo determina si el personaje esta tocando el suelo lanzando un RayCast desde un punto determinado hasta cualquier elemento que pertenezca al layer Ground.
    bool IsTouchingTheGround()
    {
        if (Physics.Raycast(this.transform.position - pivotOffset, Vector3.down, rayLenght, groundMask))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //Si el personaje esta tocando el suelo, y solo en el estado de juego inGame, al presionar el boton asociado al input Jump este se impulsara hacia arriba.
    void Jump(bool isTouchingTheGround)
    {
        if (GameManager.sharedInstance.currentGameState == GameState.inGame)
        {
            if (isTouchingTheGround && Input.GetButtonDown("Jump"))
            {
                //Debug.Log("Jump");
                m_rigidBody.velocity = new Vector3(m_rigidBody.velocity.x, 0f, m_rigidBody.velocity.z);
                m_rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }

    }

    /*
     * Los siguientes metodos hacen parte de la mecanica de caminar del personaje.
     */

    //Recibe el input horizontal del usuario y lo devuelve en forma de Vector3
    Vector3 GetHorizontalInput()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), m_rigidBody.velocity.y, m_rigidBody.velocity.z);
        return movement;
    }

    //Modifica la velocidad del personaje unicamente en el eje X.
    void MoveCharacter(Vector3 horizontalInput)
    {

        if (GameManager.sharedInstance.currentGameState == GameState.inGame)
        {
            FlipCharacter(horizontalInput);
            m_rigidBody.velocity = new Vector3(horizontalInput.x * speed, m_rigidBody.velocity.y, m_rigidBody.velocity.z);
        }
    }

    //Dependiendo del input del usuario el personaje observara a un lado o al otro.
    void FlipCharacter(Vector3 horizontalInput)
    {
        if (horizontalInput.x > 0f)
        {
            this.transform.right = Vector3.right;

        }
        else if (horizontalInput.x < 0f)
        {
            this.transform.right = Vector3.left;
        }
    }
}
