using TMPro;
using UnityEngine;

public class LeaderBoad : MonoBehaviour
{

    public TextMeshProUGUI PlayScene;
    public TextMeshProUGUI PlayScene2;
    public TextMeshProUGUI PlayScene3;
    public TextMeshProUGUI PlayScene4;
    public TextMeshProUGUI PlayScene5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayScene.text = "PlayScene : " + HighScore.Load(1).ToString();
        PlayScene2.text = "PlayScene2 : " + HighScore.Load(2).ToString();
        PlayScene3.text = "PlayScene3 : " + HighScore.Load(3).ToString();
        PlayScene4.text = "PlayScene4 : " + HighScore.Load(4).ToString();
        PlayScene5.text = "PlayScene5 : " + HighScore.Load(5).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
