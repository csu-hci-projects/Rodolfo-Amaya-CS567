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

    private Transform _currentSelection;
    private Transform _initialSelection;

    List<Transform> _selections;

    private void Awake()
    {
        _selectionResponse = GetComponent<ISelectionResponse>();
        _selector = GetComponent<ISelector>();
        _rayProvider = GetComponent<IRayProvider>();
        _selections = new List<Transform>();
    }

    public List<Transform> GetSelections()
    {
        return _selections;
    }

    public void DeleteSelections()
    {

        foreach (Transform t in _selections)
        {
            //_selections.Remove(t);
            _selectionResponse.OnDeselect(t);
            Destroy(t.gameObject);
        }
        _selections = new List<Transform>();
        
    }

    public void CombineSelections()
    {
        
    }

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
                _selector.Check(_rayProvider.CreateRay());
                _initialSelection = _selector.GetSelection();
            }

            if (Input.touches[0].phase == TouchPhase.Ended)
            {
                _selector.Check(_rayProvider.CreateRay());
                _currentSelection = _selector.GetSelection();
                //print(_currentSelection);
                //print(_initialSelection);

                Debug.Log("Touch Lifted/Released");
                if (_currentSelection != null && _initialSelection == _currentSelection)
                {
                    updateSelections(_currentSelection);
                }
            }
        }
    }

    void updateSelections(Transform _selection)
    {
        if (_selections.Count == 0)
        {
            //print("ADDING INITIAL");
            _selections.Add(_currentSelection);
        }
        else if (_selections.Count > 0)
        {
            bool Onhard = false;
            List<Transform> lockedSelections = _selections;
            foreach (Transform t in _selections)
            {
                if (t == _currentSelection)
                {
                    //print("DESELECTING");
                    _selections.Remove(_currentSelection);
                    _selectionResponse.OnDeselect(_currentSelection);
                    Onhard = true;
                    break;
                }
            }
            if (Onhard == false)
            {
                //print("ADDING");
                _selections.Add(_currentSelection);
            }
        }
        if(_selections.Count > 0)
        {
            foreach (Transform t in _selections)
            {
                _selectionResponse.OnSelect(t);
            }
        }
    }


}
