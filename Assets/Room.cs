using System;
using System.Collections.Generic;

public class Room
{
    // Possible components of a given room
    public string name;
    public List<RoomObject> roomObjects = new List<RoomObject>();

    public Room(string _name, Container[] _containers, Sinner[] _sinners, Door[] _doors, MenuItem[] _items)
	{
        name = _name;
        roomObjects.AddRange(_containers);
        roomObjects.AddRange(_sinners);
        roomObjects.AddRange(_doors);
        roomObjects.AddRange(_items);
    }
}
