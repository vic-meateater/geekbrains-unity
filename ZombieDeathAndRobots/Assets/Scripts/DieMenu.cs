using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DieMenu : MonoBehaviour
{
    //VARIABLES
    [SerializeField] private Button _btnRestart;
    [SerializeField] private Button _btnMainMenu;
    [SerializeField] private Button _btnExit;

    public void Awake()
    {
        _btnRestart.onClick.AddListener(Restart);
        _btnMainMenu.onClick.AddListener(ToMainMenu);
        _btnExit.onClick.AddListener(Exit);

    }

    private void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level_1");
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
