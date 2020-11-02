using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] GameObject _pauseMenu;
    [SerializeField] private Button PauseResumeButton;
    [SerializeField] private Button QuitButton;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        GameManager.Instance.OnGameStateChanged.AddListener(HandleGameStateChanged);
        PauseResumeButton.onClick.AddListener(HandlePauseResumeClicked);
        QuitButton.onClick.AddListener(HandleQuitClicked);
    }

    void HandleGameStateChanged(GameManager.GameState currentState, GameManager.GameState previousState)
    {
        _pauseMenu.SetActive(currentState == GameManager.GameState.PAUSED);
    }

    void HandlePauseResumeClicked()
    {
        GameManager.Instance.TogglePause();
    }

    void HandleQuitClicked()
    {
        GameManager.Instance.QuitGame();
    }
}
