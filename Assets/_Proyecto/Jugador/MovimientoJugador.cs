using UnityEngine;
using System.Collections;

public class MovimientoJugador: MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float velocidad = 5f;
    [SerializeField] private Transform camara;
    private CharacterController characterController;
    private Vector3 direccion = Vector3.zero;

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
        direccion = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        direccion = transform.TransformDirection(direccion);
        direccion *= velocidad;

        characterController.Move(direccion * Time.deltaTime);

    }
}
