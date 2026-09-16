using UnityEngine;

public class CamaraJugador : MonoBehaviour
{
    [SerializeField] private Transform jugador;
    [SerializeField] private float sensibilidad = 2f;
    [SerializeField] private float limiteAnguloSuperior = 80f;
    [SerializeField] private float limiteAnguloInferior = -80f;

    private float rotacionVertical = 0f;

    void Awake()
    {
        if (jugador == null)
        {
            jugador = transform.parent;
        }
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

        if (Cursor.lockState != CursorLockMode.Locked)
        {
            return; 
        }

        float mouseX = Input.GetAxis("Mouse X") * sensibilidad;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidad;

        jugador.Rotate(0f, mouseX, 0f);

        rotacionVertical -= mouseY;
        rotacionVertical = Mathf.Clamp(rotacionVertical, limiteAnguloInferior, limiteAnguloSuperior);
        transform.localEulerAngles = new Vector3(rotacionVertical, 0f, 0f);
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
}