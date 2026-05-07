using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public GameObject helpPanel;
    public GameObject LeaderBoard;
    public GameObject Ranking;
    public void GameStart()
    {
        SceneManager.LoadScene("PlayScene");
    }
    public void OpenHelp()
    {
        helpPanel.SetActive(true);

    }

    public void OpenLeaderBoard()
    {
        LeaderBoard.SetActive(true);

    }

    public void OpenRanking()
    {
        Ranking.SetActive(true);

    }

    void Start() //처음에 꺼져있게
    {
        helpPanel.SetActive(false);


        if (helpPanel != null)
            helpPanel.SetActive(false);

        LeaderBoard.SetActive(false);


        if (LeaderBoard != null)
            LeaderBoard.SetActive(false);

        Ranking.SetActive(false);

        if (Ranking != null)
            Ranking.SetActive(false);
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

    public void closeLeaderBoard()
    {
        LeaderBoard.SetActive(false);
    }

    public void closeRanking()
    {
        Ranking.SetActive(false);
    }



    public void LoadTitle()
    {
        SceneManager.LoadScene("MainTitle");
    }
}
