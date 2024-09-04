using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UI;

public class GameDescriptionManager : MonoBehaviour
{
    private Camera mainCamera;
    public GameObject gameDetails;
    public Text TextTitle;
    public Text TextDescription;
    public Button playButton;

    private int height = Screen.height;
    private int width = Screen.width;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;   
        setUpImage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void setUpImage()
    {
        Transform imageTransforms = gameDetails.GetComponentInChildren<Transform>();
        float heightVal = height - (height / 5);
        Vector3 imagePoint = mainCamera.ScreenToWorldPoint(new Vector3(width / 2, heightVal + 100, mainCamera.nearClipPlane));
        imageTransforms.transform.position = imagePoint;
        TextTitle.rectTransform.position = mainCamera.ScreenToWorldPoint(new Vector3(width/2, height/2 + 200, mainCamera.nearClipPlane));
        TextDescription.rectTransform.position = mainCamera.ScreenToWorldPoint(new Vector3(width/2, height/2, mainCamera.nearClipPlane));
        //TextTitle.transform.position = mainCamera.ScreenToWorldPoint(new Vector3(width / 2, heightVal + (height/ 5), mainCamera.nearClipPlane));
        //TextDescription.transform.position = mainCamera.ScreenToWorldPoint(new Vector3(width / 2, heightVal + (height/ 2.5f), mainCamera.nearClipPlane));
        
        TextTitle.text = gameDetails.GetComponent<GameInfoDataClass>().title;
        TextDescription.text = gameDetails.GetComponent<GameInfoDataClass>().line1 + "\n" + gameDetails.GetComponent<GameInfoDataClass>().line2 + "\n" + gameDetails.GetComponent<GameInfoDataClass>().line3;
        int buttonScaleHeight = height / 6;
        int buttonScaleWidth = width /2;
        RectTransform ButtonRect = playButton.GetComponent<RectTransform>();
        ButtonRect.sizeDelta =  new Vector2(buttonScaleWidth, buttonScaleHeight);
        ButtonRect.position = mainCamera.ScreenToWorldPoint(new Vector3(width/2, height/2 - 300, mainCamera.nearClipPlane));
        Text PlayGame = playButton.GetComponentInChildren<Text>();
        PlayGame.fontSize = buttonScaleHeight / 4;



        
        
    }
}
