using System;
using UnityEngine;

public class CogerObjetoJugador : MonoBehaviour
{
    [SerializeField] private Transform camara;
    [SerializeField] private float distanciaInteraccion = 5.0f;
    [SerializeField] private LayerMask capaInteractuable;
    [SerializeField] private Transform puntoAnclaje;
    [SerializeField] private Transform objeto;
    private IAgarrable agarrable;
    [SerializeField] private bool cogido = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!cogido)
            {
                if (Physics.Raycast(camara.position, camara.forward, out RaycastHit hit, distanciaInteraccion, capaInteractuable))
                {
                    agarrable = hit.collider.GetComponent<IAgarrable>();
                    if (agarrable != null)
                    {
                        objeto = hit.transform;
                        objeto.SetParent(puntoAnclaje);
                        objeto.localPosition = Vector3.zero;
                        objeto.localRotation = Quaternion.identity;
                        agarrable.Coger();
                        cogido = true;
                    }
                }
            }
            else if (cogido)
            {
                if (agarrable != null)
                {
                    objeto.SetParent(null);
                    agarrable.Soltar();
                    cogido = false;
                }
            }
        }
    }
}
