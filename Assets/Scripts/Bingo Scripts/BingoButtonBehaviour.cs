using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour
{
    int n;
    bool isBingo = false;
    public SpriteRenderer falsie;

    public void OnButtonPress()
    {
        n++;
        Debug.Log("Button clicked " + n + " times.");
        falsie.gameObject.SetActive(true);
        checkBingo();
    }

    public void checkBingo()
    {
        if (falsie == null)
        {
            Debug.LogError("falsie SpriteRenderer is not assigned!");
        }
        else
        {

        }
        Debug.Log("Before, falsie.enabled: " + falsie.enabled);

        if (isBingo)
        {
            // load up win scene
        }
        else
        {
            Debug.Log("entering Show()");
            Show();
        }
    }

    public void setIsBingo()
    {
        isBingo = true;
    }

    // for Falsie component
    // shows sprite for 3 seconds
    void Show()
    {
        falsie.enabled = true;
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        falsie.enabled = false;
        Debug.Log("Show() complete");
    }
}

