using UnityEngine;

public class Puerta : MonoBehaviour, IInteractuable
{
    [SerializeField] private float anguloApertura = 90f;
    private bool abierta = false;

    private Quaternion rotacionCerrada;
    private Quaternion rotacionAbierta;

    void Awake()
    {
        rotacionCerrada = transform.rotation;
        rotacionAbierta = rotacionCerrada * Quaternion.Euler(0f, anguloApertura, 0f);
    }

    public void Interactuar()
    {
        abierta = !abierta;
        transform.rotation = abierta ? rotacionAbierta : rotacionCerrada;
    }
}