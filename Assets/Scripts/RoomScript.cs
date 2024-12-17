using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RoomScript : MonoBehaviour
{
    private static readonly int AnimationOpen = Animator.StringToHash("Open");
    private static readonly int AnimationClose = Animator.StringToHash("Close");
    
    [SerializeField] private RoomScript nextRoom;
    [SerializeField] private GameObject door;
    [SerializeField] private bool autoOpen;
    [SerializeField] private bool resetTimer;
    
    private bool completed;

    IEnumerator Start()
    {
        if (!autoOpen) yield break;
        yield return null;
        StopChallenge();
    }

    public void StartChallenge()
    {
        if (resetTimer) TimerScript.Instance.ResetTimer();
        if (autoOpen) return;
        TimerScript.Instance.StartTimer();
    }
    
    public void StopChallenge()
    {
        TimerScript.Instance.StopTimer();
        completed = true;
    }
    
    public void OpenDoor()
    {
        if (!completed) return;
        var animator = door.GetComponent<Animator>();
        animator.SetTrigger(AnimationOpen);
        if (nextRoom != null) nextRoom.StartChallenge();
    }
    
    public void CloseDoor()
    {
        var animator = door.GetComponent<Animator>();
        animator.SetTrigger(AnimationClose);
    }
}
