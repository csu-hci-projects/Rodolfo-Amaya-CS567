using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tags : MonoBehaviour
{
    public string[] myTags;
    public bool hasTag(string tagToCheck)
    {
        foreach (string tag in myTags) //Can replace foreach with 'for loop'
        {
            if (tag == tagToCheck)
            {
                return true;
            }
        }
        return false;
    }
}