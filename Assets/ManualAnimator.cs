using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManualAnimator
{
    Dictionary<string, Func<Text, string, int>> methods = new Dictionary<string, Func<Text, string, int>>();

    int content(Text text, string value)
    {
        text.text = value;
        return 0;
    }

    public ManualAnimator()
    {
        methods.Add("content",content);
    }
	public void TextAnimate(Text text, string property, string value)
	{
        methods[property](text, value);
        Debug.Log("animated");
	}
}
