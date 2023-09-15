using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuildArea : MonoBehaviour
{
    public List<Tile> TouchedTileList = new List<Tile>();
    List<Material> _matList = new List<Material>();
    BoxCollider _collider;
    Define.BuildType _type;
    int _size;
    bool _isBuild;

    private void Awake()
    {
        _collider = gameObject.GetOrAddComponent<BoxCollider>();
        _collider.isTrigger = true;
        gameObject.GetOrAddComponent<Rigidbody>().isKinematic = true;
    }

    private void Update()
    {
        if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            return;

        if (_matList.Count == 0 || _isBuild == false)
            return;
       
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.transform.CompareTag("Construction"))
            {
                transform.position = hit.transform.position + Vector3.up * 0.75f;
            }
        }

        if (IsBuildable() && Input.GetMouseButtonDown(0))
        {
            GameObject go = null;

            switch(_type)
            {
                case Define.BuildType.DefaultTower:
                    go = Managers.Object.CreateBuilding(Define.BuildType.DefaultTower);
                    break;
                case Define.BuildType.MultiShotTower:
                    go = Managers.Object.CreateBuilding(Define.BuildType.MultiShotTower);
                    break;
                case Define.BuildType.FocusAttackTower:
                    go = Managers.Object.CreateBuilding(Define.BuildType.FocusAttackTower);
                    break;
                case Define.BuildType.IllusionTower:
                    go = Managers.Object.CreateBuilding(Define.BuildType.IllusionTower);
                    break;
                case Define.BuildType.Obstacle:
                    go = Managers.Object.CreateBuilding(Define.BuildType.Obstacle);
                    break;
            }

            go.transform.position = GetBuildPos();
        }

        if (IsBuildable())
        {
            for (int i = 0; i < _matList.Count; i++)
            {
                Color color = Color.green;
                color.a = 0.4f;
                _matList[i].color = color;
            }
        }
        else
        {
            for (int i = 0; i < _matList.Count; i++)
            {
                Color color = Color.red;
                color.a = 0.4f;
                _matList[i].color = color;
            }
        }
    }

    public bool IsBuildable()
    {
        bool isRight = TouchedTileList.Count == _size;
        bool isUsed = false;

        for (int i = 0; i < TouchedTileList.Count; i++)
        {
            isUsed |= TouchedTileList[i].IsUsing;
        }

        return isRight == true && isUsed == false;
    }

    Vector3 GetBuildPos()
    {
        if(_size == 4)
            return new Vector3(transform.position.x + 1.25f, 2.5f, transform.position.z + 1.25f);

        return transform.position;
    }

    public void OnBuild(Define.BuildType type)
    {
        float pos = 2.5f;
        Data.BuildData data = Managers.Data.Builds[type];

        if (data.size == 1)
        {
            _matList.Add(Managers.Resource.Instantiate("BuildArea/BuildAreaSubitem", Vector3.zero, Quaternion.identity, transform).GetComponent<Renderer>().material);
            _collider.center = Vector3.zero;
            _collider.size = new Vector3(2f, 1, 2f);
            
        }
        else if(data.size == 4)
        {
            _matList.Add(Managers.Resource.Instantiate("BuildArea/BuildAreaSubitem", new Vector3(0, 0, 0), Quaternion.identity, transform).GetComponent<Renderer>().material);
            _matList.Add(Managers.Resource.Instantiate("BuildArea/BuildAreaSubitem", new Vector3(0, 0, pos), Quaternion.identity, transform).GetComponent<Renderer>().material);
            _matList.Add(Managers.Resource.Instantiate("BuildArea/BuildAreaSubitem", new Vector3(pos, 0, 0), Quaternion.identity, transform).GetComponent<Renderer>().material);
            _matList.Add(Managers.Resource.Instantiate("BuildArea/BuildAreaSubitem", new Vector3(pos, 0, pos), Quaternion.identity, transform).GetComponent<Renderer>().material);
            _collider.center = new Vector3(1.25f, 0f, 1.25f);
            _collider.size = new Vector3(4.5f, 1f, 4.5f);
        }

        transform.position = transform.position + Vector3.up;
        _size = data.size;
        _type = data.type;
        _isBuild = true;
    }

    public void Clear()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Managers.Resource.Destory(transform.GetChild(i).gameObject);
        }

        _matList.Clear();
        _isBuild = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Construction"))
        {
            Tile tile = other.GetComponent<Tile>();

            if (TouchedTileList.Contains(tile) == false)
                TouchedTileList.Add(tile);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Construction"))
        {
            Tile tile = other.GetComponent<Tile>();

            if (TouchedTileList.Contains(tile) == true)
                TouchedTileList.Remove(tile);
        }
    }
}
