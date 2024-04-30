using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public TMP_InputField inputPlayername;
    public PlayerRecord playerRecord;
    public Button buttonStart;
    public Button buttonAddPlayer;

    public void ButtonAddPlayer()
    {
        if (playerRecord != null && inputPlayername != null) {
            playerRecord.AddPlayer(inputPlayername.text);
            buttonStart.interactable = true;
            inputPlayername.text = "";
            if (playerRecord.playerList.Count == playerRecord.playerColors.Length) 
            {
                buttonAddPlayer.interactable = false;
            }
        }
        else 
        {
            Debug.LogError("Null value detecred");
        }

    }

    public void ButtonStart() 
    {
        string sceneName = "Level 1";
        playerRecord.level[0] = sceneName;
        SceneManager.LoadScene(sceneName);
    }
}
