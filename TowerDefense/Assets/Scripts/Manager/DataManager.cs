using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;
using static Define;

public class DataManager
{
    public Dictionary<BuildType, BuildData> Builds { get; private set; } = new Dictionary<BuildType, BuildData>();
    public Dictionary<BuildType, BuildStatData> BuildStat { get; private set; } = new Dictionary<BuildType, BuildStatData>();
    public Dictionary<EnemyType, EnemyStatData> EnemyStat { get; private set; } = new Dictionary<EnemyType, EnemyStatData>();

    public DataManager()
    {
        Init();
    }

    void Init()
    {
        LoadBuildData();
        LoadBuildStatData();
        LoadEnemyStatData();
    }

    void LoadEnemyStatData()
    {
        EnemyStat.Add(EnemyType.MeleeAttackUnit, new EnemyStatData(EnemyType.MeleeAttackUnit, 20f, 20f, 5f, 1f, 5f,2));
        EnemyStat.Add(EnemyType.RangedAttackUnit, new EnemyStatData(EnemyType.RangedAttackUnit, 15f, 20f, 5f, 1f, 5f, 4));
        EnemyStat.Add(EnemyType.QuickUnit, new EnemyStatData(EnemyType.QuickUnit, 20f, 20f, 5f, 1f, 7.5f, 5));
        EnemyStat.Add(EnemyType.FlyUnit, new EnemyStatData(EnemyType.FlyUnit, 10f, 20f, 5f, 1f, 5f, 8));;
        EnemyStat.Add(EnemyType.GoldUnit, new EnemyStatData(EnemyType.GoldUnit, 20f, 20f, 5f, 1f, 5f, 2));
        EnemyStat.Add(EnemyType.MiddleBossUnit, new EnemyStatData(EnemyType.MiddleBossUnit, 20f, 20f, 5f, 1f, 5f, 2));
        EnemyStat.Add(EnemyType.StageBossUnit, new EnemyStatData(EnemyType.StageBossUnit, 20f, 20f, 5f, 1f, 5f, 2));
    }

    void LoadBuildData()
    {
        Builds.Add(BuildType.DefaultTower, new BuildData(BuildType.DefaultTower, 10, 1, 1));
        Builds.Add(BuildType.MultiShotTower, new BuildData(BuildType.MultiShotTower, 30, 2, 2));
        Builds.Add(BuildType.FocusAttackTower, new BuildData(BuildType.FocusAttackTower, 50, 1, 1));
        Builds.Add(BuildType.IllusionTower, new BuildData(BuildType.IllusionTower, 100, 2, 2));
        Builds.Add(BuildType.Obstacle, new BuildData(BuildType.Obstacle, 80, 2, 2));
        Builds.Add(BuildType.ProtectedBase, new BuildData(BuildType.ProtectedBase, 0, 2, 2));
        Builds.Add(BuildType.LastProtectedBase, new BuildData(BuildType.LastProtectedBase, 0, 2, 2));
    }

    void LoadBuildStatData()
    {
        BuildStat.Add(BuildType.DefaultTower, new BuildStatData(BuildType.DefaultTower, 50f, 50f, 5f, 1f, 10f));
        BuildStat.Add(BuildType.MultiShotTower, new BuildStatData(BuildType.MultiShotTower, 100f, 100f, 5f, 1f, 5f));
        BuildStat.Add(BuildType.FocusAttackTower, new BuildStatData(BuildType.FocusAttackTower, 80f, 80f, 8f, 1.5f, 10f));
        BuildStat.Add(BuildType.IllusionTower, new BuildStatData(BuildType.IllusionTower, Mathf.Infinity, Mathf.Infinity, 0, 0, 0));
        BuildStat.Add(BuildType.Obstacle, new BuildStatData(BuildType.Obstacle, 200f, 200f, 0, 0, 0));
        BuildStat.Add(BuildType.ProtectedBase, new BuildStatData(BuildType.ProtectedBase, 500f, 500f, 0f, 0f, 0f));
        BuildStat.Add(BuildType.LastProtectedBase, new BuildStatData(BuildType.LastProtectedBase, 700f, 700f, 0f, 0f, 0f));
    }

}
