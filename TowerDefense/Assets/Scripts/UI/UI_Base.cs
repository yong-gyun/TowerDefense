using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class UI_Base : MonoBehaviour
{
    protected Dictionary<Type, UnityEngine.Object[]> _objects = new Dictionary<Type, UnityEngine.Object[]>();
    protected abstract bool Init();

    private void Awake()
    {
        Init();
    }

    protected void Bind<T>(Type type) where T : UnityEngine.Object
    {
        string[] names = Enum.GetNames(type);
        UnityEngine.Object[] objects = new UnityEngine.Object[names.Length];
        _objects.Add(typeof(T), objects);

        for (int i = 0; i < names.Length; i++)
        {
            if (typeof(T) == typeof(GameObject))
                objects[i] = gameObject.FindChild(names[i], true);
            else
                objects[i] = gameObject.FindChild<T>(names[i], true);

            if (objects[i] == null)
                Debug.Log($"Bind Faild {names[i]}");
        }
    }

    protected void BindText(Type type) { Bind<TMP_Text>(type); }
    protected void BindInputField(Type type) { Bind<TMP_InputField>(type); }
    protected void BindSlider(Type type) { Bind<Slider>(type); }
    protected void BindScrollbar(Type type) { Bind<Scrollbar>(type); }
    protected void BindButton(Type type) { Bind<Button>(type); }
    protected void BindImage(Type type) { Bind<Image>(type); }

    protected T Get<T>(int idx) where T : UnityEngine.Object
    {
        UnityEngine.Object[] objects = null;

        if (_objects.TryGetValue(typeof(T), out objects) == false)
        {
            Debug.Log($"Get Faild {typeof(T).Name}");
            return null;
        }

        return objects[idx] as T;
    }

    protected TMP_Text GetText(int idx) { return Get<TMP_Text>(idx); }
    protected TMP_InputField GetInputField(int idx) { return Get<TMP_InputField>(idx); }
    protected Slider GetSlider(int idx) { return Get<Slider>(idx); }
    protected Scrollbar GetScrollbar(int idx) { return Get<Scrollbar>(idx); }
    protected Button GetButton(int idx) { return Get<Button>(idx); }
    protected Image GetImage(int idx) { return Get<Image>(idx); }
}
