using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleObject : MonoBehaviour
{
    int _targetId;
    [SerializeField] int _hitPoint = 100;
    int _maxHitPoint = 100;
    public int HitPoint => _hitPoint;
    public int MaxHitPoint => _maxHitPoint;

    private void Awake()
    {
        _maxHitPoint = _hitPoint;
        Setup();
    }

    protected virtual void Setup()
    {

    }

    public void Damage(int dmg)
    {
        Debug.Log(this.name + "/dmg:" + dmg);
        _hitPoint -= dmg;
    }
}
