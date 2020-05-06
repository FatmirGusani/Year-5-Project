using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonNewHero : MonoBehaviour
{
    public Button NewHero;
    public static bool FanirBossBeat;
    public static bool LagoonBossBeat;
    public static bool PanbooBossBeat;

    private void Start()
    {
        if (FanirBossBeat && LagoonBossBeat && PanbooBossBeat)
        {
            NewHero.gameObject.SetActive(true);
        }
        else
        {
            NewHero.gameObject.SetActive(false);
        }
    }
}
