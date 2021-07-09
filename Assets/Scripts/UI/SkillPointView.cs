using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillPointView : UIPane
{
    [SerializeField] Text _skillPoint;

    protected override void Setup()
    {
        base.Setup();


    }

    public override void NotifyUpdate(InputObserver.InputData t)
    {
        if(t.Type == InputObserver.InputType.UI)
        {
            Close();
        }
    }
}
