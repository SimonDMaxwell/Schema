using System;
using UnityEngine;
using System.Collections.Generic;

public class Level
{
    protected string[] _theme;
    public string[] theme()
    {
        return _theme;
    }
    protected string[] _intro;
    public string[] intro()
    {
        return _intro;
    }
    protected string[] _introTriggers;
    public string[] introTriggers()
    {
        return _introTriggers;
    }
    protected string[] _introInhibitors;
    public string[] introInhibitors()
    {
        return _introInhibitors; 
    }

    public List<Room> rooms = new List<Room>();
    protected bool _exit = false;
    public bool exit()
    {
        return _exit;
    }
    public bool introPlayed;

    public Level()
    {
    }

    public void Complete()
    {
        _exit = true;
    }
}
