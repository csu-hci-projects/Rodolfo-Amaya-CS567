using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;


public class ObjectSpawnManager : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject prefabBool;
    public GameObject prefabU16;
    public GameObject prefabU32;
    public GameObject prefabFloat;
    public GameObject prefabDouble;
    public GameObject prefabStruct;
    public GameObject prefabMain;
    public SelectionManager _selectionManager;

    private List<GameObject> ActiveObjects;

    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);

    void Start()
    {
        ActiveObjects = new List<GameObject>();
        ActiveObjects.Add(prefabMain);
    }

    private void Awake()
    {
    }

    public List<GameObject> GetActiveObjects()
    {
        return ActiveObjects;
    }

    public void SpawnObject()
    {
        string buttonPressed = EventSystem.current.currentSelectedGameObject.name;

        List<Transform> _selections = _selectionManager.GetCombinableSelections();
        switch (buttonPressed)
        {
            case ("Bool"):
                ActiveObjects.Add(Instantiate(prefabBool, spawnPoint.position + (spawnPoint.forward * 4f), spawnPoint.rotation));
                break;
            case ("U16"):
                ActiveObjects.Add(Instantiate(prefabU16, spawnPoint.position + (spawnPoint.forward * 12f), spawnPoint.rotation));
                break;
            case ("U32"):
                ActiveObjects.Add(Instantiate(prefabU32, spawnPoint.position + (spawnPoint.forward * 16f), spawnPoint.rotation));
                break;
            case ("Float"):
                ActiveObjects.Add(Instantiate(prefabFloat, spawnPoint.position + (spawnPoint.forward * 20f), spawnPoint.rotation));
                break;
            case ("Double"):
                ActiveObjects.Add(Instantiate(prefabDouble, spawnPoint.position + (spawnPoint.forward * 16f), spawnPoint.rotation));
                break;
            case ("Delete"):
                if (_selections.Count > 0)
                {
                    DeleteSelectedAciveObjects();
                    _selectionManager.DeleteSelections();
                }
                break;
            case ("Combine"):
                if (_selections.Count > 1)
                {
                    prefabStruct.transform.localScale = GetCombinedObjectSize();
                    DeleteSelectedAciveObjects();
                    _selectionManager.DeleteSelections();
                    ActiveObjects.Add(Instantiate(prefabStruct, spawnPoint.position + (spawnPoint.forward * 24f), spawnPoint.rotation));
                }
                break;
            default:
                break;
        }
        //print("List after adding: ");
        foreach (GameObject go in ActiveObjects)
        {
            print(go.name);
        }
    }

    Vector3 GetCombinedObjectSize()
    {
        List<Transform> _selections = _selectionManager.GetCombinableSelections();
        Vector3 NewSize = new Vector3();
        foreach (Transform t in _selections)
        {
            NewSize.y += t.localScale.y;
        }
        NewSize.x = 4;
        NewSize.z = 0.5f;
        return NewSize;
    }

    void DeleteSelectedAciveObjects()
    {
        //Start from the top to address issue of Count changing while objects are being removed
        for (int i = ActiveObjects.Count - 1; i >= 0; i--)
        {
            var selectionRenderer = ActiveObjects.ElementAt(i).GetComponent<Highlight>();
            if (selectionRenderer != null)
            {
                if (selectionRenderer.highlight == true)
                {
                    Destroy(ActiveObjects.ElementAt(i));
                    ActiveObjects.Remove(ActiveObjects.ElementAt(i));
                }
            }
        }
    }
}
