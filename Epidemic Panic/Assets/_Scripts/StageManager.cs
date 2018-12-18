using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{

    public int whiteCellsKilled;
    public int organCellRemaining;

    public void Awake()
    {
        organCellRemaining = 3;
    
    }

    private void Update()
    {
        
    }

}
