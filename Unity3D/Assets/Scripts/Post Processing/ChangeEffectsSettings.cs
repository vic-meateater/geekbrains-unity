using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ChangeEffectsSettings : MonoBehaviour
{
    [SerializeField] private PostProcessProfile _secondProcessProfile;
    [SerializeField] private PostProcessVolume _processVolume;

    public void ChangeSettings()
    {
        _processVolume.profile = _secondProcessProfile;
    }
}
