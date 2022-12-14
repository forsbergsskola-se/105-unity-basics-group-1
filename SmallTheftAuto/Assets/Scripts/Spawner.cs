using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Path pedestrian;
    public Path car;
    public int maxPedestrians;
    public int maxCars;
    private int _numPedestrians;
    private int _numCars;

    private void Start()
    {
        _numPedestrians = FindObjectsOfType<Pedestrian>().Length;
        _numCars = FindObjectsOfType<Vehicle>().Length;
        InvokeRepeating("SpawnPrefab", 1f, 5f);
    }
    
    void SpawnPrefab()
    {
        if (_numPedestrians < maxPedestrians) Instantiate(pedestrian);
        if (_numCars < maxCars) Instantiate(car);
        _numPedestrians = FindObjectsOfType<Pedestrian>().Length;
        _numCars = FindObjectsOfType<Vehicle>().Length;
    }
    
}
