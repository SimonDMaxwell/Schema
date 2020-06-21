using System;
using System.Collections.Generic;

public class Door : RoomObject
{
    string _openMessage;
    Room newRoom;
    bool _isExit;
	public Door(string name, string openMessage, string roomName, List<Sinner> sinners, List<Container> containers, List<Door> doors, List<MenuItem> items, bool isExit)
	{
        _type = "Door";
        _name = name;
        _openMessage = openMessage;
        if (!isExit)
        {
            newRoom = new Room(roomName, containers.ToArray(), sinners.ToArray(), doors.ToArray(), items.ToArray());
        }
        _isExit = isExit;
	}
}
