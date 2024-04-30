using System;
using UnityEngine;

public class Test : MonoBehaviour
{ 
    private void Start()
    {
        /*var width = AstarPath.active.data.gridGraph.width;
        var depth = AstarPath.active.data.gridGraph.depth;
        
        Debug.Log($"Width: {width}");
        Debug.Log($"Depth: {depth}");
        */

        var activeGraph = AstarPath.active.data.gridGraph;
        
        Debug.Log($"Screen Width: {Screen.width}");
        Debug.Log($"Screen Height: {Screen.height}");

        var screenSizeToUnits = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));

        AstarPath.active.data.gridGraph.width = Mathf.RoundToInt(screenSizeToUnits.x) * 2;
        AstarPath.active.data.gridGraph.depth = Mathf.RoundToInt(screenSizeToUnits.y) * 2;
        
        var width = AstarPath.active.data.gridGraph.width;
        var depth = AstarPath.active.data.gridGraph.depth;
        
        AstarPath.active.data.gridGraph.SetDimensions(width, depth, 1);
        
        AstarPath.active.data.gridGraph.Scan();
        
        Debug.Log($"Width: {width}");
        Debug.Log($"Depth: {depth}");

        Debug.Log($"Result: {screenSizeToUnits}");
    }
}
