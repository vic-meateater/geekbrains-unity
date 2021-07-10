using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Menu : MonoBehaviour
{
    //VARIABLES
    [SerializeField] private Button _btnPlay;
    [SerializeField] private Button _btnQuit;
    [SerializeField] private Toggle _tglMute;
    [SerializeField] private Slider _sldrAllVolume;
    [SerializeField] private Slider _sldrBackgroundVolume;
    [SerializeField] private Slider _sldrSFXVolume;
    [SerializeField] private float _multiplier = 30f;
    public AudioMixer _AudioMixer;
    private bool _isMuted;
    private float _volume;
    private string _allVolume = "allVolume";
    private string _backgroundVolume = "backgroundVolume";
    private string _sfxVolume = "SFXVolume";



    public void Awake()
    {
        _btnPlay.onClick.AddListener(StartGame);
        _btnQuit.onClick.AddListener(QuitGame);
        _tglMute.onValueChanged.AddListener(Mute);
        _sldrAllVolume.onValueChanged.AddListener(Volume);
        _sldrBackgroundVolume.onValueChanged.AddListener(VolumeBackground);
        _sldrSFXVolume.onValueChanged.AddListener(VolumeSFX);
    }
    private void OnDisable()
    {
        PlayerPrefs.SetFloat(_allVolume, _sldrAllVolume.value);
        PlayerPrefs.SetFloat(_backgroundVolume, _sldrAllVolume.value);
        PlayerPrefs.SetFloat(_sfxVolume, _sldrAllVolume.value);
    }
    private void Start()
    {
        _sldrAllVolume.value = PlayerPrefs.GetFloat(_allVolume, _sldrAllVolume.value);
        _sldrBackgroundVolume.value = PlayerPrefs.GetFloat(_backgroundVolume, _sldrBackgroundVolume.value);
        _sldrSFXVolume.value = PlayerPrefs.GetFloat(_sfxVolume, _sldrSFXVolume.value);
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void Mute(bool value)
    {
        _isMuted = value;
        
        if (_isMuted)
        {
            _sldrAllVolume.value = _sldrAllVolume.minValue;
            _sldrBackgroundVolume.value = _sldrBackgroundVolume.minValue;
            _sldrSFXVolume.value = _sldrSFXVolume.minValue;
        }
        else
        {
            _sldrAllVolume.value = _sldrAllVolume.maxValue;
            _sldrBackgroundVolume.value = _sldrBackgroundVolume.maxValue;
            _sldrSFXVolume.value = _sldrSFXVolume.maxValue;

        }
    }

    private void Volume(float value)
    {
        _volume = value;
        _AudioMixer.SetFloat(_allVolume, Mathf.Log10(_volume) * _multiplier);
    }
    private void VolumeBackground(float value)
    {
        _volume = value;
        _AudioMixer.SetFloat(_backgroundVolume, Mathf.Log10(_volume) * _multiplier);
    }
    private void VolumeSFX(float value)
    {
        _volume = value;
        _AudioMixer.SetFloat(_sfxVolume, Mathf.Log10(_volume) * _multiplier);
    }
}
