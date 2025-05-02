using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    [SerializeField] private Slider slider;  // <- Asegura la referencia desde el Inspector

    public void CambiarVidaMaxima(float vidaMaxima)
    {
        if (slider != null)
            slider.maxValue = vidaMaxima;
    }

    public void CambiarVidaActual(float cantidadVida)
    {
        if (slider != null)
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


