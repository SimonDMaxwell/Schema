using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelPlayLogic : MonoBehaviour
{
    /*Designer references*/
    public GameObject InventoryView;
    public GameObject RoomView;
    public GameObject ContainerView;
    public GameObject Conversation;
    //InventoryView
    public GameObject Hearts;
    public List<TMP_Text> Inventory;
    public TMP_Text Assessment;
    //Roomview
    public TMP_Text Cinematic;
    public TMP_Text RoomName;
    public TMP_Text DescBox;
    public TMP_Text[] Numbered;
    //ContainerView
    public TMP_Text Title;
    public List<TMP_Text> Slots;
    public TMP_Text Observation;
    //Conversation
    public TMP_Text Name;
    public GameObject Hint;
    public GameObject HintScript;
    public TMP_Text SpeechBox;
    /**/
    public Player player;
    Dictionary<string, AudioSource> SoundLibrary = new Dictionary<string, AudioSource>();
    public TMP_FontAsset Who_Asks_Satan;
    public TMP_FontAsset Type_Writer;
    public AudioSource[] slib;

    //Logic Variables
    int level = 0;
    float delay = 0.1f;
    bool introPlayed;
    List<Level> levels = new List<Level>();

    // Start is called before the first frame update. Sets up vital variables that will be used extensively.
    void Start()
    {
        SoundLibrary.Add("Music_Car", slib[0]);
        SoundLibrary.Add("Music_Theme1", slib[1]);
        SoundLibrary.Add("Music_Theme2", slib[2]);
        SoundLibrary.Add("Music_WindHowl", slib[3]);
        SoundLibrary.Add("SFX_Avalanche", slib[4]);
        SoundLibrary.Add("SFX_Breathing", slib[5]);
        SoundLibrary.Add("SFX_Distorted", slib[6]);
        SoundLibrary.Add("SFX_Growl", slib[7]);
        SoundLibrary.Add("SFX_Eating", slib[8]);
        SoundLibrary.Add("SFX_Moan", slib[9]);
        SoundLibrary.Add("SFX_Skid", slib[10]);
        SoundLibrary.Add("SFX_Morse", slib[11]);
        SoundLibrary.Add("SFX_Ring", slib[12]);
        SoundLibrary.Add("SFX_Whitenoise", slib[13]);
        levels.Add(new Level1());
        levels.Add(new Level2());
        Run();
    }

    // After loading but before Intro. Prepares conditions for intro playing.
    void Run()
    {
        for (int i = 0; i < levels[0].theme().Length; i++)
        {
            SoundLibrary[levels[0].theme()[i]].Play();
        }
        if (!levels[0].introPlayed)
        {
            StartCoroutine(PlayIntro(levels[0].intro(), levels[0].introTriggers(), levels[0].introInhibitors()));
        }
        try
        {
            RoomView.SetActive(true);
            RoomPrep();
        }
        catch { }
    }

    // Update specific variables
    bool updateLock = false;
    string state = "RoomView";
    //InventoryView variables
    int invScroll = 1;
    int invMin = 0;
    int invMax;
    int primary;
    //RoomView Variables
    int roomScroll = 1;
    int roomMin = 0;
    int roomMax;
    int itemScroll = 1;
    int itemMin = 0;
    int itemMax;
    //ContainerView
    int containerScroll = 1;
    int containerMin = 0;
    int containerMax;

    //Prepares variables for InventoryView
    void InvPrep()
    {
        state = "InventoryView";
        for (int i = 0; i < player.inventory.Count; i++)
        {
            Inventory[i].text = player.inventory[i].name();
            invMax = i;
        }
        InventoryView.SetActive(true);
    }
    //Prepares variables for RoomView
    void RoomPrep()
    {
        RoomName.text = levels[0].rooms.ToArray()[roomScroll].name;
        for (int i = 0; i < levels[0].rooms.ToArray()[roomScroll].roomObjects.Count; i++)
        {
            Numbered[i].text = levels[0].rooms.ToArray()[roomScroll].roomObjects.ToArray()[i].name();
            roomMax = i;
        }
    }
    //Prepares variables for ContainerView
    void ContainerPrep()
    {
        ContainerView.SetActive(true);
        state = "ContainerView";
    }
    //Prepares variable for Conversation
    void ConvPrep()
    {
        state = "Conversation";
        Name.text = ((Sinner)levels[0].rooms.ToArray()[roomScroll].roomObjects.ToArray()[itemScroll]).name();
        Hint.GetComponent<HintRotator>().Rotate(((Sinner)levels[0].rooms.ToArray()[roomScroll].roomObjects.ToArray()[itemScroll]).type());
        Conversation.SetActive(true);
    }
    // Update is called once per frame
    private void Update()
    {
        if (levels[0].exit())
        {
            level++;
        }
        if (!updateLock)
        {
            if (introPlayed)
            {
                /*InventoryView*/
                if (state == "InventoryView")
                {
                    //Items Display
                    Inventory[invScroll].font = Who_Asks_Satan;
                    for (int i = 0; i < invMax; i++)
                    {
                        if (i != invScroll)
                        {
                            Inventory[i].font = Type_Writer;
                        }
                    }
                    //Descriptions Display
                    Assessment.text = player.inventory.ToArray()[invScroll].desc();
                    //Item type submissions
                    if (Input.GetButtonDown("Submit"))
                    {
                        primary = invScroll;
                    }
                    //Navigation
                    INavigation(invMin, invMax, ref invScroll);
                }
                /*RoomView*/
                if (state == "RoomView")
                {
                    //Items Display
                    Numbered[itemScroll].font = Who_Asks_Satan;
                    for (int i = 0; i < itemMax; i++)
                    {
                        if (i != itemScroll)
                        {
                            Numbered[i].font = Type_Writer;
                        }
                    }
                    //Descriptions Display
                    DescBox.text = levels[level].rooms.ToArray()[roomScroll].roomObjects.ToArray()[itemScroll].desc();
                    //Item type submissions
                    if (Input.GetButtonDown("Submit"))
                    {
                        switch (levels[level].rooms.ToArray()[roomScroll].roomObjects.ToArray()[itemScroll].type())
                        {
                            case "Container":
                                RoomView.SetActive(false);
                                ContainerPrep();
                                break;
                            case "Sinner":
                                RoomView.SetActive(false);
                                ConvPrep();
                                break;
                            case "Door":

                                break;
                        }
                    }
                    //Navigation Presses
                    Navigation(itemMin, itemMax, ref itemScroll, roomMin, roomMax, ref roomScroll);
                }
                /*ContainerView*/
                if (state == "ContainerView")
                {
                    //Item display
                    Slots[containerScroll].font = Who_Asks_Satan;
                    for (int i = level; i < containerMax; i++)
                    {
                        if (i != containerScroll)
                        {
                            Slots[i].font = Type_Writer;
                        }
                    }
                    //Description display
                    Observation.text = ((Container) levels[level].rooms.ToArray()[roomScroll].roomObjects.ToArray()[itemScroll])._items.ToArray()[containerScroll].desc();
                    //Submissions
                    if (Input.GetButtonDown("Submit"))
                    {
                        if (invMax < player.invLimit())
                        {
                            //Copy item to inventory
                            player.inventory.Add(((Container)levels[level].rooms.ToArray()[roomScroll].roomObjects.ToArray()[itemScroll])._items.ToArray()[containerScroll]);
                            //Remove original from container
                            ((Container)levels[level].rooms.ToArray()[roomScroll].roomObjects.ToArray()[itemScroll])._items.RemoveAt(containerScroll);
                            //Reload concerned systems
                            InvPrep();
                            ContainerPrep();
                        }
                    }
                    //Navigation
                    INavigation(containerMin, containerMax, ref containerScroll);
                }
                /*Conversation*/
                if (state == "Conversation")
                {
                    type_speech(((Sinner)levels[level].rooms.ToArray()[roomScroll].roomObjects.ToArray()[itemScroll]).dialogue());
                }
            }
        }
    }
    IEnumerator type_speech(string str)
    {
        for (int a = 0; a < str.Length; a++)
        {
            SpeechBox.text += str[a];
            if (Input.GetButtonDown("Submit"))
            {
                delay = 0.025f;
            }
            yield return new WaitForSecondsRealtime(delay);
        }
        delay = 0.1f;
    }
    //Room level navigation logic
    void Navigation(int vertMin, int vertMax, ref int yScroll, int horizMin, int horizMax, ref int xScroll)
    {
        if (Input.GetButtonDown("Up"))
        {
            if (yScroll < vertMin)
            {
                yScroll--;
            }
        }
        if (Input.GetButtonDown("Down"))
        {
            if (yScroll < vertMax)
            {
                yScroll++;
            }
        }
        if (Input.GetButtonDown("Left"))
        {
            if (xScroll > horizMin)
            {
                xScroll--;
                RoomPrep();
            }
        }
        if (Input.GetButtonDown("Right"))
        {
            if (xScroll < horizMax)
            {
                xScroll++;
                RoomPrep();
            }
        }
        if (Input.GetButtonDown("E"))
        {
            RoomView.SetActive(false);
            InvPrep();
        }
    }
    //Interaction Level Navigation
    void INavigation(int vertMin, int vertMax, ref int yScroll)
    {
        if (Input.GetButtonDown("Up"))
        {
            if (yScroll > vertMin)
            {
                yScroll--;
            }
        }
        if (Input.GetButtonDown("Down"))
        {
            if (yScroll < vertMax)
            {
                yScroll++;
            }
        }
        if (Input.GetButtonDown("Left"))
        {
            InventoryView.SetActive(false);
            RoomView.SetActive(true);
        }
    }
    // Method for playing level intros
    private IEnumerator PlayIntro(string[] intro, string[] triggers, string[] inhibitors)
    {
        introPlayed = false;
        for (int i = 0; i < intro.Length; i++)
        {
            Cinematic.text = "";
            try
            {
                SoundLibrary[triggers[i]].Play();
            }
            catch { }
            try
            {
                SoundLibrary[inhibitors[i]].Stop();
            }
            catch { }
            for (int a = 0; a < intro[i].Length; a++)
            {
                Cinematic.text += intro[i][a];
                if (Input.GetButtonDown("Submit"))
                {
                    delay = 0.025f;
                }
                yield return new WaitForSecondsRealtime(delay);                
            }
            delay = 0.1f;
            yield return waitButtonDown("Submit");
        }
        Cinematic.text = "";
        introPlayed = true;
    }

    private IEnumerator waitButtonDown(string but)
    {
        bool done = false;
        while (!done)
        {
            if (Input.GetButtonDown(but))
            {
                done = true;
            }
            yield return null;
        }
    }
}
