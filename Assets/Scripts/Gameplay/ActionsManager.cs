using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsManager : MonoBehaviour
{
    [SerializeField] private List<Action> actionsLs;
    private Dictionary<int, Action> actions;
    private int index;
    private int maxIndex;

    void Awake() 
    { 
        index = 0;
        actions = new Dictionary<int, Action>();
        foreach (Action e in actionsLs) 
        {
            actions.Add(index, e);
            index++;
        }
        index = 0;
        maxIndex = actionsLs.Count-1;
    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            this.GetNextAction();
        }
    }

    public Action GetAction(int n) 
    {
        return actions[n];
    }

    public Action GetNextAction()
    {
        var res = actions[index];

        index++;
        if (index > maxIndex)
        {
            index = 0;
        }
        Debug.Log(index+" "+res);
        return res;
    }
}
