using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueUI;
    public TextMeshProUGUI dialogueText;

    private string[] dialogues;
    private int currentIndex;
    private bool isLastLine = false;

    public void StartDialogue(string[] lines)
    {
        dialogues = lines;
        currentIndex = 0;
        isLastLine = false;

        dialogueUI.SetActive(true);
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

    public void NextDialogue()
    {
        if (isLastLine) return; // 마지막 대사는 클릭 막기

        currentIndex++;
        ShowLine();
    }

    IEnumerator AutoClose()
    {
        yield return new WaitForSeconds(2f);

        dialogueUI.SetActive(false);
        isLastLine = false;
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