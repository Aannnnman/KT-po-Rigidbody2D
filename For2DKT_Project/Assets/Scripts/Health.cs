using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public event Action OnTakeDamage;
    public event Action OnHealthZero;

    [SerializeField] private int _health;
    [SerializeField] private Text _healthText;

    private void Awake() => UpdateHealthTextUI();

    public void TakeDamage(int damage)
    {
        _health -= damage;

        UpdateHealthTextUI();
        StartCoroutine(ChangeHealthColorText(Color.red));

        if (_health <= 0)
        {
            OnHealthZero?.Invoke();
            return;
        }

        OnTakeDamage?.Invoke();
    }

    private void UpdateHealthTextUI() => _healthText.text = "Health: " + _health.ToString();

    private IEnumerator ChangeHealthColorText(Color whatToChangeColor)
    {
        Color originColor = _healthText.color;
        _healthText.color = whatToChangeColor;

        yield return new WaitForSeconds(0.13f);
        _healthText.color = originColor;
    }
}
