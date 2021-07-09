using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BattleObject
{
    [SerializeField] float _attackTimer = 5;
    [SerializeField] float _power = 50;
    [SerializeField] GameObject _atkObj;

    float _ct = 0;
    public float AttackTimer { get { return (_ct / _attackTimer); } }

    protected override void Setup()
    {
        base.Setup();

        GameManager.Register(this);
    }

    private void Update()
    {
        _ct += Time.deltaTime;
        if(_ct > _attackTimer)
        {
            Attack();
            _ct -= _attackTimer;
        }
    }

    void Attack()
    {
        for(int i=0; i<_power; ++i)
        {
            GameObject.Instantiate(_atkObj, new Vector3(Random.Range(-40, 40), 100, Random.Range(-40, 40)), Quaternion.identity);
        }
    }
}
