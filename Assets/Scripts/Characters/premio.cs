using UnityEngine;

public class premio : MonoBehaviour
{

    [SerializeField] int valorMoneda;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            recolectar recolector = other.GetComponent<recolectar>();

            recolector.comprobacion(valorMoneda);

            Destroy(gameObject);

        }



    }

}
