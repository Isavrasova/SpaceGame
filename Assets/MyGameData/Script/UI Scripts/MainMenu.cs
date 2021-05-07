using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _startGame;
    [SerializeField] private Button _exit;
    [SerializeField] private Button _settings;
    [SerializeField] private Toggle _muteSound;
    [SerializeField] private Slider _volume;
    
    

    private void Awake()
    {
       
        _startGame.onClick.AddListener(StartGame);
        _exit.onClick.AddListener(Exit);
        _muteSound.onValueChanged.AddListener(SetMuteSound);
        _volume.value = _volume.maxValue * 0.8f;
    }

    private void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    private void Exit()
    {
        Application.Quit();
    }

    private void Settings()
    {

    }
    private void SetMuteSound(bool isMute)
    {

    }

    private void SetVolume(float _volume)
    {
        int volume = (int)_volume;
    }
}
