using System;

public class MenuItem
{
    public string Label { get; set; }
    public Action Action { get; set; }

    public MenuItem(string label, Action action)
    {
        Label = label;
        Action = action;
    }
}