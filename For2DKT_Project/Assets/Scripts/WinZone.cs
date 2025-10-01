using UnityEngine;
using UnityEngine.UI;

public class WinZone : MonoBehaviour
{
    [SerializeField] private Text _winText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            EnemyData enemy = collision.GetComponent<EnemyData>();

            if (enemy != null)
                Win();
        }
    }

    private void Win() => _winText.gameObject.SetActive(true);
}
