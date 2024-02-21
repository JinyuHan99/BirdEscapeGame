using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManagerScript : MonoBehaviour
{
    public MusicManagerScript musicManager;
    public Slider musicVolumeSlider; // 音乐音量滑块
    public Slider soundEffectsVolumeSlider; // 音效音量滑块
    public GameObject settingsPanel; // 设置面板对象
    public LogicScript logic;

    // Start is called before the first frame update
    void Start()
    {
        // 默认隐藏设置面板
        CloseSettingsPanel();

        // 初始化滑块位置为当前音量
        musicVolumeSlider.value = PlayerPrefs.GetFloat("BGMVolume",0.25f);
        soundEffectsVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume",0.75f);

        // 更新音频源的音量
        musicManager.BGMAudioSource.volume = musicVolumeSlider.value;
        musicManager.soundEffectsAudioSource.volume = soundEffectsVolumeSlider.value;

        // 添加滑块的监听器
        musicVolumeSlider.onValueChanged.AddListener(delegate { OnBGMVolumeChange(musicVolumeSlider.value); });
        soundEffectsVolumeSlider.onValueChanged.AddListener(delegate { OnSoundEffectsVolumeChange(soundEffectsVolumeSlider.value); });


    }



    public void OnBGMVolumeChange(float volume)
    {
        SetVolume(musicManager.BGMAudioSource, musicVolumeSlider.value);
    }

    public void OnSoundEffectsVolumeChange(float volume)
    {
        if (musicManager != null)
        {
            musicManager.soundEffectsAudioSource.volume = soundEffectsVolumeSlider.value;
            musicManager.PlayJumpSound();
        }
    }

    public void SetVolume(AudioSource audioSource,float volume)
    {
        if (musicManager != null && !musicManager.isFadingOut)
        {
            audioSource.volume = volume;
        }
    }

    // 应用设置并关闭设置面板
    public void ApplySettings()
    {
        PlayerPrefs.SetFloat("BGMVolume", musicVolumeSlider.value);
        PlayerPrefs.SetFloat("SFXVolume", soundEffectsVolumeSlider.value);
        PlayerPrefs.Save(); // 保存设置
    }

    // 显示设置面板
    public void OpenSettingsPanel()
    {
        settingsPanel.SetActive(true);
        logic.CloseGameStartScreen();
    }
    //关闭设置面板
    public void CloseSettingsPanel()
    {
        settingsPanel.SetActive(false);
        logic.OpenGameStartScreen();
    }


}
