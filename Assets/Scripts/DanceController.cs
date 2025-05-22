using UnityEngine;
using UnityEngine.Events;

public class DanceController : MonoBehaviour
{
    [SerializeField]
    private Animator _characterAnimaor;
    [SerializeField]
    private UnityEvent _onSelectDance;
    [SerializeField]
    private UnityEvent _onDanceSelected;
    private SoundData _currentSoudData;
    public void ActivateSelectDance()
    {
        _onSelectDance?.Invoke();
    }
    public void OnSelecteDance(SoundData soundData)
    {
        _currentSoudData = soundData;
        _onDanceSelected?.Invoke();
    }
    public void StartDance()
    {
        _characterAnimaor.Play(_currentSoudData.animationName);
        SoundManager.instance.PlayMusic(_currentSoudData.musicName);
    }
    
}
