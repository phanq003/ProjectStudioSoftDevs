using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

public class LeaderBoardManagerScript : MonoBehaviour
{
    const int numOfPlayers = 10;

    public InputField playerInput;
    public Text currentScoreText;

    public GameObject HighScoreMenu;
    public GameObject LeaderboardPrefab;
    public Transform parent;

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
            int count = HighScorePlayerList.Count();
            Debug.Log("count" + count);
            if (count != 0)
            {
                tenPlayerList = new List<HighScorePlayer>();
                HighScorePlayerList = HighScorePlayerList.Distinct().OrderByDescending(sc => sc.score).ToList();
                foreach (HighScorePlayer thePlayers in HighScorePlayerList)
                {
                    if (count > numOfPlayers)
                    {
                        bool hasAppend = false;
                        while (tenPlayerList.Count() < 10 && hasAppend == false)
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
    private List<GameObject> playerScores = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        string path = Application.dataPath + "/scoreRecall.text";
        try
        {
            string[] lines = File.ReadAllLines(path);

            foreach (string line in lines)
            {
                string[] content = line.Split();
                HighScorePlayer newPlayer = new HighScorePlayer(content[0], int.Parse(content[1]));
                playerList.HighScorePlayerList.Add(newPlayer);
            }
            //playerList = JsonUtility.FromJson<HighScoreList>(Application.dataPath + "/scoreRecall.text");
        }
        catch
        {
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
        string path = Application.dataPath + "/scoreRecall.text";
        StreamWriter writer = new StreamWriter(path, false);
        foreach (HighScorePlayer player in playerList.getPlayerList())
        {
            string filedata = player.playerName + " " + player.score.ToString();
            writer.WriteLine(filedata);
        }
        writer.Close();
    }
    public void saveScore()
    {
        HighScorePlayer newPlayer = new HighScorePlayer(playerInput.text, int.Parse(currentScoreText.text));
        playerList.HighScorePlayerList.Add(newPlayer);
        playerList.limitPlayersToTen();
        this.writeToList();
    }
    public void displayList()
    {
        playerList.limitPlayersToTen();
        if (playerList.getPlayerList().Count() != 0)
        {
            refreshLeaderBoard();
            float offset = 2.9f;
            Debug.Log("1it has been printed");
            int cycle = 1;
            foreach (HighScorePlayer thePlayers in playerList.getPlayerList())
            {
                Debug.Log("it has been printed");
                string theName = thePlayers.playerName;
                string theScore = thePlayers.score.ToString();
                GameObject tempLeaderboard = Instantiate(LeaderboardPrefab, new Vector3(parent.transform.position.x, parent.transform.position.y + offset, parent.transform.position.z), Quaternion.identity, parent);
                playerScores.Add(tempLeaderboard);
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

    public void refreshLeaderBoard()
    {
        if (playerScores.Count() > 0)
        {
            foreach (GameObject playerScore in playerScores)
            {
                Destroy(playerScore);
            }
        }
    }

    public void hideMenu()
    {
        if (HighScoreMenu.activeSelf)
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
