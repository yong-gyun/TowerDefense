using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Data
{
    public class BuildData
    {
        public Define.BuildType type;
        public int cost;
        public int width;
        public int height;
        public int size;

        public BuildData(Define.BuildType type, int cost, int width, int height)
        {
            this.type = type;
            this.cost = cost;
            this.width = width;
            this.height = height;
            size = width * height;
        }
    }

    public struct EnemyStatData
    {
        public Define.EnemyType type;
        public float maxHp;
        public float hp;
        public float attack;
        public float attackSpeed;
        public float moveSpeed;
        public int gold;

        public EnemyStatData(Define.EnemyType type, float maxHp, float hp, float attack, float attackSpeed, float moveSpeed, int gold)
        {
            this.type = type;
            this.maxHp = maxHp;
            this.hp = hp;
            this.attack = attack;
            this.attackSpeed = attackSpeed;
            this.moveSpeed = moveSpeed;
            this.gold = gold;
        }
    }

    public struct BuildStatData
    {
        public Define.BuildType type;
        public float maxHp;
        public float hp;
        public float attack;
        public float attackSpeed;
        public float attackDistance;

        public BuildStatData(Define.BuildType type, float maxHp, float hp, float attack, float attackSpeed, float attackDistance)
        {
            this.type = type;
            this.maxHp = maxHp;
            this.hp = hp;
            this.attack = attack;
            this.attackSpeed = attackSpeed;
            this.attackDistance = attackDistance;
        }
    }
}
