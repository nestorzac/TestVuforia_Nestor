using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using System.Linq;
 
public class DanceController : MonoBehaviour
{
    [SerializeField]
    private Animator _characterAnimator;
    [SerializeField]
    private NotesManager _notesManager;
    [SerializeField]
    private UnityEvent _onSelecteDance;
 
    [SerializeField]
    private UnityEvent _onDanceSelected;
    [SerializeField]
    private string _failAnimationName = "fail";
    private Coroutine _resetDanceCoroutine;
    private SoundData _currentSoundData;
 
    public void ActivateSelectDance()
    {
        _onSelecteDance?.Invoke();
    }
 
    public void OnSelectedDance(SoundData soundData)
    {
        _currentSoundData = soundData;
        _onDanceSelected?.Invoke();
    }
 
    public void StartDance()
    {
        _characterAnimator.Play(_currentSoundData.animationName);
        SoundManager.instance.PlayMusic(_currentSoundData.musicName);
        _notesManager.StartNoteChart(_currentSoundData.notesConfig, _currentSoundData.speed);
    }
 
    public void FailedNote()
    {
        if (_resetDanceCoroutine != null)
        {
            StopCoroutine(_resetDanceCoroutine);
        }
        _resetDanceCoroutine = StartCoroutine(ResetDance());
    }
 
    public IEnumerator ResetDance()
    {
        _characterAnimator.Play(_failAnimationName, 0, 0f);
        float failAnimationLenght = _characterAnimator.runtimeAnimatorController.
        animationClips.First(clip => clip.name == _failAnimationName).length;
        yield return new WaitForSeconds(failAnimationLenght);
        _characterAnimator.Play(_currentSoundData.animationName);
        _resetDanceCoroutine = null;
    }
}
 
 