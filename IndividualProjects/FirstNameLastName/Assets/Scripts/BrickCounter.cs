using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickCounter : MonoBehaviour {
    private int _brickCount;

    public void CountBrick() {
        _brickCount++;
        Debug.Log($"Total Bricks Removed: {_brickCount}");
    }
}
