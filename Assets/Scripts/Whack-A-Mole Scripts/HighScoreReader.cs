using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;


public class HighScoreReader : MonoBehaviour
{
    const int numOfPlayers = 10;

    public InputField playerInput;
    public Text currentScoreText;

    public GameObject HighScoreMenu;
    public GameObject LeaderboardPrefab;
    
    [System.Serializable]
    public class HighScorePlayer
    {
        public string playerName { get; private set; }
        public int score { get; private set; }
        public HighScorePlayer(string playerName, int playerScore)
        {
            this.playerName = playerName;
            this.score = playerScore;
        }
       
    }
    [System.Serializable]
    public class HighScoreList
    {
        public HighScorePlayer[] HighScorePlayerList;
        private HighScorePlayer[] tenPlayerList;

        public void limitPlayersToTen()
        {
            int count = HighScorePlayerList.Count();
            if (count != 0)
            {
                HighScorePlayerList.OrderByDescending(sc => sc.score).ToList();
            }
            if (count > numOfPlayers)
            {
                foreach (HighScorePlayer thePlayers in HighScorePlayerList)
                {
                    bool hasAppend = false;
                    while (tenPlayerList.Count() < 10 || hasAppend == false)
                    {
                        tenPlayerList.Append(thePlayers);
                        hasAppend = true;
                    }
                }
            }
            
        }
        public HighScorePlayer[] getPlayerList()
        {
            return tenPlayerList; 
        }
    }
    public HighScoreList playerList = new HighScoreList();
   
    // Start is called before the first frame update
    void Start()
    {
        playerList = JsonUtility.FromJson<HighScoreList>("");
        
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void saveScore()
    {
        string playerName = playerInput.text;
        HighScorePlayer newPlayer = new HighScorePlayer(playerInput.text, int.Parse(currentScoreText.text));
        playerList.limitPlayersToTen();
    }
    public void displayList()
    {
        if (playerList != null)
        {
            float offset = 0f;
            int cycle = 1;
            foreach (HighScorePlayer thePlayers in playerList.getPlayerList())
            {
                string theName = thePlayers.playerName;
                string theScore = thePlayers.score.ToString();
                GameObject tempLeaderboard = Instantiate(LeaderboardPrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + offset, gameObject.transform.position.z), Quaternion.identity);
                offset -= 0.66f;
                Text[] text = tempLeaderboard.GetComponentsInChildren<Text>();
                text[0].text = "#" + cycle;
                text[1].text = theName;
                text[2].text = theScore;
                cycle++;
            }
        }
        else
        {

        }
    }

    public void hideMenu()
    {
        if(HighScoreMenu.activeSelf)
        {
            HighScoreMenu.SetActive(false);
        }
        else
        {
            this.displayList();
            HighScoreMenu.SetActive(true);
        }
    }
}
