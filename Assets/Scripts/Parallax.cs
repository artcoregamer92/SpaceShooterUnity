using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private Vector3 direccion;
    [SerializeField] private float anchoImagen;

    private Vector3 posicionInicial;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        posicionInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Resto: cu�nto me queda de recorrido para alcanzar un nuevo ciclo.
        float resto = (velocidad * Time.time) % anchoImagen;

        //Mi posici�n se va refrescando desde la inicial sumando tanto como resto me quede en la direcci�n deseada.
        transform.position = posicionInicial + resto * direccion;
    }
}
