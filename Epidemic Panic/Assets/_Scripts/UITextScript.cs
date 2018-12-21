using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITextScript : MonoBehaviour
{

    public Text livesText;
    public Text organText;
    public Text winText;


    private PlayerController playerController;
    private StageManager stageManager;

    private void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        stageManager = GameObject.FindGameObjectWithTag("StageManager").GetComponent<StageManager>();
    }

    // Update is called once per frame
    void Update()
    {
        livesText.text = "Lives: " + playerController.lives.ToString();
        organText.text = "Organ Cells: " + stageManager.organCellRemaining.ToString() + " alive";
        
        if(stageManager.organCellRemaining <= 0)
        {
            WinText();
        }

    }

    void WinText()
    {
        winText.enabled = true;

    }
}
