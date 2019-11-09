﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

interface ISelector
{
    void Check(Ray ray);
    Transform GetSelection();
}

