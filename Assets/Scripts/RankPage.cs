using UnityEngine;
using System.Linq;
using TMPro;
using System;
using UnityEngine.SocialPlatforms.Impl;
using TMPro.EditorUtilities;

public class RankPage : MonoBehaviour
{
    [SerializeField] Transform contentRoot;
    [SerializeField] GameObject rowPrefab;

    StageResultList allData;
    void Awake()
    {
        allData = StageResultSaver.LoadRank();
        RefreshRankList();
    }
    void RefreshRankList()
    {
        foreach (Transform child in contentRoot)
        {
            Destroy(child.gameObject);

        }
        var sortedData = allData.results.OrderByDescending(x => x.score).ToList();

        for (int i = 0; i < sortedData.Count; i++)
        {
            GameObject row = Instantiate(rowPrefab, contentRoot);

            TMP_Text rankText = row.transform.Find("Text (TMP)").GetComponentInChildren<TMP_Text>();
            rankText.text = $"{i + 1}. {sortedData[i].playerName} - {sortedData[i].score}";
        }
    }
}
