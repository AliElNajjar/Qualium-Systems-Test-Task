using UnityEngine;
using UnityEngine.SceneManagement;



public class GameManager : Singleton<GameManager>
{
    public enum GameState
    {
        RUNNING,
        PAUSED
    }

    public Events.EventGameState OnGameStateChanged;

    GameState _currentGameState = GameState.RUNNING;

    public GameState CurrentGameState
    {
        get { return _currentGameState; }
        private set { _currentGameState = value; }
    }
    
    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        StartGame();
    }

    private void Update()
    {
        
    }

    private void LoadLevel(string levelName)
    {
        SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
    }

    private void unLoadLevel(string levelName)
    {
        SceneManager.UnloadSceneAsync(levelName);
    }

    void UpdateState(GameState state)
    {
        GameState previousGameState = _currentGameState;
        _currentGameState = state;

        switch (_currentGameState)
        {
            case GameState.RUNNING:
                Time.timeScale = 1.0f;
                break;
            case GameState.PAUSED:
                Time.timeScale = 0f;
                break;
            default:
                break;
        }

        OnGameStateChanged.Invoke(_currentGameState, previousGameState);
    }

    public void StartGame()
    {
        LoadLevel("Main");
    }

    public void TogglePause()
    {
        UpdateState(_currentGameState == GameState.RUNNING ? GameState.PAUSED : GameState.RUNNING);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
}