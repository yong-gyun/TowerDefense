using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Scene : UI_Base
{
    bool _init;

    protected override bool Init()
    {
        if (_init)
            return false;

        Managers.UI.SetCanvas(gameObject, false);
        return true;
    }
}
