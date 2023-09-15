using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    [SerializeField] Transform _spawnPoint;

    protected override bool Init()
    {
        if (base.Init() == false)
            return false;

        Managers.Object.SpawnEnemy(Define.EnemyType.MeleeAttackUnit).name = "1";
        Managers.Object.SpawnEnemy(Define.EnemyType.MeleeAttackUnit).name = "2";
        Managers.Object.SpawnEnemy(Define.EnemyType.MeleeAttackUnit).name = "3";
        Managers.Object.SpawnEnemy(Define.EnemyType.MeleeAttackUnit).name = "4";
        Managers.Object.SpawnEnemy(Define.EnemyType.MeleeAttackUnit).name = "5";
        return true;
    }
}
