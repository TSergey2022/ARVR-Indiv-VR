using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuCanvasScript : MonoBehaviour
{
    [SerializeField] private GameObject menuPanelGo;
    [SerializeField] private GameObject optionsPanelGo;
    [SerializeField] private Text locomotionText;

    private void Awake()
    {
        OnDisable();
        locomotionText.text = (PlayerSettingsScript.locomotionSpeed * 0.1f).ToString("0.0");
    }

    private void OnEnable()
    {
        Time.timeScale = 0.0f;
    }

    private void OnDisable()
    {
        optionsPanelGo.SetActive(false);
        menuPanelGo.SetActive(true);
        Time.timeScale = 1.0f;
    }

    public void OnResumeButtonClicked()
    {
        gameObject.SetActive(false);
    }
    
    public void OnSettingsButtonClicked()
    {
        menuPanelGo.SetActive(false);
        optionsPanelGo.SetActive(true);
    }
    
    public void OnQuitToMenuButtonClicked()
    {
        if (SceneManager.GetActiveScene().name != "MainMenuScene")
        {
            FadeCanvasScript.Instance.ChangeSceneWithFade("MainMenuScene");
        }
    }
    
    public void OnQuitGameButtonClicked()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void OnCloseSettingsButtonClicked()
    {
        optionsPanelGo.SetActive(false);
        menuPanelGo.SetActive(true);
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
}
