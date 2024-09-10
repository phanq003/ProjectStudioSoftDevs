using System.Collections;
using System.Collections.Generic;
using System.IO;
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
        public List<HighScorePlayer> HighScorePlayerList = new List<HighScorePlayer>();
        private List<HighScorePlayer> tenPlayerList = new List<HighScorePlayer>();

        public void limitPlayersToTen()
        {
            try
            {
                Debug.Log(HighScorePlayerList.Count());
            }
            catch
            {

            }
            int count = HighScorePlayerList.Count();
            Debug.Log("count" + count);
            if (count != 0)
            {
                tenPlayerList = new List<HighScorePlayer>();
                HighScorePlayerList.OrderByDescending(sc => sc.score).ToList();
                foreach (HighScorePlayer thePlayers in HighScorePlayerList)
                {
                    if (count > numOfPlayers)
                    {
                        bool hasAppend = false;
                        while (tenPlayerList.Count() < 10 || hasAppend == false)
                        {
                            tenPlayerList.Add(thePlayers);
                            hasAppend = true;
                        }
                    }
                    else
                    {
                        tenPlayerList.Add(thePlayers);
                    }
                }
            }
            
          
            
        }
        public List<HighScorePlayer> getPlayerList()
        {
            return tenPlayerList; 
        }
    }
    public HighScoreList playerList = new HighScoreList();
   
    // Start is called before the first frame update
    void Start()
    {
        try
        {
            playerList = JsonUtility.FromJson<HighScoreList>(Application.dataPath + "/scoreWack.text");
        }
        catch {
            writeToList();
        }
        
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void writeToList()
    {
        print("WriteTOList" + playerList.getPlayerList().ToString());
        print(playerList.getPlayerList().Count() + "HJDASKHSDADJLSJKDKSADJDLKSLKDJSALKDJAYOOOOO");
        string jsonFileString = JsonUtility.ToJson(playerList.getPlayerList());
        File.WriteAllText(Application.dataPath + "/scoreWack.text", jsonFileString);
    }
    public void saveScore()
    {
        print("saved" + playerInput.text + currentScoreText.text);
        HighScorePlayer newPlayer = new HighScorePlayer(playerInput.text, int.Parse(currentScoreText.text));
        playerList.HighScorePlayerList.Add(newPlayer);
        print(playerList.HighScorePlayerList.Count() + "SAKJDKDJLSAKDKJLSJALKD");
        playerList.limitPlayersToTen();
        this.writeToList();
    }
    public void displayList()
    {
        if (playerList.getPlayerList().Count() != 0)
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
