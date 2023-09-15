using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Define.EnemyType Type { get; set; }
    public float MaxHp { get { return _maxHp; } set { _maxHp = value; } }
    public float Hp { get { return _hp; } set { _hp = value; } }
    public float Attack { get { return _attack; } set { _attack = value; } }
    public float MoveSpeed { get { return _moveSpeed; } set { _moveSpeed = value; } }
    public float AttackSpeed { get { return _attackSpeed; } set { _attackSpeed = value; } }
    public float Gold { get { return _gold; } set { _gold = value; } }

    [SerializeField] protected float _maxHp;
    [SerializeField] protected float _hp;
    [SerializeField] protected float _attack;
    [SerializeField] protected float _attackSpeed;
    [SerializeField] protected float _moveSpeed;
    [SerializeField] protected float _gold;
    protected NavMeshAgent _agent;
    
    [SerializeField] protected Define.EnemyState _state;

    bool _init;

    protected virtual bool Init()
    {
        if (_init)
            return false;

        _agent = GetComponent<NavMeshAgent>();
        _agent.isStopped = true;
        _agent.autoRepath = false;

        float distance = Mathf.Infinity;

        for (int i = 0; i < Managers.Object.ProtectedBase.Count; i++)
        {
            _agent.SetDestination(Managers.Object.ProtectedBase[i].transform.position);

            if (_agent.remainingDistance <= distance)
                distance = _agent.remainingDistance;
        }

        _agent.isStopped = false;
        _init = true;
        return true;
    }

    protected virtual void Update()
    {

    }

    protected virtual void UpdateMove()
    {

    }

    public void OnDamaged(float damage)
    {
        if (Hp <= 0)
            return;

        Hp -= damage;

        if(Hp <= 0)
        {
            Hp = 0f;
            OnDie();
        }
    }

    protected virtual void OnDie()
    {
        Managers.Object.DespawnEnemy(this);
    }

    public void SetStat()
    {
        
    }
}
