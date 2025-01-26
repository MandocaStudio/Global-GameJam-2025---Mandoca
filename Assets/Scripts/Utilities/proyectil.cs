using System.Collections;
using UnityEngine;

public class proyectil : MonoBehaviour
{
    public float bulletEffect;

    public bool disparo = false;
    private void Update()
    {
        if (disparo.GetKeyDown("Fire2")){
            //enemigo =  GameObject.FindGameObjectsWithTag("Enemy");
            //disparo = true;
            private void OnCollisionEnter(Collision other){
                if (other.collider.CompareTag("Enemy")){
                    enemigo.transform.position = Vector3 + 1;
                }
            }
            
        }
         if (disparo.GetKeyDown("Fire3")){
            //enemigo =  GameObject.FindGameObjectsWithTag("Enemy");
            //disparo = true;
            private void OnCollisionEnter(Collision other){
                if (other.collider.CompareTag("Enemy")){
                    enemigo.transform.position = Vector3 - 1;
                }
            }
        }
    }
    
     
    // private void OnCollisionEnter(Collision other)
    // {
    //     if (other.collider.CompareTag("Enemy"))
    //     {
    //         Destroy(gameObject);

    //         if (other.collider.CompareTag("Enemy"))
    //         {
    //             EnemyStats enemyStats = other.collider.GetComponent<EnemyStats>();
    //             if (enemyStats != null)
    //             {
    //                 enemyStats.TakeDamage(bulletDamage);
    //             }
    //         }
    //     }

    //     if (!other.collider.CompareTag("Player"))
    //     {
    //         Destroy(gameObject);
    //     }
    // }

}



