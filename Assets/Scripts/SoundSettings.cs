using UnityEngine;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;

    private void Start()
    {
        volumeSlider.minValue = -80;
        volumeSlider.maxValue = 20;
        volumeSlider.onValueChanged.AddListener(SetVolume);
        LoadVolumeSettings(); 
    }

    private void SetVolume(float volume)
    {
        SoundManager.Instance.SetVolume(volume);
        PlayerPrefs.SetFloat("Volume", volume); 
    }

    private void LoadVolumeSettings()
    {
        if (PlayerPrefs.HasKey("Volume"))
        {
            float savedVolume = PlayerPrefs.GetFloat("Volume");
            volumeSlider.value = savedVolume;
            SetVolume(savedVolume);
        }
    }
}
