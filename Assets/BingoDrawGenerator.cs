using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BingoDrawGenerator : MonoBehaviour
{
    public List<string> possibleVals;
    public Text currentVal;

    void Awake(){
        possibleVals = new List<string>{"Christmas", "Merry", "Festive", "Santa Claus", "Saint Nicholas", "Kris Kringle", "Elves", "Jolly", "Reindeer", "Carols", "Carolling", "Carolers", "Mistletoe", "Frankincense", "Myrrh", "Xmas", "Yuletide", "Tinsel", "Stocking", "Presents", "Fruitcake", "Chimney", "Birth", "Candy", "Pinecone", "Spirit", "Tidings", "Tradition", "Rudolph", "Sleigh", "Holiday", "Holly", "Ornaments", "Scrooge", "Sledge", "Snowball", "St. Nicks", "Snowman", "Father", "Christmas", "Christmas Eve", "Christmas tree", "Jack Frost", "Santa’s helpers", "Santa’s workshop", "Christmas carol", "Christmas card", "Frosty the Snowman", "December 25", "Sleigh bells", "Gingerbread house", "North Pole", "Plum pudding", "Season’s greetings", "Celebrate", "Christmas tree stand", "Chestnuts", "Angel", "Elf", "Feast", "Goose"};
    }

    // Start is called before the first frame update
    void Start()
    {
        currentVal.text = "First call will happen in a moment...";
        StartCoroutine(NewCall());
    }

    // Update is called once per frame
    void Update()
    {
       

    }

    IEnumerator NewCall()
    {
        yield return new WaitForSeconds(5f);
        // where the logic is called for each word
        // Create a list of sample items
        while (possibleVals.Count > 0)
        {
            // use randomise object to identify a random index
            int randomIndex = Random.Range(0, possibleVals.Count - 1);
            // once word is called, it must be removed from the list
            if (currentVal != null)
            {
                currentVal.text = possibleVals[randomIndex];
                // then remove that value extracted from the list
                possibleVals.RemoveAt(randomIndex);
            }
            yield return new WaitForSeconds(5f);
        }
        // no more values, display this to the screen
        currentVal.text = "No More Words!"; 
    }
}
