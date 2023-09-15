using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager
{
    public List<EnemyController> MonsterList { get { _enemyList.RemoveAll(m => m == null); return _enemyList; } }
    List<EnemyController> _enemyList = new List<EnemyController>();
    public List<BuildingController> ProtectedBase { get; private set; } = new List<BuildingController>();

    public GameObject CreateBuilding(Define.BuildType type)
    {
        GameObject go = Managers.Resource.Instantiate($"Building/{type}");

        if (go == null)
            return null;

        TowerController tc = go.GetComponent<TowerController>();
        tc.Type = type;
        tc.SetStat(type);
        return go;
    }

    public EnemyController SpawnEnemy(Define.EnemyType type)
    {
        GameObject go = Managers.Resource.Instantiate($"Enemy/{type}");

        if (go == null)
            return null;

        EnemyController ec = go.GetComponent<EnemyController>();
        ec.Type = type;
        ec.SetStat();
        _enemyList.Add(ec);
        return ec;
    }

    public void DespawnEnemy(EnemyController ec)
    {
        _enemyList.Remove(ec);

        //TODO 적 사망시 처리 추가
    }

    public void Clear()
    {
        MonsterList.Clear();
        ProtectedBase.Clear();
    }
}