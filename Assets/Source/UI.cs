using UnityEngine;
using UnityEngine.UI;

internal class UI : MonoBehaviour
{
    [SerializeField] private ScorePresenter _scorePresenter;
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private Text _bestResultText;
    [SerializeField] private Text _resultText;

    private readonly ScoreSaver _scoreSaver = new ScoreSaver();

    public void OpenPausePanel()
    {
        _pausePanel.SetActive(true);
    }

    public void ClosePausePanel()
    {
        _pausePanel.SetActive(false);
    }

    public void OpenLosePanel()
    {
        _scoreSaver.Save(_scorePresenter.Score);
        _bestResultText.text = $"Best result: {_scoreSaver.GetBestResult().ToString()}";
        _resultText.text = $"Result: {_scorePresenter.Score.ToString()}";
        _losePanel.SetActive(true);
    }

    public void CloseLosePanel()
    {
        _losePanel.SetActive(false);
    }
}
