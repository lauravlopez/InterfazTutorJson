using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class MessageData  
{
    public string messageText;

    public bool GoodStateButton;
    public bool ExitButton;

    public bool sendGoodStateButton()
    {
        bool state = GoodStateButton;
        return state;
    }
}
