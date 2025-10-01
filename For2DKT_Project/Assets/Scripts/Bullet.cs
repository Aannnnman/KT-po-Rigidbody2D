using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private LayerMask _whatIsCollision;

    private void Start() => Destroy(gameObject, 5f);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (((1 << collision.gameObject.layer) & _whatIsCollision.value) != 0)
            {
                Health health = collision.GetComponent<Health>();

                if (health != null)
                    health.TakeDamage(1);

                _animator.SetTrigger("Destroy");
                _rigidbody.velocity = Vector2.zero;
                Destroy(gameObject, 0.45f);
            }
        }
    }
}
