using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Totem : MonoBehaviour
{
    public enum Stats {
        Attack = 3,
        Defence = 3,
        Health = 3,
        ElementType };

    public GameObject WaterTotem;
    public GameObject AirTotem;
    public GameObject FireTotem;
    public GameObject EarthTotem;

    Element TotemElementType;

    public void PlaneClaimed(GameObject plane)
    {
        var ElementType = plane.GetComponent<ClickableSquare>().PlaneType;

        TotemElementType = ElementType;
        SpawnTotem(plane.transform.position);

    }
    void SpawnTotem(Vector3 postion)
    {

        if (TotemElementType == Element.Air)
            Instantiate(AirTotem, postion, Quaternion.identity);
        else if (TotemElementType == Element.Water)
            Instantiate(WaterTotem, postion, Quaternion.identity);
        else if (TotemElementType == Element.Fire)
            Instantiate(FireTotem, postion, Quaternion.identity);
        else if (TotemElementType == Element.Earth)
            Instantiate(EarthTotem, postion, Quaternion.identity);


    }
}

