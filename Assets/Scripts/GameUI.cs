using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GameUI
{
    static public GameUI Instance => _instance;
    static GameUI _instance = new GameUI();
    private GameUI() { }

    Canvas CanvasRoot = null;
    HPBar _playerHPBar = null;
    HPBar _enemyHPBar = null;

    Stack<UIPane> _viewStack = new Stack<UIPane>();
    UIPane _currentPane = null;
    Player _player;
    InputObserver _inputObj = new InputObserver();

    List<UIPane> _uiList = new List<UIPane>();

    UIPane _nextUI = null;
    UIPane _backUI = null;

    public void Setup()
    {
        CanvasRoot = GameObject.Find("/UI")?.GetComponent<Canvas>();
        _player = GameManager.GetTarget(0).GetComponent<Player>();
        _uiList = CanvasRoot.GetComponentsInChildren<UIPane>().ToList();
        _inputObj.AddObserver(_player);
    }

    public void Update()
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

        if(_nextUI)
        {
            _inputObj.DeleteObserver(_player);
            if (_currentPane != null)
            {
                _inputObj.DeleteObserver(_currentPane);
                _viewStack.Push(_currentPane);
            }
            _currentPane = _nextUI;
            _inputObj.AddObserver(_currentPane);
        }

        if(_backUI && _backUI == _currentPane)
        {
            _inputObj.DeleteObserver(_currentPane);
            _currentPane = null;
            if (_viewStack.Count > 0)
            {
                _currentPane = _viewStack.Pop();
                _inputObj.AddObserver(_currentPane);
            }
            else
            {
                _inputObj.AddObserver(_player);
            }
        }
        _nextUI = null;
        _backUI = null;
    }

    static public void Open(int id)
    {
        _instance._uiList[id].Open();
    }

    static public void SetCurrent(UIPane c)
    {
        _instance._nextUI = c;
    }
    
    static public void Back(UIPane c)
    {
        _instance._backUI = c;
    }
}