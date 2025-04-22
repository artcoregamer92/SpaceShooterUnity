using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    private Slider slider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void CambiarVidaMaxima(float vidaMaxima)
    {
        slider.value = vidaMaxima;
    }

    public void CambiarVidaActual(float cantidadVida)
    {
        slider.value = cantidadVida;
    }

    public void InicializarBarraDeVida(float cantidadVida)
    {
        CambiarVidaMaxima(cantidadVida);
        CambiarVidaActual(cantidadVida);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
