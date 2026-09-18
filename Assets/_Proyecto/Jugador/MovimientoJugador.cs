using UnityEngine;
using System.Collections;

public class MovimientoJugador : MonoBehaviour
{
    //Movimiento 
    [SerializeField] private float velocidad = 5f;
    [SerializeField] private float multiplicadorCorrer = 2.0f;
    [SerializeField] private float multiplicadorSaltar = 1.3f;
    [SerializeField] private float multiplicadorAgacharse = 0.8f;

    //Salto
    [SerializeField] private float fuerzaSalto = 5f;
    [SerializeField] private float gravedad = 9.81f;
    private float velocidadVertical;

    //Controlador 
    private CharacterController characterController;
    private float altura;
    private Vector3 centro;
    private float radio;
    [SerializeField] private LayerMask capaEntorno;
    //Estado
    [SerializeField] private bool agachado = false;
    [SerializeField] private bool levantarse = false;

    [SerializeField] private CamaraJugador camaraJugador;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        altura = characterController.height;
        centro = characterController.center;
        radio = characterController.radius;

        if (camaraJugador == null)
        {
            camaraJugador = GetComponentInChildren<CamaraJugador>();
        }
    }
    void Start()
    {

    }

    void Update()
    {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        input = Vector3.ClampMagnitude(input, 1f);
        //velovidades
        float velocidadActual = velocidad;
        //Velociad/Correr
        if (Input.GetKey(KeyCode.LeftShift))
        {
            velocidadActual *= multiplicadorCorrer;
        }

        //velovidad/agacharse
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            agachado = true;
            characterController.center = new Vector3(centro.x, centro.y / 2, centro.z);
            characterController.height = altura / 2;
            camaraJugador.CambiarAgachado(true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            levantarse = true;
        }
        if (agachado)
        {
            velocidadActual *= multiplicadorAgacharse;
        }
        if (levantarse)
        {
            if (!HayObstaculo())
            {
                LevantarPersonaje();
                levantarse = false;
            }
        }

        Vector3 movimiento = transform.TransformDirection(input) * velocidadActual;

        //salto
        if (characterController.isGrounded)
        {
            velocidadVertical = -2f;

            if (Input.GetButtonDown("Jump"))
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

    private bool HayObstaculo()
    {
        float mitadCilindro = (altura / 2f) - radio;
        Vector3 centroMundo = transform.position + centro;
        Vector3 puntoArriba = centroMundo + transform.up * mitadCilindro;
        Vector3 puntoAbajo = centroMundo - transform.up * mitadCilindro;

        return Physics.CheckCapsule(puntoArriba, puntoAbajo, radio, capaEntorno);
    }

    private void LevantarPersonaje()
    {
        agachado = false;
        characterController.center = new Vector3(centro.x, centro.y, centro.z);
        characterController.height = altura;
        camaraJugador.CambiarAgachado(false);
    }
}
