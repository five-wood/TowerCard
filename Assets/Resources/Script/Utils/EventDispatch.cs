using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class EventDispatch
{
    Dictionary<string, List<Action>> Dict;
    public static void TriggerEvent(string eventStr,params object[] param)
    {
    }

    public static void AddEventListener(string eventStr,Action action)
    {
    }

    public static void RemoveEventListener(string eventStr, Action action)
    {
    }
}

