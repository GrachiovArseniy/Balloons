using UnityEngine;

internal class ScoreSaver
{
    internal void Save(int result)
    {
        if (PlayerPrefs.HasKey("BestResult") == false)
            PlayerPrefs.SetInt("BestResult", result);
        else if (result > PlayerPrefs.GetInt("BestResult"))
            PlayerPrefs.SetInt("BestResult", result);
    }

    internal int GetBestResult()
    {
        return PlayerPrefs.GetInt("BestResult");
    }
}