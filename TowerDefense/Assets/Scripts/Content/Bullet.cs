using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Define.BuildType _type;
    Transform _lockTarget;
    float _speed = 10f;
    float _attack;
    float _maxDistance = 3f;

    public void Init(Define.BuildType type, Transform lockTarget)
    {
        _type = type;
        _lockTarget = lockTarget;
        _attack = Managers.Data.BuildStat[type].attack;
    }

    private void Update()
    {
        Vector3 dir = _lockTarget.position - transform.position;
        transform.position += dir.normalized * _speed * Time.deltaTime;
        transform.LookAt(_lockTarget);

        if(dir.magnitude <= 0.2f)
        {
            OnAttacked();
        }
    }

    void OnAttacked()
    {
        if(_type == Define.BuildType.FocusAttackTower)
        {
            if(Managers.Object.MonsterList.Count > 0)
            {
                foreach (EnemyController mc in Managers.Object.MonsterList)
                {
                    float distance = (mc.transform.position - transform.position).magnitude;

                    if(distance <= _maxDistance)
                    {
                        mc.OnDamaged(_attack);
                    }
                }

                Managers.Resource.Destory(gameObject);
            }

            return;
        }

        _lockTarget.GetComponent<EnemyController>().OnDamaged(_attack);
        Managers.Resource.Destory(gameObject);
    }
}
