using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueUI;
    public TextMeshProUGUI dialogueText;
    public GameObject characterImage;

    public System.Action onDialogueEnd;

    private string[] dialogues;
    private int currentIndex;
    private bool isLastLine = false;
    private bool isPlaying = false;

    public void StartDialogue(string[] lines)
    {
       

        if (isPlaying) return;
        isPlaying = true;

        dialogues = lines;
        currentIndex = 0;
        isLastLine = false;

        dialogueUI.SetActive(true);
        if (characterImage != null)
            characterImage.SetActive(true);


        ShowLine();
    }

    void ShowLine()
    {
        dialogueText.text = dialogues[currentIndex];

        // 마지막 대사 체크
        if (currentIndex == dialogues.Length - 1)
        {
            isLastLine = true;
            StartCoroutine(AutoClose());
        }
    }

    void Awake() //처음 UI꺼져있게
    {

        dialogueUI.SetActive(false);
        

        if (characterImage != null)
            characterImage.SetActive(false);


    }

    public void NextDialogue()
    {
        if (isLastLine) return; // 마지막 대사는 클릭 막기

        currentIndex++;
        ShowLine();
    }

    //IEnumerator는 Unity에서 코루틴을 구현하기 위해 사용됨. 코루틴은 특정 시간 동안 대기하거나, 여러 프레임에 걸쳐 실행되는 작업을 처리함
    IEnumerator AutoClose()  // 마지막 대사 후 2초 후에 자동으로 UI 닫기
    {
        yield return new WaitForSeconds(2f); //yield return은 코루틴에서 일정 시간 대기 후 다음 코드를 실행하게 하는 기능.  2초 동안 대기

        dialogueUI.SetActive(false);
        isLastLine = false;

        if (characterImage != null)
            characterImage.SetActive(false);

        isPlaying = false;
        onDialogueEnd?.Invoke();
    }

    void Update()
    {
        if (dialogueUI == null) return;
        if (!dialogueUI.activeSelf) return;

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            NextDialogue();
        }
    }
}