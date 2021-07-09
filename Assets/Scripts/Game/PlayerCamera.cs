using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] Vector3 _offset;
    [SerializeField] GameObject _player;

    void Update()
    {
        Camera.main.transform.position = _player.transform.position + _offset;
        Camera.main.transform.LookAt(_player.transform);
    }
}
