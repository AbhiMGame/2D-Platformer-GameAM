using UnityEngine;

public class KeyController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
        if (playerController!=null)
        {
            playerController.PickupKey();
            Destroy(gameObject);
        }
    }
}
