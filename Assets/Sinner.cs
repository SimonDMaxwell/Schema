using System;
using System.Collections.Generic;
using UnityEngine;

public class Sinner : RoomObject
{
    string _dialogue;
    public string dialogue()
    {
        return _dialogue;
    }
    string _keyDialogue;
    public string keyDialogue()
    {
        return _keyDialogue;
    }
    string _key;
    public string key()
    {
        return _key;
    }
    MenuItem _keyGift;
    public MenuItem keyGift()
    {
        return _keyGift;
    }
    bool _harmful;
    public bool harmful()
    {
        return _harmful;
    }
    bool _wanting;
    public bool wanting()
    {
        return _wanting;
    }

	public Sinner(string name, string desc, string dialogue, string keyDialogue, string key, MenuItem keyGift, string type, bool wanting)
	{
        _name = name;
        _desc = desc;
        _dialogue = dialogue;
        _keyDialogue = keyDialogue;
        _key = key;
        _keyGift = keyGift;
        _type = type; /*Sinner, Demon, Natural*/
        _wanting = wanting;
	}
}
