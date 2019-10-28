using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    [SerializeField] private Material highLightedMaterial;
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private string selectableTag = "Selectable";

    private Transform _selection;

    // Update is called once per frame
    void Update()
    {
        if (_selection != null)
        {
            //Deselect object
            var selectionRenderer = _selection.GetComponent<Renderer>();
            if (selectionRenderer != null)
            {
                selectionRenderer.material = defaultMaterial;
            }
        }

        // Set ray variable to camera center, in FPS controller the mouse is always at the screen center
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // Cast a ray into the distance, if an object is hit, the hit variable will return true
        _selection = null;
        if (Physics.Raycast(ray, out var hit))
        {
            // Get the location of the object that was hit and then get the object
            var selection = hit.transform;

            // Ensure the object is selectable
            if (selection.CompareTag(selectableTag)) ;
            {
                _selection = selection;

            }
        }

        if (_selection != null)
        { 
            var selectionRenderer = _selection.GetComponent<Renderer>();

            // If the object is not a null object, change its material
            if (selectionRenderer != null)
            {
                selectionRenderer.material = highLightedMaterial;
            }
        }
        
    }
}
