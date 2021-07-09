using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

using InputDataObserver = IObserver<InputObserver.InputData>;
public class UIPane : MonoBehaviour, InputDataObserver
{
    [SerializeField] bool InitVisibility = true;
    protected CanvasRenderer Renderer;
    protected CanvasGroup Group;
    public RectTransform RectTransform { get; protected set; }

    private void Awake()
    {
        RectTransform = GetComponent<RectTransform>();
        Renderer = GetComponent<CanvasRenderer>();
        Group = GetComponent<CanvasGroup>();
        if (!InitVisibility)
        {
            Group.alpha = 0;
        }
        Setup();
    }

    protected virtual void Setup()
    {

    }

    public virtual void NotifyUpdate(InputObserver.InputData t)
    {

    }

    public virtual void Open()
    {
        Group.alpha = 1;
        GameUI.SetCurrent(this);
    }

    public virtual void Close()
    {
        Group.alpha = 0;
        GameUI.Back(this);
    }
}
