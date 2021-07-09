using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using InputDataObserver = IObserver<InputObserver.InputData>;
public class Player : BattleObject, InputDataObserver
{
    private CCMove _moveScript;

    protected override void Setup()
    {
        base.Setup();

        GameManager.Register(this);
        _moveScript = GetComponent<CCMove>();
    }

    public void NotifyUpdate(InputObserver.InputData t)
    {
        if (t.Type == InputObserver.InputType.Move) _moveScript.Move();
        if (t.Type == InputObserver.InputType.Attack)
        {
            BattleObject obj = GameManager.GetTarget(1);
            if ((obj.transform.position - this.transform.position).magnitude < 40)
            {
                obj.Damage(1);
            }
        }
        if (t.Type == InputObserver.InputType.UI)
        {
            GameUI.Open(0);
        }
    }
}
