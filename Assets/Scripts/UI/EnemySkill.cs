using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySkill : MonoBehaviour
{
    [SerializeField]Image _image;
    Enemy _target;

    void Start()
    {
        _target = GameManager.GetTarget(1).GetComponent<Enemy>();
    }

    void Update()
    {
        _image.fillAmount = _target.AttackTimer;
    }
}
