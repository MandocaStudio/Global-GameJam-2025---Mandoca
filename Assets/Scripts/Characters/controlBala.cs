using UnityEngine;

public class controlBala : MonoBehaviour
{
    Rigidbody balaRB;
    public float potencia = 100f;
    public float lifeTime = 3f;
    private float time = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        balaRB = GetComponent<Rigidbody>();
        balaRB.linearVelocity = this.transform.forward * potencia;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time += Time.deltaTime;
        if (time >= lifeTime){
            Destroy(this.gameObject);
        }
    }
}
