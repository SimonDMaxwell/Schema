using System;
using System.Collections.Generic;

public class Level2 : Level
{
    Room temproom;
    List<Container> tempcontainers;
    List<MenuItem> tempitems;
    List<MenuItem> tempmenuitems;
    List<Sinner> tempsinners;
    List<Door> tempdoors;
    Room tempdorroom;

	public Level2()
	{
        _theme = new string[] {"Music_Theme1"};
        _intro = new string[2];
        _intro[0] = "I opened my eyes to an uncomfortable, searing heat, noticing that strange being wearing cloaks surrounded me. They chattered," +
            " speaking ominous tongues inside this strange labyrinth that reeked of sulfur. \"Where am I? I have to... to get to Kelly.\"\n\n I struggled to my feet as they watched, and they scorned" +
            " me, moving away in disgust. \"Who the hell are you? Why am I here!?\"";
        _intro[1] = "The sound of shuffling foosteps emerged behind me in my groggyness. \"Stay away!\" I shouted and tossed around to see what was" +
            " approaching me, but a cloaked being amushed me, hitting me over the head with a large sceptre. Once again I floated into the darkness.";
        //Rooms Data
        tempsinners.Add(new Sinner("Hell's Officer",
            "A monster... wearing blue theme of a policeman's uniform. It's fat and greedy looking, but there's something interesting under its arm!",
            "Adam takes out a picture of Kelly and frantically shows it to the uniformed beast.\"Please, I need you to tell me where I am! Look at this," +
            " that's my daughter... I need to get to her.\" He pleaded, but the beast did not pay him heed.\n\n" +
            "\"I'm so hungry...\"\n\n \"Damnit look at me! Why won't anyone help me...\" He sobbed.",
            "\"Is... is that a donut!? Give it to me!\" The beast gobbles it down and happily belches. \"Yawn~ I'm going to sleep now.\"\n\n" +
            "While the beast sleeps, you sneak the key from under it's heavy arm.",
            "Strawberry Donut",
            new MenuItem("Officer's Key", "One key, to open them all.", true),
            "Demon",
            true));
        tempsinners.Add(new Sinner("Zenbeth",
            "A being lurking in the shadows quietly on it's lonesome, a social butterfly if i've ever seen one.",
            "\"Do you really think you should be talking to me?\"",
            "",
            "",
            null,
            "Demon",
            false));
        tempsinners.Add(new Sinner("Chagharim1",
            "There are some other monsters here, three that look exactly alike except for their demeanors. This is the first brother.",
            "\"Open the first drawer, all other tell lies.\"",
            "",
            "",
            null,
            "Natural",
            false));
        tempsinners.Add(new Sinner("Chagharim2",
            "There are some other monsters here, three that look exactly alike except for their demeanors. This is the second brother.",
            "\"Open the second drawer, only I tell the truth! My brothers should have their tongues cut off.\"",
            "",
            "",
            null,
            "Natural",
            false));
        tempsinners.Add(new Sinner("Chagharim3",
            "There are some other monsters here, three that look exactly alike except for their demeanors. This is the third brother.",
            "\"Please open the third drawer, the first brother speaks true.\" *sobs*",
            "",
            "",
            null,
            "Natural",
            false));
        tempmenuitems.Add(new MenuItem("Moldy Cheese", "Ugh... that's just plain funky.", false));
        tempcontainers.Add(new Container("Police Desk Drawer",
            "The first drawer in the police creature's desk, it's locked.",
            "Officer's Key",
            true,
            tempmenuitems));
        tempmenuitems.Clear();
        tempmenuitems.Add(new MenuItem("Level Key", "???", true));
        tempcontainers.Add(new Container("Police Desk Drawer",
            "The second drawer in the police creature's desk, it's locked.",
            "Officer's Key",
            true,
            tempmenuitems));
        tempmenuitems.Clear();
        tempmenuitems.Add(new MenuItem("The Meaning of Life", "What is this garbage?\n\n :Adam throws away the book without hesitation, but it somehow comes back to him.", false));
        tempcontainers.Add(new Container("Police Desk Drawer",
            "The third drawer in the police creature's desk, it's locked.",
            "Officer's Key",
            true,
            tempmenuitems));
        tempmenuitems.Clear();
        tempmenuitems.Add(new MenuItem("Strawberry Donut", "A dirty donut.", true));
        tempcontainers.Add(new Container("Sofa Seats",
            "Did somebody... lose something under here?",
            "",
            false,
            tempmenuitems));
        tempitems.Add(new MenuItem("Renaissance Painting", "I don't know what this is named, but nudists would love it.", false));
        tempitems.Add(new MenuItem("Waitign Sopha", "Whoever wrote this sign doesn't know how to spell...", false));
        tempdoors.Add(new Door("Pious Door", "You will never escape here for all eternity.", null, null, null, null, null, true));
        temproom = new Room("Lobby",
            tempcontainers.ToArray(),
            tempsinners.ToArray(),
            tempdoors.ToArray(),
            tempitems.ToArray());
        rooms.Add(temproom);
    }
}
