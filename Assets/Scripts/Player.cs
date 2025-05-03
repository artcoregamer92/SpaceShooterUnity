using UnityEngine;
using UnityEngine.Video;

public class Player : MonoBehaviour
{
    [SerializeField] private float velocidad;

    [SerializeField] private float ratioDisparo;
    [SerializeField] private GameObject disparoPrefab;
    [SerializeField] private GameObject spawnPoint1;
    [SerializeField] private GameObject spawnPoint2;

    [Header("Vida")]
    [SerializeField] private float maximoVida = 100f;
    [SerializeField] private BarraDeVida barraDeVida;

    private float vida;
    private float temporizador = 0.5f;
    public GameOverManager gameOverManager; // asignar desde el Inspector

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vida = maximoVida;
        Debug.Log("Vida inicial: " + vida); // <- Te dice si vida está bien
        barraDeVida.InicializarBarraDeVida(vida);
    }

    

    // Update is called once per frame
    void Update()
    {
        Movimiento();
        DelimitarMovimiento();
        Disparar();
    }
    void Movimiento()
    {
        float inputH = Input.GetAxisRaw("Horizontal");
        float inputV = Input.GetAxisRaw("Vertical");
        Vector3 direccion = new Vector3(inputH, inputV).normalized; 
        transform.Translate(direccion * velocidad * Time.deltaTime);
    }

    void DelimitarMovimiento()
    {
        float xClamped = Mathf.Clamp(transform.position.x, -8.4f, 8.4f);
        float yClamped = Mathf.Clamp(transform.position.y, -4.5f, 4.5f);
        transform.position = new Vector3(xClamped, yClamped, 0f);
    }
    void Disparar()
    {
        temporizador += Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && temporizador > ratioDisparo)
        {
            Instantiate(disparoPrefab, spawnPoint1.transform.position, Quaternion.identity);
            Instantiate(disparoPrefab, spawnPoint2.transform.position, Quaternion.identity);
            temporizador = 0f;
        }
    }

    public void TomarDaño(float daño)
    {
        vida -= daño;
        vida = Mathf.Max(vida, 0f);

        if (barraDeVida != null)
            barraDeVida.CambiarVidaActual(vida);

        if (vida <= 0)
        {
            vida = 0;

            if (gameOverManager != null)
                gameOverManager.ActivarGameOver();

            gameObject.SetActive(false);
        }
    }



    public void Curar(float curacion)
    {
        vida = Mathf.Min(vida + curacion, maximoVida);

        if (barraDeVida != null)
            barraDeVida.CambiarVidaActual(vida);
    }

    private void OnTriggerEnter2D(Collider2D elOtro)
    {
        if (elOtro.CompareTag("DisparoEnemigo") || elOtro.CompareTag("Enemigo"))
        {
            Destroy(elOtro.gameObject);
            TomarDaño(20f);
        }
    }
}
