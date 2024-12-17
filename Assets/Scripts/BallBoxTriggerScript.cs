using System;
using UnityEngine;
using UnityEngine.UI;

public class BallBoxTriggerScript : MonoBehaviour
{
    public int ballsLeft;
    public RoomScript roomScript;
    [SerializeField] private Text text;

    private void Awake()
    {
        text.text = $"{ballsLeft}";
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Ball")) return;
        Destroy(other.gameObject);
        ballsLeft--;
        text.text = $"{ballsLeft}";
        if (ballsLeft > 0) return;
        if (roomScript == null) return;
        roomScript.StopChallenge();
        Destroy(transform.parent.parent.gameObject);
    }
}
