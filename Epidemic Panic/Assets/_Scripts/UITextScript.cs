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
    private StatManager statManager;

    private void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        statManager = GameObject.FindGameObjectWithTag("StageManager").GetComponent<StatManager>();
    }

    // Update is called once per frame
    void Update()
    {
        livesText.text = "Lives: " + playerController.lives.ToString();
        organText.text = statManager.organCellRemaining.ToString() + "/" + statManager.organCellTotal.ToString();
        
        if(statManager.organCellRemaining <= 0)
        {
            WinText();
        }

    }

    void WinText()
    {
        winText.enabled = true;

    }
}
