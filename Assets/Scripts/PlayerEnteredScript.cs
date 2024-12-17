using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Teleportation;

public class PlayerEnteredScript : MonoBehaviour
{
    [SerializeField] private RoomScript roomScript;
    [SerializeField] private TeleportationArea teleportationArea;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        roomScript.StopChallenge();
        teleportationArea.enabled = true;
        Destroy(gameObject);
    }
}
