using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject playerPrefab, whiteCellPrefab;
    public Transform playerSpawn;
    public Transform[] whiteSpawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(playerPrefab, playerSpawn.position, playerSpawn.rotation  );
        WhiteSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WhiteSpawnInvoke()
    {
        Invoke("WhiteSpawn", 2);
    }

    void WhiteSpawn()
    {
        int whiteSpawnPointIndex = Random.Range(0, whiteSpawnPoints.Length);
        Collider2D[] whiteSpawnCheck = Physics2D.OverlapCircleAll(whiteSpawnPoints[whiteSpawnPointIndex].position, 3);
        bool playerInSpawn = false;

        foreach (Collider2D x in whiteSpawnCheck)
        {
            if (x.gameObject.tag == "Player")
            {
                playerInSpawn = true;
                Debug.Log("playerinspawn");
            }
        }

        if(playerInSpawn == false)
        {
            Instantiate(whiteCellPrefab, whiteSpawnPoints[whiteSpawnPointIndex].position, whiteSpawnPoints[whiteSpawnPointIndex].rotation);
        }
        else
        {
            WhiteSpawn();
        }

    }
}
