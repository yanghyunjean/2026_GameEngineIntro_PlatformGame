
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Outro : MonoBehaviour
{
    public DialogueManager dialogueManager;

    private bool hasPlayed = false;

    float score;

    public void PlayOutro() 
    {
        if (hasPlayed) return;
        hasPlayed = true;

        string[] lines = {
           "(사진에는 매우 익숙하게 느껴지는 그림이 그려져 있었다.)",
".. 이건,,,",
        "이전 시스템이 강제종료 되기 전, 기억나는 보육원의 아이가 그려주었던 그림이다.",
        "나는,, 제품명0281402, 햇살 보육권에서 작동되었다.",
        "안드로이드인 나에게 따뜻하게 대해준 몇 안되는 인간 개체였다.",
        "그 아이는 그림을 나에게 선물로 주었고, 나는 이를 소중히 여겼다.",
        "인류가 멸망하면서 이 또한 부질없는 종이 쪼가리가 되어 버렸다.",
        "...... 어째서 내가 작동한건지 모르겠지만..",
        "아무것도 남지 않은 이 세상에 내가 보뷱원 모두의 마지막 기억이므로.",
        "결론: 인간을 기억한다.",
        "곧 애너지가 다해 나 또한 다시 꺼지겠지만,",
        "언젠가.. 다시 켜지는 날이 있다면.. ",
        "너희를 기억하겠다."
        };

        dialogueManager.onDialogueEnd = () =>
        {
            SceneManager.LoadScene("MainTitle");

            HighScore.TrySet(SceneManager.GetActiveScene().buildIndex, (int)score);
        };

        dialogueManager.StartDialogue(lines);
    }
}