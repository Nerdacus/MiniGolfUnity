using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Security.Cryptography;

public class PlayerRecord : MonoBehaviour
{
    public List<Player> playerList;
    public string[] level;
    public Color[] playerColors;
    [HideInInspector] public int levelIndex;

    void OnEnable()
    {
        playerList = new List<Player>();
       // playerColors = new Color[3];
       // level = new string[1];
        DontDestroyOnLoad(gameObject);
    }

    public void AddPlayer(String name) 
    {
        playerList.Add(new Player(name, playerColors[playerList.Count], level.Length));
    }

    public void AddPutts(int playerIndex, int puttCount)
    {
        playerList[playerIndex].putts[levelIndex] = puttCount;
    }

    public List<Player>GetScoreboardList()
    {
        foreach (var player in playerList)
        {
            foreach (var puttScore in player.putts)
            {
                player.totalPutts += puttScore;
            }
        }
        return (from p in playerList orderby p.totalPutts select p).ToList();
    }

    public class Player 
    {
        public string name;
        public Color color;
        public int[] putts;
        public int totalPutts;

        public Player (string newName, Color newColor, int levelCount) 
        {
            name = newName;
            color = newColor;
            putts = new int[levelCount];
        }
    }
}
