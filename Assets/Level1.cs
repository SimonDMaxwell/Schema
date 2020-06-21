using System;
using UnityEngine;

public class Level1 : Level
{

    public Level1()
    {
        _theme = new String[] { "Music_Car", "Music_WindHowl"};
        _intro = new string[9];
        _intro[0] = "SCHEMA";
        _intro[1] = "A Game By Simon Maxwell";
        _intro[2] = "9:15pm Breckenridge, Colorado, United States of America.";
        _intro[3] = "I am... what you would call a lowlife. I've gone lower than most humans would ever go, endorsed and indulged in the most perverse acts.\n\n" +
            "I was satisfied, but it could never last. My family, in the face of all this," +
            " was at the back of my mind. Until the day I lost her, the day I lost my wife." +
            " The evil I had done was catching up to me...";
        _intro[4] = "I confessed to my only daughter with a heavy heart, but once she knew the truth, I could see it in her eyes." +
            " She blamed me for her mother's death, my twelve year old daughter no longer wished to see my face." +
            " I sent her away to her grandparents on her mother's side, that way she could at least be closer to her.\n\n" +
            " It's been seven years now since then, and she's finally starting to forgive me. I know I don't deserve it." +
            " But I want my daughter to love me again, I want to fix this broken relationship between us.";
        _intro[5] = "My phone rang beside me in the car as I drove down the winding Colorado roads. Heavy snow had been falling for hours" +
            " now and there was even a warning of a blizzard rearing it's head. Braving the storm, I answered anxiously, knowing it was Kelly. " +
            "\"Goodnight sweetheart, to what do I owe an audience with the stunning princess Donaway?\" I answered, chuckling awkwardly.\n\n" +
            "Noticing she hadn't answered yet, I went on. \"If it's my arrival you're worried about, it's okay, I won't be late!\"";
        _intro[6] = "I tried to be chipper, but once I calmed down I heard how breathless she was. \"Sweetie? What's going on?\"\n\n" +
            "'Kshh!' The air quality of the call began to drop randomly. \"Daddy - kshh - I'm scared...\" Whimpered Kelly, something was obviously going wrong.\n\n" +
            "\"Shit! I can barely hear you, are you okay Kelly!?\" I asked, stepping on the gas as hard as I could. I didn't want to lose anymore precious" +
            " people. \"Kelly!\"\n\n" +
            "She screamed behind the veil of white noise, crying out for me. \"Save me! Som - kssh - I don't w - kssh - die!\"\n\n" +
            "\"Hold on princess I'm coming! Run, hide, whatever you need to do to survive until I get there okay! I promise you that I'll save you...\"";
        _intro[7] = "I heard a familiar voice on the other end of the line, but that voice was not as I remembered it. It was hollowed, void of life" +
            " and filled by suffering. \"You can't Adam... this is your punishment.\" The voice I heard on line, was the voice of my dead wife.\n\n" +
            "My eyes widened with terror. \"Th-this is impossible, you're dead! You're dead Martha!\" I cried out, but the call had already been disconnected.";
        _intro[8] = "The axels screeched as I floored the SUV on the icy asphalt. \"Come on! Faster dammit!\" I was terrified of losing my family, so terrified of the same thing happening again.\n\n" +
            "I drove recklessly, desperate to get to my daughter. But it wasn't long before I lost control of the car," +
            "it spun out of control and thunder rumbled through my bones. the next thing I knew avalanche fell, sweeping me away into darkness...\n\nEverything faded.";
        _introTriggers = new String[9];
        _introTriggers[0] = "";
        _introTriggers[1] = "";
        _introTriggers[2] = "SFX_Morse";
        _introTriggers[3] = "";
        _introTriggers[4] = "";
        _introTriggers[5] = "SFX_Ring";
        _introTriggers[6] = "SFX_Whitenoise";
        _introTriggers[7] = "SFX_Distorted";
        _introTriggers[8] = "SFX_Skid";
        _introInhibitors = new String[9];
        _introInhibitors[0] = "";
        _introInhibitors[1] = "";
        _introInhibitors[2] = "";
        _introInhibitors[3] = "SFX_Morse";
        _introInhibitors[4] = "";
        _introInhibitors[5] = "";
        _introInhibitors[6] = "";
        _introInhibitors[7] = "SFX_Whitenoise";
        _introInhibitors[8] = "";
        _exit = true;
    }
}
