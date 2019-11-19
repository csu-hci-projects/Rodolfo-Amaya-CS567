using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectionManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private IRayProvider _rayProvider;
    private ISelector _selector;
    private ISelectionResponse _selectionResponse;

    private Transform _currentLongSelection;
    private Transform _currentSelection;
    private Transform _initialSelection;

    List<Transform> _CombinableSelections;

    private void Awake()
    {
        _selectionResponse = GetComponent<ISelectionResponse>();
        _selector = GetComponent<ISelector>();
        _rayProvider = GetComponent<IRayProvider>();
        _CombinableSelections = new List<Transform>();
    }

    public List<Transform> GetCombinableSelections()
    {
        return _CombinableSelections;
    }

    public Transform GetCurrentLongTouch()
    {
        return _currentLongSelection;
    }

    public void DeleteSelections()
    {
        foreach (Transform t in _CombinableSelections)
        {
            //_selections.Remove(t);
            _selectionResponse.OnDeselect(t);
            //Destroy(t.gameObject);
        }
        _CombinableSelections = new List<Transform>();
    }

    private float TouchTime = 0;

    // Update is called once per frame
    void Update()
    {
        // Set ray variable to camera center, in FPS controller the mouse is always at the screen center
        // Cast a ray into the distance, if an object is hit, the hit variable will return true
        // Get the location of the object that was hit and then get the object
        // Ensure the object is selectable

        if (Input.touchCount > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                Debug.Log("Touch Pressed");
                TouchTime = Time.time;
                //print(TouchTime);
                _selector.Check(_rayProvider.CreateRay());
                _initialSelection = _selector.GetSelection();
            }

            if (Input.touches[0].phase == TouchPhase.Ended)
            {
                //print(TouchTime);
                _selector.Check(_rayProvider.CreateRay());
                _currentSelection = _selector.GetSelection();

                Debug.Log("Touch Lifted/Released");
                if (_currentSelection != null && _initialSelection == _currentSelection)
                {
                    var ObjTags = _currentSelection.GetComponent<Tags>();
                    if (ObjTags.hasTag("Combinable"))
                    {
                        updateSelections(_currentSelection);
                    }

                    if (Time.time - TouchTime > 2.0)
                    {
                        //print("QUACK");
                        print(_selector.GetSelection().name);
                        _currentLongSelection = _selector.GetSelection();
                    }
                }
                

            }
        }
    }

    void updateSelections(Transform _selection)
    {
        if (_CombinableSelections.Count == 0)
        {
            //print("ADDING INITIAL");
            _CombinableSelections.Add(_currentSelection);
        }
        else if (_CombinableSelections.Count > 0)
        {
            bool Onhard = false;
            List<Transform> lockedSelections = _CombinableSelections;
            foreach (Transform t in _CombinableSelections)
            {
                if (t == _currentSelection)
                {
                    //print("DESELECTING");
                    _CombinableSelections.Remove(_currentSelection);
                    _selectionResponse.OnDeselect(_currentSelection);
                    Onhard = true;
                    break;
                }
            }
            if (Onhard == false)
            {
                //print("ADDING");
                _CombinableSelections.Add(_currentSelection);
            }
        }
        if(_CombinableSelections.Count > 0)
        {
            foreach (Transform t in _CombinableSelections)
            {
                _selectionResponse.OnSelect(t);
            }
        }
    }


}
