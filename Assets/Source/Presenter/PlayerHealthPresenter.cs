using Balloons.Model;
using UnityEngine;
using UnityEngine.UI;

internal class PlayerHealthPresenter : MonoBehaviour
{
    private PlayerHealth _playerHealth;
    private TimePresenter _timePresenter;
    private Text _text;

    internal void Init(PlayerHealth playerHealth, TimePresenter timePresenter, Text text)
    {
        _playerHealth = playerHealth;
        _timePresenter = timePresenter;
        _text = text;
        enabled = true;
    }

    private void OnEnable()
    {
        _playerHealth.GameLosted += OnGameLosted;
        _playerHealth.Changed += OnHealthChanged;
    }

    private void OnDisable()
    {
        _playerHealth.GameLosted -= OnGameLosted;
        _playerHealth.Changed -= OnHealthChanged;
    }

    private void OnHealthChanged()
    {
        _text.text = _playerHealth.Value.ToString();
    }

    private void OnGameLosted()
    {
        _timePresenter.OpenLosePanel();
    }
}
