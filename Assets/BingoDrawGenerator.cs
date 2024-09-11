using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BingoDrawGenerator : MonoBehaviour
{
    public List<string> possibleVals; 

    void Awake(){
        possibleVals = new List<string>{"Christmas", "Merry", "Festive", "Santa Claus", "Saint Nicholas", "Kris Kringle", "Elves", "Jolly", "Reindeer", "Carols", "Carolling", "Carolers", "Mistletoe", "Frankincense", "Myrrh", "Xmas", "Yuletide", "Tinsel", "Stocking", "Presents", "Fruitcake", "Chimney", "Birth", "Candy", "Pinecone", "Spirit", "Tidings", "Tradition", "Rudolph", "Sleigh", "Holiday", "Holly", "Ornaments", "Scrooge", "Sledge", "Snowball", "St. Nicks", "Snowman", "Father", "Christmas", "Christmas Eve", "Christmas tree", "Jack Frost", "Santa’s helpers", "Santa’s workshop", "Christmas carol", "Christmas card", "Frosty the Snowman", "December 25", "Sleigh bells", "Gingerbread house", "North Pole", "Plum pudding", "Season’s greetings", "Celebrate", "Christmas tree stand", "Chestnuts", "Angel", "Elf", "Feast", "Goose"};
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
