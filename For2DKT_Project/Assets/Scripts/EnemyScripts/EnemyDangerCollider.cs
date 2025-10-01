using UnityEngine;

public class EnemyDangerCollider : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision) => HurtPlayer(collision);

    private void HurtPlayer(Collision2D collision)
    {
        if (collision != null)
        {
            PlayerData player = collision.gameObject.GetComponent<PlayerData>();

            if (player != null)
                player.Health.TakeDamage(1);
        }
    }
}
