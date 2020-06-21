using System;

public class MenuItem : RoomObject
{
    private bool _key;
    public bool key()
    {
        return _key;
    }

	public MenuItem(string name, string description, bool key)
	{
        _name = name;
        _desc = description;
        _key = key;
	}
}
