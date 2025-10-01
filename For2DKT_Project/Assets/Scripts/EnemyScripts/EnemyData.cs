using UnityEngine;

public class EnemyData : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private CapsuleCollider2D _collider;
    [SerializeField] private Health _health;
    [SerializeField] private GameObject _enemyUI;

    public Animator Animator => _animator;
    public CapsuleCollider2D Collider => _collider;
    public Health Health => _health;
    public GameObject EnemyUI => _enemyUI;
}