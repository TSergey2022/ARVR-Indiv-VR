using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class IngameMenuScript : MonoBehaviour
{
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private InputActionReference openMenuRef;
    [SerializeField] private GameObject menuCanvasPrefab;
    private GameObject menuCanvasGo;

    private void Awake()
    {
        openMenuRef.action.performed += ToggleIngameMenu;
    }

    private void OnDestroy()
    {
        openMenuRef.action.performed -= ToggleIngameMenu;
    }

    private void ToggleIngameMenu(InputAction.CallbackContext callbackContext)
    {
        if (SceneManager.GetActiveScene().name == "MainMenuScene") return;
        if (menuCanvasGo == null)
        {
            menuCanvasGo = Instantiate(menuCanvasPrefab);
            menuCanvasGo.SetActive(false);
        }

        if (!menuCanvasGo.activeSelf)
        {
            var forward = playerCameraTransform.forward; forward.y = 0; forward.Normalize();
            var pos = playerCameraTransform.position + forward * 2.0f;
            menuCanvasGo.transform.position = pos;
            menuCanvasGo.transform.eulerAngles = new Vector3(0, playerCameraTransform.eulerAngles.y, 0);
        }
        menuCanvasGo.SetActive(!menuCanvasGo.activeSelf);
        Time.timeScale = menuCanvasGo.activeSelf ? 0.0f : 1.0f;
    }
}
