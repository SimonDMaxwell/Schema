using System.Collections.Generic;

public class Container : RoomObject
{
    private string _key;
    public string key()
    {
        return _key;
    }
    private bool _isLocked;
    public bool is_locked()
    {
        return _isLocked;
    }
    public bool unlock(string key)
    {
        if (key == this._key)
        {
            _isLocked = false;
            return true;
        }
        return false;
    }
    public List<MenuItem> _items;

    public Container(string name, string description, string key, bool isLocked, List<MenuItem> items)
    {
        _type = "Container";
        _name = name;
        _desc = description;
        _key = key;
        _items = items;
    }
}
