using System;
using System.Collections.Generic;

public class Player
{
    public List<MenuItem> inventory;
    int _invLimit = 9;
    public int invLimit()
    {
        return _invLimit;
    }
    int _soul = 3;
    public Player(MenuItem[] inventory)
	{
       for (int i = 0; i < inventory.Length; i++)
        {
            inventory[i] = inventory[i];
        }
	}
}
