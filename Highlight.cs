using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


class Highlight : MonoBehaviour
{
    [SerializeField] public Transform component;
    [SerializeField] public Material defaultMaterial;
    [SerializeField] public Material highLightedMaterial;
    private bool hl;
    private bool needsUpdate;

    public bool highlight;

    public void setHighlight(bool value)
    {
        highlight = value;
        needsUpdate = true;
    }

    void Update()
    {
        if (needsUpdate)
        {
            needsUpdate = false;

            UpdateMaterialProperties();
        }
    }

    void UpdateMaterialProperties()
    {
        // Apply properties according to mode
        var selectionRenderer = component.GetComponent<Renderer>();

        // If the object is not a null object, change its material
        if (selectionRenderer != null)
        {
            if (highlight)
            {
                selectionRenderer.material = this.highLightedMaterial;
            }
            else
            {
                selectionRenderer.material = this.defaultMaterial;
            }
        }
    }
}

