using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PausedMenu : MonoBehaviour
{
    //VARIABLES
    [SerializeField] private Button _btnResume;
    [SerializeField] private Button _btnMainMenu;
    [SerializeField] private Button _btnExit;
    [SerializeField] private GameObject _pauseMenu;


    public static bool _gameIsPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Awake()
    {
        _btnResume.onClick.AddListener(Resume);
        _btnMainMenu.onClick.AddListener(ToMainMenu);
        _btnExit.onClick.AddListener(Exit);

    }

    private void Resume()
    {
        _pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        _gameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Pause()
    {
        Cursor.lockState = CursorLockMode.Confined;
        _pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        _gameIsPaused = true;
    }

    public void ToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
