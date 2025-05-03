using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class MagnetPower : MonoBehaviour
{
    [Header("Parámetros del imán")]
    [SerializeField] private float radioIman = 5f;      // Alcance
    [SerializeField] private float fuerzaIman = 15f;    // Intensidad de atracción
    [SerializeField] private float duracionIman = 5f;   // Segundos activo

    private bool imanActivo = false;

    void Update()
    {
        if (!imanActivo) return;

        // Detecta todos los colliders 2D en el radio
        Collider2D[] objetos = Physics2D.OverlapCircleAll(transform.position, radioIman);
        foreach (Collider2D col in objetos)
        {
            if (col.CompareTag("Collectible"))
            {
                Rigidbody2D rb = col.attachedRigidbody;
                if (rb != null)
                {
                    // Dirección hacia el jugador
                    Vector2 dir = (transform.position - col.transform.position).normalized;
                    rb.AddForce(dir * fuerzaIman);
                }
            }
        }
    }

    /// <summary> Activa el imán desde otro script. </summary>
    public void ActivarIman()
    {
        if (gameObject.activeInHierarchy)
            StartCoroutine(ImanRoutine());
    }

    private IEnumerator ImanRoutine()
    {
        imanActivo = true;
        yield return new WaitForSeconds(duracionIman);
        imanActivo = false;
    }

#if UNITY_EDITOR
    // Solo para dibujar el radio en el editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, radioIman);
    }
#endif
}
