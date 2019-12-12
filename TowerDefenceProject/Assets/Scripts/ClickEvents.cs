using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEvents : MonoBehaviour
{
    public void Clicked ()
    {
        AudioManager.instance.PlaySounds("MenuSound");
        
    }

    public void TimeScaleNormal()
    {
        Time.timeScale = 1;
    }
}
