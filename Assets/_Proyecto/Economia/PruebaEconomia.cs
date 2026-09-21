using UnityEngine;

public class PruebaEconomia : MonoBehaviour
{
    [SerializeField] private GestorEconomia gestorEconomia;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            gestorEconomia.SumarDinero(10.0f);
        }
        if(Input.GetKeyDown(KeyCode.M))
        {
            gestorEconomia.RestarDinero(10.0f);
        }
    }
}
