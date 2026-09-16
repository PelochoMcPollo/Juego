using UnityEngine;
using System.Collections;

public class MovimientoJugador: MonoBehaviour
{
    //Movimiento 
    [SerializeField] private float velocidad = 5f;
    [SerializeField] private float multiplicadorCorrer = 2.0f;
    [SerializeField] private float multiplicadorSaltar = 1.3f;
    //Salto
    [SerializeField] private float fuerzaSalto = 5f;
    [SerializeField] private float gravedad = 9.81f;
    private float velocidadVertical;

    //Controlador 
    private CharacterController characterController;


    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        input = Vector3.ClampMagnitude(input, 1f);

        float velocidadActual = Input.GetKey(KeyCode.LeftShift) ? velocidad * multiplicadorCorrer : velocidad;

        Vector3 movimiento = transform.TransformDirection(input) * velocidadActual;

        if(characterController.isGrounded)
        {
            velocidadVertical = -2f;

            if(Input.GetButtonDown("Jump"))
            {
                velocidadVertical = Input.GetKey(KeyCode.LeftShift) ? fuerzaSalto * multiplicadorSaltar : fuerzaSalto;
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
