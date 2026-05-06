using UnityEngine;

[CreateAssetMenu(fileName = "Game/Item", menuName = "Game/Create Item")]
public class ItemSO : ScriptableObject
{
    [Header("Score Value")]
        public int point = 10;
}
