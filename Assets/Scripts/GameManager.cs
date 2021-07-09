using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GameManager
{
    static public GameManager Instance => _instance;
    static GameManager _instance = new GameManager();
    private GameManager() {  }

    BattleObject[] _fieldObjects = new BattleObject[2];
    
    static public int Register(BattleObject obj)
    {
        if (obj.CompareTag("Player"))
        {
            _instance._fieldObjects[0] = obj;
            return 0;
        }
        else
        {
            _instance._fieldObjects[1] = obj;
            return 1;
        }
    }

    static public BattleObject GetTarget(int id)
    {
        return _instance._fieldObjects[id];
    }
}

