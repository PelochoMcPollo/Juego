using UnityEngine;
using System.Collections;

public class MovimientoJugador: MonoBehaviour
{
    //Movimiento 
    [SerializeField] private float velocidad = 5f;
    private Vector3 direccion = Vector3.zero;

    //Salto
    [SerializeField] private float fuerzaSalto = 5f;
    [SerializeField] private float gravedad = 9.81f;
    private float velocidadVertical;

    //Camara 
    [SerializeField] private Transform camara;

    //Controlador 
    private CharacterController characterController;


    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        input = Vector3.ClampMagnitude(input, 1f);
        Vector3 movimiento = transform.TransformDirection(input) * velocidad;

        if(characterController.isGrounded)
        {
            velocidadVertical = -2f;

            if(Input.GetButtonDown("Jump"))
            {
                velocidadVertical = fuerzaSalto;
            }
        }
        else
        {
            velocidadVertical -= gravedad * Time.deltaTime;
        }

        movimiento.y = velocidadVertical;
        characterController.Move(movimiento * Time.deltaTime);
    }
}
