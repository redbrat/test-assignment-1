using System;
using UnityEngine;
using Zenject;

[Serializable]
public class CoreGameModel
{
    private const string MODEL_KEY = nameof(MODEL_KEY);

    public int PictureId => pictureId;
    public int PatternId => patternId;
    
    [SerializeField] private int pictureId = -1;
    [SerializeField] private int patternId = -1;

    [Inject]
    private void Init()
    {
        Load();
    }

    public void SetPictureId(int pictureId)
    {
        this.pictureId = pictureId;
        Save();
    }

    public void SetPattern(int patternId)
    {
        this.patternId = patternId;
        Save();
    }

    private void Save()
    {
        var json = JsonUtility.ToJson(this);
        PlayerPrefs.SetString(MODEL_KEY, json);
        PlayerPrefs.Save();
    }

    private void Load()
    {
        if (!PlayerPrefs.HasKey(MODEL_KEY))
        {
            return;
        }

        var json = PlayerPrefs.GetString(MODEL_KEY);
        JsonUtility.FromJsonOverwrite(json, this);
    }
}
