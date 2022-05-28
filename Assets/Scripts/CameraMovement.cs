using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Tooltip("Transform al que va a seguir la camara")]
    public Transform target;
    [Tooltip("Offset de la camara con respecto al Player")]
    public Vector3 offset;
    [Tooltip("Vector que sirve para calcular el movimiento de la camara")]
    public Vector3 velocity = Vector3.zero;
    [Tooltip("Tiempo de respuesta del movimiento de la camara")]
    public float dampingTime = 0.3f;
    [Tooltip("Borde vertical donde el eje vertical de la camara se hace igual al del player")]
    public float verticalCameraBoundry = 3;
    [Tooltip("Instancia compartida de la camara")]
    public static CameraMovement sharedInstance;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = target.transform.position + offset;
    }

    private void FixedUpdate()
    {
        MoveCamera();
    }

    void MoveCamera()
    {
        Vector3 destination;

        //El siguiente codigo comentado se utilizaria si el movimiento vertical de la camara fuera fijo hasta llegar a un borde

        /*if (target.position.y > verticalCameraBoundry)
        {
            destination = new Vector3(target.position.x + offset.x, target.position.y + verticalCameraBoundry, offset.z);
        }
        else
        {
            destination = new Vector3( target.position.x + offset.x, offset.y, offset.z );
        }*/

        destination = new Vector3(target.position.x + offset.x, target.position.y + offset.y, offset.z);

        this.transform.position = Vector3.SmoothDamp(this.transform.position, destination, ref velocity, dampingTime);
    }

}
