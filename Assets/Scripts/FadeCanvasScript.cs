using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeCanvasScript : MonoBehaviour
{
    public static FadeCanvasScript Instance { get; private set; }
    
    [SerializeField] private Animator animator;
    [SerializeField] private Canvas canvas;
    private AsyncOperation sceneAO;
    
    private void Awake()
    {
        Instance = this;
        animator.SetTrigger("FadeOut");
    }

    // Функция для начала перехода сцены с затуханием
    public void ChangeSceneWithFade(string sceneName)
    {
        // Активируем анимацию FadeIn
        animator.SetTrigger("FadeIn");

        // Начинаем асинхронно загружать новую сцену
        sceneAO = SceneManager.LoadSceneAsync(sceneName);

        // Отключаем автоматический переход к новой сцене
        sceneAO.allowSceneActivation = false;
    }
    
    // Функция, которая вызывается в конце анимации FadeIn
    private void ChangeScene()
    {
        // Разрешаем переход к новой сцене
        sceneAO.allowSceneActivation = true;
        
        sceneAO = null;
    }

    // Вызывается автоматически Unity после завершения анимации FadeIn
    public void OnFadeInComplete()
    {
        ChangeScene();
    }
}
