using Balloons.Model;
using UnityEngine;
using UnityEngine.UI;

internal class Root : MonoBehaviour
{
    [Header("Presenters")]

    [SerializeField] private BalloonSpawnerPresenter _balloonSpawnerPresenter;
    [SerializeField] private TimePresenter _timePresenter;
    [SerializeField] private ScorePresenter _scorePresenter;
    [SerializeField] private PlayerHealthPresenter _playerHealthPresenter;

    [Header("UI")]

    [SerializeField] private UI _ui;
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _healthText;

    [Header("Prefabs")]

    [SerializeField] private GameObject _balloon;

    private BalloonSpawner _balloonSpawner;
    private Balloons.Model.Time _time;
    private Score _score;
    private PlayerHealth _playerHealth;
    private FieldBorder _fieldBorder;

    private void Awake()
    {
        _score = new Score();
        _playerHealth = new PlayerHealth();
        _fieldBorder = new FieldBorder(Config.DownGameFieldBorder);
        _balloonSpawner = new BalloonSpawner(_playerHealth);
        _time = new Balloons.Model.Time(_balloonSpawner, _fieldBorder, _playerHealth, _score);
        _balloonSpawner.SetTime(_time);

        _balloonSpawnerPresenter.Init(_balloonSpawner, _balloon);
        _timePresenter.Init(_time, _ui);
        _scorePresenter.Init(_score, _scoreText);
        _playerHealthPresenter.Init(_playerHealth, _timePresenter, _healthText);
    }
}
