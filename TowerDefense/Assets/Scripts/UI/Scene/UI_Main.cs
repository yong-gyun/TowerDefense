using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Main : UI_Scene
{
    enum Texts
    {

    }

    enum Buttons
    {
        BuyDefaultTowerButton,
        BuyMultiShotTowerButton,
        BuyFocusAttackTowerButton,
        BuyIllusionAsylumButton,
        BuyObstacleButton
    }

    BuildArea _buildArea;
    bool _buildMode;

    protected override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindButton(typeof(Buttons));
        GetButton((int)Buttons.BuyDefaultTowerButton).onClick.AddListener(OnClickBuyDefaultTowerButton);
        GetButton((int)Buttons.BuyMultiShotTowerButton).onClick.AddListener(OnClickBuyMultiShotTowerButton);
        GetButton((int)Buttons.BuyFocusAttackTowerButton).onClick.AddListener(OnClickBuyFocusAttackTowerButton);
        GetButton((int)Buttons.BuyIllusionAsylumButton).onClick.AddListener(OnClickBuyIllusionAsylumButton);
        GetButton((int)Buttons.BuyObstacleButton).onClick.AddListener(OnClickBuyObstacleButton);
        return true;
    }

    private void Update()
    {
        if(_buildMode)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                OnBuildCancle();
            }
        }


    }

    void OnClickBuyDefaultTowerButton()
    {
        CreateBuildArea(Define.BuildType.DefaultTower);
    }

    void OnClickBuyMultiShotTowerButton()
    {
        CreateBuildArea(Define.BuildType.MultiShotTower);

    }

    void OnClickBuyFocusAttackTowerButton()
    {
        CreateBuildArea(Define.BuildType.FocusAttackTower);

    }

    void OnClickBuyIllusionAsylumButton()
    {
        CreateBuildArea(Define.BuildType.ProtectedBase);
    }

    void OnClickBuyObstacleButton()
    {
        CreateBuildArea(Define.BuildType.Obstacle);

    }

    void CreateBuildArea(Define.BuildType type)
    {
        if (_buildArea == null)
        {
            GameObject go = new GameObject("BuildArea");
            _buildArea = go.GetOrAddComponent<BuildArea>();
        }

        _buildArea.OnBuild(type);
        _buildMode = true;
    }

    void OnBuildCancle()
    {
        Managers.Resource.Destory(_buildArea.gameObject);
    }
}
