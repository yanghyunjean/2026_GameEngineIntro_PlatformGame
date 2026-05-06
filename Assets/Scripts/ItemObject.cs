using System;
using UnityEngine;

public class ItemObject : MonoBehaviour
{

    [SerializeField] ItemSO data;

    public int GetPoint()
    {
        return data.point;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
