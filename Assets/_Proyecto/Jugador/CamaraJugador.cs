using UnityEngine;

public class CamaraJugador : MonoBehaviour
{
    [SerializeField] private Transform jugador;
    [SerializeField] private float sensibilidad = 2f;
    [SerializeField] private float limiteAnguloSuperior = 80f;
    [SerializeField] private float limiteAnguloInferior = -80f;

    [SerializeField] private float offsetAgachado = 0.5f;
    [SerializeField] private float velocidadTransicion = 8f;
    private Vector3 posicionOriginal;
    private Vector3 posicionObjetivo;

    private float rotacionVertical = 0f;

    void Awake()
    {
        if (jugador == null)
        {
            jugador = transform.parent;
        }

        posicionOriginal = transform.localPosition;
        posicionObjetivo = posicionOriginal;
    }

    void Start()
    {
        BloquearCursor();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleCursor();
        }

        if (Cursor.lockState == CursorLockMode.Locked)
        {
            float mouseX = Input.GetAxis("Mouse X") * sensibilidad;
            float mouseY = Input.GetAxis("Mouse Y") * sensibilidad;

            jugador.Rotate(0f, mouseX, 0f);

            rotacionVertical -= mouseY;
            rotacionVertical = Mathf.Clamp(rotacionVertical, limiteAnguloInferior, limiteAnguloSuperior);
            transform.localEulerAngles = new Vector3(rotacionVertical, 0f, 0f);
        }

        transform.localPosition = Vector3.Lerp(transform.localPosition, posicionObjetivo, Time.deltaTime * velocidadTransicion);
    }

    private void BloquearCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void ToggleCursor()
    {
        bool bloqueado = Cursor.lockState == CursorLockMode.Locked;
        Cursor.lockState = bloqueado ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = bloqueado;
    }

    public void CambiarAgachado(bool agachado)
    {
        posicionObjetivo = agachado
            ? posicionOriginal - new Vector3(0, offsetAgachado, 0)
            : posicionOriginal;
    }
}