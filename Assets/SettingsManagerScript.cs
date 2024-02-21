using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManagerScript : MonoBehaviour
{
    public MusicManagerScript musicManager;
    public Slider musicVolumeSlider; // ������������
    public Slider soundEffectsVolumeSlider; // ��Ч��������
    public GameObject settingsPanel; // ����������
    public LogicScript logic;

    // Start is called before the first frame update
    void Start()
    {
        // Ĭ�������������
        CloseSettingsPanel();

        // ��ʼ������λ��Ϊ��ǰ����
        musicVolumeSlider.value = PlayerPrefs.GetFloat("BGMVolume",0.25f);
        soundEffectsVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume",0.75f);

        // ������ƵԴ������
        musicManager.BGMAudioSource.volume = musicVolumeSlider.value;
        musicManager.soundEffectsAudioSource.volume = soundEffectsVolumeSlider.value;

        // ��ӻ���ļ�����
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

    // Ӧ�����ò��ر��������
    public void ApplySettings()
    {
        PlayerPrefs.SetFloat("BGMVolume", musicVolumeSlider.value);
        PlayerPrefs.SetFloat("SFXVolume", soundEffectsVolumeSlider.value);
        PlayerPrefs.Save(); // ��������
    }

    // ��ʾ�������
    public void OpenSettingsPanel()
    {
        settingsPanel.SetActive(true);
        logic.CloseGameStartScreen();
    }
    //�ر��������
    public void CloseSettingsPanel()
    {
        settingsPanel.SetActive(false);
        logic.OpenGameStartScreen();
    }


}
