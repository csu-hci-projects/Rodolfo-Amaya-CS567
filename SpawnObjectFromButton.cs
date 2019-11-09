using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;


class SpawnObjectFromButton : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject prefabBool;
    public GameObject prefabU16;
    public GameObject prefabU32;
    public GameObject prefabDouble;
    public GameObject prefabStruct;
    public SelectionManager _selectionManager;

    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
    //}

    private void Awake()
    {
    }

    public void SpawnObject()
    {
        string buttonPressed = EventSystem.current.currentSelectedGameObject.name;

        switch (buttonPressed)
        {
            case ("Bool"):
                Instantiate(prefabBool, spawnPoint.position + (spawnPoint.forward * 4f), spawnPoint.rotation);
                break;
            case ("U16"):
                Instantiate(prefabU16, spawnPoint.position + (spawnPoint.forward * 12f), spawnPoint.rotation);
                break;
            case ("U32"):
                Instantiate(prefabU32, spawnPoint.position + (spawnPoint.forward * 16f), spawnPoint.rotation);
                break;
            case ("Double"):
                Instantiate(prefabDouble, spawnPoint.position + (spawnPoint.forward * 20f), spawnPoint.rotation);
                break;
            case ("Delete"):
                _selectionManager.DeleteSelections();
                break;
            case ("Combine"):
                List<Transform> _selections = _selectionManager.GetSelections();
                if (_selections.Count > 1)
                {
                    Vector3 NewSize = new Vector3();
                    foreach (Transform t in _selections)
                    {
                        //print(t.localScale);
                        //print(t.lossyScale);
                        NewSize.y += t.localScale.y;
                    }
                    NewSize.x = 4;
                    NewSize.z = 0.5f;
                    print(NewSize);
                    prefabStruct.transform.localScale = NewSize;
                    _selectionManager.DeleteSelections();
                    Instantiate(prefabStruct, spawnPoint.position + (spawnPoint.forward * 24f), spawnPoint.rotation);
                }
                break;
            default:
                break;
        }
    }
}
