using UnityEngine;

public class NumbersScript : MonoBehaviour
{
    [SerializeField] private RoomScript room;
    [SerializeField] private Material realGreenMaterial;
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private bool first;
    [SerializeField] private bool final;
    [SerializeField] private NumbersScript next;
    
    private bool active;
    private bool pressed;

    private void Awake()
    {
        active = first;
    }
    
    public void OnThisPressed()
    {
        if (pressed) return;
        if (!active) return;
        meshRenderer.material = realGreenMaterial;
        pressed = true;
        if (final)
        {
            room.StopChallenge();
        }
        else
        {
            next.active = true;
        }
    }
}
