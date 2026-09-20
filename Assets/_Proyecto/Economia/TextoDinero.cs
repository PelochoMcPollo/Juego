using UnityEngine;
using TMPro;

public class TextoDinero : MonoBehaviour
{
    [SerializeField] private GestorEconomia gestorEconomia;
    [SerializeField] private TextMeshProUGUI textoDinero;

    void Awake()
    {
        textoDinero = GetComponent<TextMeshProUGUI>();
    }
    void OnEnable()
    {
        gestorEconomia.OnDineroCambiado += ActualizarTexto;
        ActualizarTexto(gestorEconomia.ObtenerDinero());
    }

    void OnDisable()
    {
        gestorEconomia.OnDineroCambiado -= ActualizarTexto;
    }

    private void ActualizarTexto(float nuevoDinero)
    {
        textoDinero.text = "$" + nuevoDinero.ToString("F0");
    }

}
