using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class startmenu : MonoBehaviour
{
    ManualAnimator mananim = new ManualAnimator();
    bool titleswitch;
    List<Action> menuChoices = new List<Action>();
    public List<Text> texts;
    public List<Font> fonts;
    public AudioSource UI_Action;
    int sel = 0;
    int min = 0;
    int max = 1;

    Color BLACK = new Color(0, 0, 0);
    Color WHITE = new Color(1, 0.5f, 0.5f);
    Color RED = new Color(255,0.2f,0.2f);
    // Start is called before the first frame update
    void Start()
    {
        menuChoices.Add(start_game);
        menuChoices.Add(continue_);
        InvokeRepeating("title", 0.0f, 0.75f);
    }

    //Start game button
    public void start_game()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Continue button
    public void continue_()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void Update()
    {
        texts[sel + 1].font = fonts[1];
        texts[max - sel + 1].font = fonts[0];
        if (Input.GetButtonDown("Down"))
        {
            if (sel < max)
            {
                sel++;
                UI_Action.Play();
            }
        } else if (Input.GetButtonDown("Up"))
        {
            if (min < sel)
            {
                sel--;
                UI_Action.Play();
            }
        } else if (Input.GetButtonDown("Submit"))
        {
            UI_Action.Play();
            print("submitted");
            switch (sel)
            {
                case 0:
                    SceneManager.LoadScene("LevelPlayer");                    
                    break;
                case 1:
                    SceneManager.LoadScene("LevelPlayer");
                    break;
            }
        }
        switch (sel)
        {
            case 0:
                
                break;
            case 1:
                
                break;
        }
    }

    void title()
    {
        Debug.Log("launched");
        if (titleswitch)
        {
            mananim.TextAnimate(texts.ToArray()[0], "content", "Schema_");
            titleswitch = !titleswitch;
        } else
        {
            mananim.TextAnimate(texts.ToArray()[0], "content", "Schema");
            titleswitch = !titleswitch;
        }
    }
}
