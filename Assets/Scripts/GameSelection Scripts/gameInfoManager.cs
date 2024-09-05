using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class gameInfoManager : MonoBehaviour
{
    // Start is called before the first frame update
    private Dictionary<float, float> size = new Dictionary<float, float>();
    public Canvas canvas;
    public GameObject gameDetails;
    RectTransform canvasTransform;
    void Start()
    {
        canvasTransform = canvas.GetComponent<RectTransform>();
        //size[canvasTransform.rect.height] = canvasTransform.rect.width;
        //size[Screen.height] = Screen.width; = figure out what to do to convert height
        size[10] = 17;

        this.getGameDetails();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void getGameDetails()
    {
        //code that gets the game selected
        Transform[] imagesTransforms = gameDetails.GetComponentsInChildren<Transform>();
        int imageNum = imagesTransforms.Length;
        int index = 0;
        foreach (Transform image in imagesTransforms)
        {
            image.transform.position = new Vector3(0, (index * (size.GetValueOrDefault(10)/ imageNum)) - size.GetValueOrDefault(10) /2, 10);
            index++; 
        }
    }

}
