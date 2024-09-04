using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameDescriptionManager : MonoBehaviour
{
    private Camera mainCamera;
    public GameObject gameDetails;
    public Text TextTitle;
    public Text TextDescription;
    public Button playButton;
    public Canvas gameDescription;

    private int height = 1080; //Screen.height;
    private int width = 1920; //Screen.width;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;   
        setUpImage();
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        //setUpImage();
    }
    public void setUpImage()
    {
        Debug.Log("setUpWasCalled");
        mainCamera = Camera.main;  //for scene switch - think of a better solution
        Transform imageTransforms = gameDetails.GetComponentInChildren<Transform>();
        imageTransforms.transform.localScale += new Vector3(1,1,1);
        float heightVal = height - (height / 5);
        Vector3 imagePoint = mainCamera.ScreenToWorldPoint(new Vector3(width / 2, heightVal + 63, mainCamera.nearClipPlane));
        imageTransforms.transform.position = imagePoint;
        TextTitle.rectTransform.position = mainCamera.ScreenToWorldPoint(new Vector3(width/2, height/2 + 100, mainCamera.nearClipPlane));
        TextDescription.rectTransform.position = mainCamera.ScreenToWorldPoint(new Vector3(width/2, height/2 - 100, mainCamera.nearClipPlane));
        Debug.Log("Width" + width + "height" + height);
        //TextTitle.transform.position = mainCamera.ScreenToWorldPoint(new Vector3(width / 2, heightVal + (height/ 5), mainCamera.nearClipPlane));
        //TextDescription.transform.position = mainCamera.ScreenToWorldPoint(new Vector3(width / 2, heightVal + (height/ 2.5f), mainCamera.nearClipPlane));
        
        TextTitle.text = gameDetails.GetComponent<GameInfoDataClass>().title;
        TextDescription.text = gameDetails.GetComponent<GameInfoDataClass>().line1 + "\n" + gameDetails.GetComponent<GameInfoDataClass>().line2 + "\n" + gameDetails.GetComponent<GameInfoDataClass>().line3;
        int buttonScaleHeight = height / 6;
        int buttonScaleWidth = width /2;
        RectTransform ButtonRect = playButton.GetComponent<RectTransform>();
        ButtonRect.sizeDelta =  new Vector2(buttonScaleWidth, buttonScaleHeight);
        ButtonRect.position = mainCamera.ScreenToWorldPoint(new Vector3(width/2, height/2 - 400, mainCamera.nearClipPlane));
        Text PlayGame = playButton.GetComponentInChildren<Text>();
        PlayGame.fontSize = buttonScaleHeight / 4;



        
        
    }
    public void exitInstructions()
    {
        Debug.Log("click");
        gameDescription.enabled = false;
        gameDetails.SetActive(false);
    }
    public void openInstructions()
    {
        exitInstructions();
        Destroy(gameObject);
        Debug.Log("Will delete");
        SceneManager.LoadScene("Instructions");
        //enable the instructions

        //if instructions goes to a new scene write the following code 
        
        //else do this line after instructions
    }
}
