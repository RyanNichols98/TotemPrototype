using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class PlayerStats : MonoBehaviour
{
    public int MaxAP = 3;
    public int CurrentAP;
    public int AP = 1;
    public int TotalTotems;
    public int PlayerWins;
    public bool iSPlayerTurn;
    public Text APtext;


    public void ResetAP()
    {
        CurrentAP = MaxAP;
        APtext.text = CurrentAP.ToString();
    }

    public void UseAP()
    {

        CurrentAP -= AP;

        APtext.text = CurrentAP.ToString();

    }
    // Start is called before the first frame update
    void Start()
    {
        ResetAP();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
