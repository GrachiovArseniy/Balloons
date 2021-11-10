using UnityEngine;

internal class TimePresenter : MonoBehaviour
{
    private Balloons.Model.Time _timeModel;
    private UI _ui;
    private bool _paused = false;

    internal void Init(Balloons.Model.Time timeModel, UI ui)
    {
        _timeModel = timeModel;
        _ui = ui;
        enabled = true;
    }

    public void OpenLosePanel()
    {
        _paused = true;
        _ui.OpenLosePanel();
    }

    public void PutOnPause()
    {
        _paused = true;
    }

    public void Resume()
    {
        _paused = false;
    }

    public void Restart()
    {
        _timeModel.StopGame();
        _paused = false;
    }

    private void Update()
    {
        if (_paused)
            return;

        _timeModel.UpdateAll(Time.deltaTime);
    }
}