using UnityEngine;
using TMPro;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueUI;
    public TextMeshProUGUI dialogueText;

    public void ShowDialogue(string text, float time)
    {
        StopAllCoroutines();
        StartCoroutine(ShowRoutine(text, time));
    }

    IEnumerator ShowRoutine(string text, float time)
    {
        dialogueUI.SetActive(true);
        dialogueText.text = text;

        yield return new WaitForSeconds(time);

        dialogueUI.SetActive(false);
    }
}