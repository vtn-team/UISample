using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class EnemyAttackObject : MonoBehaviour
{
    [SerializeField] int _damage = 10;
    [SerializeField] float _lifetime = 15.0f;
    float _timer = 0;
    bool _isGround = false;

    private void Update()
    {
        if(_isGround)
        {
            _timer += Time.deltaTime;
            if (_timer > _lifetime) Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.GetTarget(0).Damage(_damage);
            Destroy(this.gameObject);
        }
        else
        {
            _isGround = true;
        }
    }
}
