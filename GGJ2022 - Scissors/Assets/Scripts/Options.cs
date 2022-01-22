using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Options : MonoBehaviour
{
    // string to load main menu
    public string backToMainMenu;

    // reference to audiomixer

    public AudioMixer masterMixer;

    #region Attributes

    #region Player Preference 
    private const string RESOLUTION_PREFERENCE = "resolution";

    #endregion

    #region Resolution
    [SerializeField]
    private Text resolutionText;

    private Resolution[] resolutions;

    private int currResolution=0;

    #endregion

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions;
        currResolution = PlayerPrefs.GetInt(RESOLUTION_PREFERENCE,0);
        SetResolutionText(resolutions[currResolution]);
    }
    #region Resolution Cycling
    public void SetResolutionText(Resolution resolution) 
    {
        resolutionText.text = resolution.width + "x" + resolution.height;
    }
    public void SetNextResolution()
    {
        currResolution = GetNextWrappedIndex(resolutions, currResolution);
        SetResolutionText(resolutions[currResolution]);
    }
    public void SetPreviousResolution()
    {
        currResolution = GetPreviousWrappedIndex(resolutions, currResolution);
        SetResolutionText(resolutions[currResolution]);
    }
    #endregion
    #region Apply Resolutions
    public void SetAndApplyResolution(int newResolution) 
    {
        currResolution = newResolution;
        ApplyCurrentResolution();
    }
    public void ApplyCurrentResolution() 
    {
        ApplyResolution(resolutions[currResolution]);
    }
    public void ApplyResolution(Resolution resolution) 
    {
        SetResolutionText(resolution);
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        PlayerPrefs.SetInt(RESOLUTION_PREFERENCE, currResolution);
    }
    #endregion
    // when btnBackToMain is clicked this function will run
    #region Helper Functions
    public void BackToMain()
    {
        SceneManager.LoadScene(backToMainMenu);
    }
    private int GetNextWrappedIndex<T>(IList<T> collection, int currIndex) 
    {
        if (collection.Count < 1) return 0;
        return (currIndex + 1) % collection.Count;
    
    }
    private int GetPreviousWrappedIndex<T>(IList<T> collection, int currIndex) 
    {
        if (collection.Count < 1) return 0;
        if ((currIndex - 1) < 0) return collection.Count - 1;
        return (currIndex - 1) % collection.Count - 1;
    }
    public void ApplyChanges() 
    {
        SetAndApplyResolution(currResolution);
    }
    public void SetVolume(float volume) 
    {
        // set master mixer audio level
        masterMixer.SetFloat("volume", volume);
    }

    public void setFullScreen(bool isFullscreen) 
    {
        Screen.fullScreen = isFullscreen;
    }

}
#endregion
