using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public static MenuUI instance;
    [SerializeField] private Button ResumeButton;
    [SerializeField] private Button ExitButton;
    [SerializeField] private Toggle musicToogle;
    [SerializeField]private Slider musicSlider;
    private float musicVolume;
    private bool musicPlaying;
    void Start()
    {
        if(instance == null)instance = this;
        ResumeButton.onClick.AddListener(ResumeGame);
        ExitButton.onClick.AddListener(ExitGame);
        musicSlider.onValueChanged.AddListener(ChangeVolume);
        musicToogle.onValueChanged.AddListener(TurnOffMusic);
    }
    private void OnEnable()
    {
        Time.timeScale = 0f;
    }
    private void OnDisable()
    {
        Time.timeScale = 1f;
    }
    public void ResumeGame()
    {
        this.gameObject.SetActive(false);
    }
    private void ExitGame()
    {
        SceneManager.LoadScene(0);
    }
    private void ChangeVolume(float volume)
    {
        musicVolume = volume;
        Debug.Log(musicVolume);
    }
    private void TurnOffMusic(bool isOn)
    {
        musicPlaying = isOn;
        Debug.Log(musicPlaying);
    }
    

}
