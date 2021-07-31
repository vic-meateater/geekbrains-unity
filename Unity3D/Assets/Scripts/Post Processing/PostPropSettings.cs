using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostPropSettings : MonoBehaviour
{
    private PostProcessVolume _postProcessVolume;
    private ColorGrading _colorGrading;

    private float _saturationValue;

    private void Start()
    {
        SettigsColorGrading();

        _postProcessVolume = PostProcessManager.instance.QuickVolume(gameObject.layer, 2, _colorGrading);
        _saturationValue = -100f;
        _colorGrading.saturation.value = _saturationValue;
    }


    private void Update()
    {
        if(_saturationValue < 0)
        {
            _colorGrading.saturation.value = _saturationValue += 12f * Time.deltaTime;
        }
    }
    private void SettigsColorGrading()
    {
        _colorGrading = ScriptableObject.CreateInstance<ColorGrading>();
        _colorGrading.enabled.Override(true);
        _colorGrading.saturation.Override(0f);
    }
}
