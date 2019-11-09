using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class RaycastTagSelector : MonoBehaviour, ISelector
{
    [SerializeField] public string selectableTag = "Selectable";
    public Transform _selection;

    public void Check(Ray ray)
    {
        this._selection = null;
        if (Physics.Raycast(ray, out var hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag(this.selectableTag))
            {
                this._selection = selection;
            }
        }
    }

    public Transform GetSelection()
    {
        return this._selection;
    }
}

