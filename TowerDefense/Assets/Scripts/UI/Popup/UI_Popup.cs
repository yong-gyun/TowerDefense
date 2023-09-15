using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Popup : UI_Base
{
    bool _init;

    protected override bool Init()
    {
        if (_init)
            return false;

        Managers.UI.SetCanvas(gameObject, true);

        _init = true;
        return true;
    }

    public virtual void ClosePopupUI()
    {

    }
}
