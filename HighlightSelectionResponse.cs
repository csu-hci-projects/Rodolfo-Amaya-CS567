using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class HighlightSelectionResponse : MonoBehaviour, ISelectionResponse
{
    public void OnSelect(Transform selection)
    {
        var selectionRenderer = selection.GetComponent<Highlight>();

        // If the object is not a null object, change its material
        if (selectionRenderer != null)
        {
            selectionRenderer.setHighlight(true);
        }
    }

    public void OnDeselect(Transform selection)
    {
        var selectionRenderer = selection.GetComponent<Highlight>();
        if (selectionRenderer != null)
        {
            selectionRenderer.setHighlight(false);
        }
    }
}