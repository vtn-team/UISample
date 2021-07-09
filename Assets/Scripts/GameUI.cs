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

    List<UIPane> _uiList = new List<UIPane>();

    UIPane _nextUI = null;
    UIPane _backUI = null;

    public void Setup()
    {
        CanvasRoot = GameObject.Find("/UI")?.GetComponent<Canvas>();
        _uiList = CanvasRoot.GetComponentsInChildren<UIPane>().ToList();
    }

    public void UpdateUI()
    {
        if(_nextUI)
        {
            if (_currentPane != null)
            {
                _viewStack.Push(_currentPane);
            }
            _currentPane = _nextUI;
            InputrManager.Instance.Register(_currentPane);
        }

        if(_backUI && _backUI == _currentPane)
        {
            InputrManager.Instance.Delete(_currentPane);
            _currentPane = null;
            if (_viewStack.Count > 0)
            {
                _currentPane = _viewStack.Pop();
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