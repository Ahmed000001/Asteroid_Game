using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidManger : MonoBehaviour
{
    public static AsteroidManger Insatnce;
    [SerializeField] private List<Asteroid> asteroidPrefabs;
   
    [SerializeField] private int maximumInitAsteroidNum=10;
    [SerializeField] private GameObject[] SpawnLoactions;
    private float minX, maxX, minZ, maxZ;
    private List<Asteroid> spwandAsteroids;
    private void Awake()
    {
        if (Insatnce == null)
        {
            Insatnce = this;
        }
        spwandAsteroids = new List<Asteroid>();
    }

    void Start()
    {
      

        GetBoundaries();
        BoundariesManger.Instance.OnScreenResolutionChanged += GetBoundaries;
    }

    void GetBoundaries()
    {
        maxX = BoundariesManger.Instance.LeftBottom.x;
        minX = BoundariesManger.Instance.RightUp.x;

        maxZ = BoundariesManger.Instance.LeftBottom.z;
        minZ = BoundariesManger.Instance.RightUp.z;
    }

    public void SpawnAsteroids()
    {
       
        for (int i = 0; i < maximumInitAsteroidNum; i++)
        {
            var ranIndex = Random.Range(0, asteroidPrefabs.Count);
           

            var ranLoc = Random.Range(0, SpawnLoactions.Length);


            var asteroid = Instantiate(asteroidPrefabs[ranIndex], SpawnLoactions[ranLoc].transform);
            spwandAsteroids.Add(asteroid);

        }
    }

    public void OnAsteriodDead(AsteroidType asteroidtype,Transform damgedTransform)
    {

        switch (asteroidtype)
        {
            case AsteroidType.Big:
                return;
              
            case AsteroidType.Medium:
                for (int i = 0; i < 2; i++)
                {
                   var ast= Instantiate(asteroidPrefabs[0]);
                   ast.transform.position = damgedTransform.position;
                     spwandAsteroids.Add(ast);
                }
                break;
            case AsteroidType.Small:
                for (int i = 0; i < 2; i++)
                {
                  var ast= Instantiate(asteroidPrefabs[1]);
                    ast.transform.position = damgedTransform.position;
                    spwandAsteroids.Add(ast);
                }
                break;
           
        }
    }

    public void CleanAsteroids()
    {
        foreach (var asteroid in spwandAsteroids)
        {
          Destroy(asteroid);  
        }

        spwandAsteroids.Clear();
    }
    void Update()
    {
        
    }
}
