using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

public class LineManager : MonoBehaviour
{
    public ObjectSpawnManager objectSpawnManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        List<GameObject> objs = objectSpawnManager.GetActiveObjects();

        /*
         * 
        var go = new GameObject();
        var lr = go.AddComponent<LineRenderer>();

        var gun = GameObject.Find("Gun");
        var projectile = GameObject.Find("Projectile");

        lr.SetPosition(0, gun.transform.position);
        lr.SetPosition(1, projectile.transform.position);
        *
        */

        for (int i = 0; i < objs.Count; i++)
        {
            var pt1 = objectSpawnManager.GetActiveObjects().ElementAt(i);
            var lr = pt1.GetComponent<LineRenderer>();
            if (i+1 < objs.Count)
            {
                var pt2 = objectSpawnManager.GetActiveObjects().ElementAt(i+1);
                lr.startColor = Color.blue;
                lr.endColor = Color.blue;
                lr.startWidth = 0.25f;
                lr.endWidth = 0.25f;
                lr.SetPosition(0, pt1.transform.position);
                lr.SetPosition(1, pt2.transform.position);
            }
            else 
            {
                break;
            }
        }
    }
}
