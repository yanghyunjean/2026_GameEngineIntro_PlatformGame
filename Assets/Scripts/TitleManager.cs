using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public GameObject helpPanel;
    public void GameStart()
    {
        SceneManager.LoadScene("PlayScene");
    }
    public void OpenHelp()
    {
        helpPanel.SetActive(true);

    }

    void Start() //처음에 꺼져있게
    {
        helpPanel.SetActive(false);


        if (helpPanel != null)
            helpPanel.SetActive(false);
    }

    public void CloseHelp()
    {
        helpPanel.SetActive(false);
    }

    public void ButtonLog()
    {
        Debug.Log("BUTTON CLICKED!");
    }

    public void QuitGame()
    {
        Debug.Log("게임 종료");
        Application.Quit();
    }

    public void LoadTitle()
    {
        SceneManager.LoadScene("MainTitle");
    }
}
