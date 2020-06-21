using System;

public class Tracker
{
    public Player player;
    public Level levelData;
    int level;
	public Tracker(Player player, Level levelData, int level)
	{
        this.player = player;
        this.levelData = levelData;
        this.level = level;
	}
}
