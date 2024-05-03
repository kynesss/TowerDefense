using UnityEngine;
using Zenject;

namespace TowerDefense.Scripts.Utils
{
    public class AstarGridScaler : IInitializable
    {
        public void Initialize()
        {
            var screenSizeToUnits = Camera.main!.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));
            var activeGraph = AstarPath.active.data.gridGraph;

            activeGraph.width = Mathf.RoundToInt(screenSizeToUnits.x) * 2;
            activeGraph.depth = Mathf.RoundToInt(screenSizeToUnits.y) * 2;
        
            var width = activeGraph.width;
            var depth = activeGraph.depth;
        
            AstarPath.active.data.gridGraph.SetDimensions(width, depth, 1);
            AstarPath.active.data.gridGraph.Scan();
        }
    }
}
