using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.UI;

public class MainMenuCanvasScript : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject settingsPanel;
    
    [SerializeField] private Text locomotionText;

    private void Awake()
    {
        locomotionText.text = (PlayerSettingsScript.locomotionSpeed * 0.1f).ToString("0.0");
    }
    public void OnPlayButtonClicked()
    {
        FadeCanvasScript.Instance.ChangeSceneWithFade("GameScene");
        GetComponent<TrackedDeviceGraphicRaycaster>().enabled = false;
    }

    public void OnSettingsButtonClicked()
    {
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void OnQuitButtonClicked()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void OnLeftControllerSmoothMotionButtonClicked()
    {
        PlayerSettingsScript.leftControllerSmoothMotion = true;
        PlayerSettingsScript.Instance.UpdateSettings();
    }
    
    public void OnLeftControllerTeleportationButtonClicked()
    {
        PlayerSettingsScript.leftControllerSmoothMotion = false;
        PlayerSettingsScript.Instance.UpdateSettings();
    }
    
    public void OnRightControllerSmoothMotionButtonClicked()
    {
        PlayerSettingsScript.rightControllerSmoothMotion = true;
        PlayerSettingsScript.Instance.UpdateSettings();
    }
    
    public void OnRightControllerTeleportationButtonClicked()
    {
        PlayerSettingsScript.rightControllerSmoothMotion = false;
        PlayerSettingsScript.Instance.UpdateSettings();
    }
    
    public void OnLessLocoSpeedButtonClicked()
    {
        PlayerSettingsScript.locomotionSpeed = Mathf.Max(PlayerSettingsScript.locomotionSpeed - 1, 1);
        locomotionText.text = (PlayerSettingsScript.locomotionSpeed * 0.1f).ToString("0.0");
        PlayerSettingsScript.Instance.UpdateSettings();
    }
    
    public void OnMoreLocoSpeedButtonClicked()
    {
        PlayerSettingsScript.locomotionSpeed = Mathf.Min(PlayerSettingsScript.locomotionSpeed + 1, 40);
        locomotionText.text = (PlayerSettingsScript.locomotionSpeed * 0.1f).ToString("0.0");
        PlayerSettingsScript.Instance.UpdateSettings();
    }

    public void OnBackToMenuButtonClicked()
    {
        settingsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
}
