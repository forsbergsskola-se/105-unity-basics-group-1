using UnityEngine;

public class BrickCounter : MonoBehaviour
{ 
    int _brickCount;

    public void CountBrick() 
    {
        _brickCount++;
        Debug.Log($"Total Bricks Removed: {_brickCount}");
    }
}
