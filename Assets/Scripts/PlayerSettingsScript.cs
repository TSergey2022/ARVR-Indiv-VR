using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class PlayerSettingsScript : MonoBehaviour
{
    public static bool leftControllerSmoothMotion = true;
    public static bool rightControllerSmoothMotion = false;
    public static int locomotionSpeed = 10;
    
    public static PlayerSettingsScript Instance { get; private set; }
    
    [SerializeField] private ControllerInputActionManager leftController;
    [SerializeField] private ControllerInputActionManager rightController;
    [SerializeField] private DynamicMoveProvider locomotionProvider;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        UpdateSettings();
    }

    public void UpdateSettings()
    {
        leftController.smoothMotionEnabled = leftControllerSmoothMotion;
        rightController.smoothMotionEnabled = rightControllerSmoothMotion;
        locomotionProvider.moveSpeed = 0.1f * locomotionSpeed;
    }
}
