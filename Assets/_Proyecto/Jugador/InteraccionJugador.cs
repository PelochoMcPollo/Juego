using UnityEngine;

public class InteraccionJugador : MonoBehaviour
{
    [SerializeField] private Transform camara;
    [SerializeField] private float distanciaInteraccion = 5.0f;
    [SerializeField] private LayerMask capaInteractuable;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(camara.position, camara.forward, out RaycastHit hit, distanciaInteraccion, capaInteractuable))
            {
                IInteractuable interactuable = hit.collider.GetComponent<IInteractuable>();
                if (interactuable != null)
                {
                    interactuable.Interactuar();
                }
            }
        }
    }

}
