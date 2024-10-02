using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class FestiveThemeScript : MonoBehaviour
{
    public SpriteRenderer[] imageRenderers;  
    public Sprite[] normalSprites;
    public Sprite[] festiveSprites;

    public ParticleSystem snow = null;
    // Start is called before the first frame update
    void Start()
    {
        setTheme();

    }


     private void setTheme(){
        if (FestiveManager.instance.isFestive){
            for (int i = 0; i < imageRenderers.Length; i++){
                imageRenderers[i].sprite = festiveSprites[i];
            }
            if (snow != null && !snow.isPlaying){
                snow.Play();
            }
        }
        else{
            for (int i = 0; i < imageRenderers.Length; i++){
                imageRenderers[i].sprite = normalSprites[i];
            }
             if (snow != null && snow.isPlaying){
                snow.Stop();
            }
        }
    }
}
