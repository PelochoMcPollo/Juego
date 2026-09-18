using UnityEngine;

public class ObjetoAgarrable : MonoBehaviour, IAgarrable
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Collider co;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        co = GetComponent<Collider>();
    }
    public void Coger()
    {
        rb.isKinematic = true;
        co.enabled = false;

    }
    public void Soltar()
    {
        rb.isKinematic = false;
        co.enabled = true;

    }

}
