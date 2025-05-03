using UnityEngine;

public class MagnetPickup : MonoBehaviour
{
    [SerializeField] private float rotacionVel = 90f; // opcional: gira el ítem

    private void Update()
    {
        transform.Rotate(0, 0, rotacionVel * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            MagnetPower mp = other.GetComponent<MagnetPower>();
            if (mp != null)
            {
                mp.ActivarIman();
            }
            Destroy(gameObject); // Se consume el ítem
        }
    }
}


