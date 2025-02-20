using UnityEngine;

public class FloorCurrentDetector : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bubble"))
        {
            Vida bubbleHealth = other.GetComponent<Vida>();

            if (bubbleHealth.cantidad_vida == 1)
            {
                bubbleHealth.bubbleDamage(true);

            }

        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("bubble"))
        {
            Vida bubbleHealth = other.GetComponent<Vida>();

            if (bubbleHealth.cantidad_vida != 1)
            {
                bubbleHealth.bubbleDamage(true);

            }

        }

    }
}
