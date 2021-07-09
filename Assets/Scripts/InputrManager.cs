using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using InputDataObserver = IObserver<InputObserver.InputData>;
class InputrManager
{
    static public InputrManager Instance => _instance;
    static InputrManager _instance = new InputrManager();
    private InputrManager() { }

    Player _player;
    InputObserver _inputObj = new InputObserver();
    Stack<InputDataObserver> _obsStack = new Stack<InputDataObserver>();
    InputDataObserver _cur = null;

    public void Setup()
    {
        //デフォルト
        _player = GameManager.GetTarget(0).GetComponent<Player>();
        _inputObj.AddObserver(_player);
        _cur = _player;
    }

    public void UpdateInput()
    {
        _inputObj.NotifyObserver(InputObserver.CreateInput("Move"));
        if (Input.GetKeyDown(KeyCode.Z))
        {
            _inputObj.NotifyObserver(InputObserver.CreateInput("Attack"));
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            _inputObj.NotifyObserver(InputObserver.CreateInput("UI"));
        }
    }

    public void Register(InputDataObserver obs)
    {
        _inputObj.DeleteObserver(_cur);
        _obsStack.Push(_cur);
        _inputObj.AddObserver(obs);
        _cur = obs;
    }

    public void Delete(InputDataObserver obs)
    {
        _inputObj.DeleteObserver(obs);
        _cur = _obsStack.Pop();
        _inputObj.AddObserver(_cur);
    }
}
