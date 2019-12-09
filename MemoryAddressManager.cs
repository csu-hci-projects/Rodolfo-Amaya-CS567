using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class MemoryAddressManager : MonoBehaviour
{
    public ObjectSpawnManager objectSpawnManager;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        List<GameObject> objs = objectSpawnManager.GetActiveObjects();



        for (int i = 0; i < objs.Count; i++)
        {
            var pt1 = objectSpawnManager.GetActiveObjects().ElementAt(i);
            var textMp = pt1.GetComponentInChildren<TextMeshPro>();
            //var tmp = pt1.GetComponent<TextMeshPro>();
            if(textMp != null)
            {
                //int intValue = 182;
                // Convert integer 182 as a hex in a string variable
                //string hexValue = intValue.ToString("X");

                //textMp.SetText(hexValue);
                //print(hexValue);
            }
        }
    }
}
