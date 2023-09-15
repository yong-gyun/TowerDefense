using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public enum SceneType
    {
        Title,
        Game,
    }

    public enum TowerState
    {
        Find,
        Attack,
        Die
    }

    public enum EnemyState
    {
        Idle,
        Move,
        Attack,
        Die
    }

    public enum BuildType
    {
        Unknow,
        DefaultTower,
        MultiShotTower,
        FocusAttackTower,
        IllusionTower,
        Obstacle,
        ProtectedBase,
        LastProtectedBase
    }

    public enum EnemyType
    {
        MeleeAttackUnit,
        RangedAttackUnit,
        QuickUnit,
        FlyUnit,
        GoldUnit,
        MiddleBossUnit,
        StageBossUnit
    }
}
