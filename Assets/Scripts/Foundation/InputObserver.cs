using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InputDataObservable = IObservable<InputObserver.InputData>;
using InputDataObserver = IObserver<InputObserver.InputData>;

public class InputObserver : InputDataObservable
{ 
    public enum InputType
    {
        Move,
        Attack,
        UI
    }
    public class InputData
    {
        public InputType Type;
    }

    static InputData[] StableInputData =
    {
        new InputData(){ Type = InputType.Move },
        new InputData(){ Type = InputType.Attack },
        new InputData(){ Type = InputType.UI }
    };

    List<InputDataObserver> Subscriber = new List<InputDataObserver>();

    public void AddObserver(InputDataObserver target)
    {
        Subscriber.Add(target);
    }

    public void DeleteObserver(InputDataObserver target)
    {
        Subscriber.Remove(target);
    }

    public void NotifyObserver(InputData data)
    {
        Subscriber.ForEach(s => s.NotifyUpdate(data));
    }

    static public InputData CreateInput(string label)
    {
        switch(label)
        {
            case "Move": return StableInputData[(int)InputType.Move];
            case "Attack": return StableInputData[(int)InputType.Attack];
            case "UI": return StableInputData[(int)InputType.UI];
            default: return null;
        }
    }
}

