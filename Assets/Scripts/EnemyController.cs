using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
           collision.GetComponent<HealthController>().TakeDamage(damage);
        }
    }

}
