using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    BuildArea _buildingSize;
    bool _onBuildMode;

    private void Start()
    {

        //GameObject go = Managers.Resource.Instantiate("BuildArea");
    }

    void OnInputKeyEvent()
    {
        //if(Input.GetKeyDown(KeyCode.B))
        //{
        //    _onBuildMode = !_onBuildMode;
        //    Debug.Log($"BuildMode {_onBuildMode}");


        //    if (_onBuildMode)
        //    {
        //        GameObject go = new GameObject();
        //        _buildingSize = go.GetOrAddComponent<BuildArea>();
        //        _buildingSize.SetInfo();
        //    }
        //    else
        //    {
        //        Managers.Resource.Destory(_buildingSize.gameObject);
        //    }
        //}
    }

    private void Update()
    {
        OnInputKeyEvent();
        
        if(_onBuildMode)
        {
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //RaycastHit hit;

            //if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            //{
            //    if (hit.transform.CompareTag("Construction"))
            //    {
            //        transform.position = hit.transform.position + Vector3.up * 0.75f;
            //    }
            //}

            //if (_buildingSize.IsBuildable() && Input.GetMouseButtonDown(0))
            //{
            //    Managers.Object.CreateBuilding(Define.BuildType.MultiShotTower).transform.position = _buildingSize.GetBuildPos();
            //    Debug.Log("Check");
            //}
        }
    }

    public void SetBuildingSize(Define.BuildType type)
    {
        int width = Managers.Data.Builds[type].width;
        int height = Managers.Data.Builds[type].height;

    }
}
