using Balloons.Model;
using UnityEngine;
using UnityEngine.UI;

internal class ScorePresenter : MonoBehaviour
{
    public int Score => _score.Value;

    private Score _score;
    private Text _text;

    internal void Init(Score scoreModel, Text text)
    {
        _score = scoreModel;
        _text = text;
        enabled = true;
    }

    private void OnEnable()
    {
        _score.Changed += OnScoreChanged;
    }

    private void OnDisable()
    {
        _score.Changed += OnScoreChanged;
    }

    private void OnScoreChanged()
    {
        _text.text = _score.Value.ToString();
    }
}