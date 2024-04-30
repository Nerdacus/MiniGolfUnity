using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{ 
    public BallController ball;
    public TextMeshProUGUI labelPlayerName; 

    private PlayerRecord playerRecord;
    private int playerIndex;
    void Start()
{
    GameObject playerRecordObject = GameObject.Find("Player Record");
    if (playerRecordObject != null)
    {
        playerRecord = playerRecordObject.GetComponent<PlayerRecord>();
        if (playerRecord != null)
        {
            playerIndex = 0;
            SetUpPlayer();
        }
        else
        {
            Debug.LogError("PlayerRecord component not found on 'Player Record' GameObject.");
        }
    }
    else
    {
        Debug.LogError("GameObject 'Player Record' not found.");
    }
}


    private void SetUpPlayer() 
    {
        ball.SetupBall(playerRecord.playerColors[playerIndex]);
        labelPlayerName.text = playerRecord.playerList[playerIndex].name;
    }

    public void NextPlayer(int previousPutts) 
    {
        playerRecord.AddPutts(playerIndex, previousPutts);
        if (playerIndex < playerRecord.playerList.Count-1)
        {
            playerIndex++;
            SetUpPlayer();
        }
        else 
        {
            if(playerRecord.levelIndex == playerRecord.level.Length-1) 
            {
                //load scoreboard scene
                SceneManager.LoadScene("Scoreboard");
            }
            else 
            {
                playerRecord.levelIndex++;
                SceneManager.LoadScene(playerRecord.level[playerRecord.levelIndex]);
            }
        }
    }
}
