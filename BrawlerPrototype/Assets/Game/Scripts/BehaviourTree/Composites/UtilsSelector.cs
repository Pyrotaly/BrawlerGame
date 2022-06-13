using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;
using System.Linq;

public class UtilsSelector : CompositeNode
{
    private List<Node> UtilList = new List<Node>();
    protected int current;
    protected int newCurrent;
    protected override void OnStart()
    {
        current = 0;
    }

    protected override void OnStop() 
    {
    }

    protected override State OnUpdate()
    {
        for (int i = current; i < children.Count; ++i)
        {
            current = i;
            var child = children[current];

            //Calls calculate Utils function in all children and organizes it from highest utils to lowest utils
            child.CalculateUtils();
            UtilList.Add(child);
            UtilList = UtilList.OrderByDescending(u => u.TestInt).ToList();  //LINQ explanation https://youtu.be/yClSNQdVD7g?t=460       
        }

        //Running the highest util node

        for (int i = newCurrent; i < UtilList.Count; ++i)
        {
            newCurrent = i;
            var child = UtilList[newCurrent];

            if (UtilList[0].TestInt == 0)
            {
                return State.Failure;
            }

            switch (child.Update())
            {
                case State.Running:
                    return State.Running;
                case State.Success:
                    return State.Success;
                case State.Failure:
                    continue;
            }
        }

        return State.Failure;
    }
}
