using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] int _targetId;
    [SerializeField] Image _image;

    int _currentHP;

    int _maxHitPoint;
    int _oldHitPoint;
    bool _isAnimate;
    float _timer;

    private void Start()
    {
        _currentHP = _maxHitPoint = GameManager.GetTarget(_targetId).MaxHitPoint;
        _oldHitPoint = _currentHP;
    }

    private void Update()
    {
        if(_currentHP != GameManager.GetTarget(_targetId).HitPoint)
        {
            _isAnimate = true;
            _timer = 0;
            _oldHitPoint = _currentHP;
            _currentHP = GameManager.GetTarget(_targetId).HitPoint;
        }

        if (_isAnimate) { 
            _timer += Time.deltaTime;
            _image.fillAmount = Mathf.Lerp((float)_oldHitPoint / (float)_maxHitPoint, (float)_currentHP / (float)_maxHitPoint, _timer);
            if (_timer > 1.0f)
            {
                _isAnimate = false;
            }
        }
        else
        {
            _image.fillAmount = (float)_currentHP / (float)_maxHitPoint;
        }
    }
}
