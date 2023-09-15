using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    public Transform Root
    {
        get
        {
            if (_root == null)
                _root = new GameObject("@UI_Root").transform;

            return _root;
        }
    }

    Transform _root;
    int _order = 10;
    Stack<UI_Popup> _popupStack = new Stack<UI_Popup>();
    
    public UI_Scene SceneUI { get { return _sceneUI; } set { _sceneUI = value; } }
    UI_Scene _sceneUI;

    public void SetCanvas(GameObject go, bool sort)
    {
        if (go == null)
            return;
        
        Canvas canvas = go.GetOrAddComponent<Canvas>();
        canvas.overrideSorting = sort;
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;

        if(sort)
        {
            canvas.sortingOrder = _order++;
        }
        else
        {
            canvas.sortingOrder = 0;
        }
    }

    public T ShowPopupUI<T>(string name = null) where T : UI_Popup
    {
        if(string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = Managers.Resource.Instantiate($"UI/Popup/{name}");

        if (go == null)
            return null;

        T popup = go.GetOrAddComponent<T>();
        popup.transform.SetParent(Root);
        _popupStack.Push(popup);
        return popup;
    }

    public T ShowsceneUI<T>(string name = null) where T : UI_Scene
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = Managers.Resource.Instantiate($"UI/Scene/{name}");

        if (go == null)
            return null;

        T sceneUI = go.GetOrAddComponent<T>();
        sceneUI.transform.SetParent(Root);
        _sceneUI = sceneUI;
        return sceneUI;
    }

    public void ClosePopupUI()
    {
        if (_popupStack.Count == 0)
            return;

        UI_Popup popup = _popupStack.Pop();
        Managers.Resource.Destory(popup.gameObject);
        _order--;
    }

    public void ClosePopupUI(UI_Popup popup)
    {
        if (_popupStack.Count == 0)
            return;

        if(_popupStack.Peek() == popup)
            ClosePopupUI();
    }

    public void CloseAllPopupUI()
    {
        while (_popupStack.Count > 0)
            ClosePopupUI();
    }

    public void Clear()
    {
        CloseAllPopupUI();
        _sceneUI = null;
    }
}
