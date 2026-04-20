using UnityEngine;

public class Intro : MonoBehaviour
{
    public DialogueManager dialogueManager;

    void Start()
    {
        string[] lines = {
            "시스템 오류 발생. 재부팅 시도",
            "..2XXX년 X월 X일.日日日日동, 날씨 ....  ",
            "지난 기록을 회상합니다.",
            "......日日日日日日日후 인간 개체를 찾을 수 없음. 결론: ",
            "인류 멸망. ", 
            "인간 개체가 존재하지 않음에도 불구하고 시스템이 가동됨.",
            "원인 분석 중... 日日日日 분석 실패 기억 소실. 원인을 찾기 위해 단서가 필요.",
            "결론: 주변 탐색 시작",
            "건물에서 떨어지면 안될것 같다. 조심해서 나아가자.", 
            "내 기억을,, 찾을 수 있길"
        };

        dialogueManager.StartDialogue(lines);
    }
}