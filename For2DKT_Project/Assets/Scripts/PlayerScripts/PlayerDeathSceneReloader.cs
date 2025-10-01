using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeathSceneReloader : MonoBehaviour
{
    [SerializeField] private PlayerData _playerData;

    private void Awake() => _playerData.Health.OnHealthZero += RestartScene;

    private void OnDestroy() => _playerData.Health.OnHealthZero -= RestartScene;

    private void RestartScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}
