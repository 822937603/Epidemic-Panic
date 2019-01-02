using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{

    public int whiteCellsKilled = 0;
    public int organCellRemaining;
    public int organCellTotal;

    public void Awake()
    {
        organCellRemaining = 3;
        organCellTotal = 3;
    
    }

    private void Update()
    {
        if(organCellRemaining <= 0)
        {
            Time.timeScale = 0f;
        }
    }

}
