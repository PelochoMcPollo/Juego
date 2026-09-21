using System;
using UnityEngine;

public class GestorEconomia : MonoBehaviour
{
    [SerializeField] private float dinero;
    public event Action<float> OnDineroCambiado;

    public void SumarDinero(float cantidad)
    {
        dinero += cantidad;
        OnDineroCambiado?.Invoke(dinero);
    }

    public bool RestarDinero(float cantidad)
    {
        if (dinero - cantidad >= 0)
        {
            dinero -= cantidad;
            OnDineroCambiado?.Invoke(dinero);
            return true;
        }
        return false;
    }
    public float ObtenerDinero()
    {
        return dinero;
    }
}
