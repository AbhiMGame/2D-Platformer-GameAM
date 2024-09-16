using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerController>()!=null)
        {
           collision.GetComponent<HealthController>().TakeDamage(damage);

        }
    }

}
