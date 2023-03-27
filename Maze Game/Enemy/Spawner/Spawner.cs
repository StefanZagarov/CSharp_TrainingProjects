using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _spawnedEnemies;

    [SerializeField] private float _spawnRange;
    [SerializeField] private int _spawnLimit;

    [SerializeField] private float _spawnInterval;
    private float _spawnIntervalEnd;    

    [Space(20)]

    [SerializeField] private List<GameObject> _commonEnemies = new List<GameObject>();
    [SerializeField] private List<GameObject> _rareEnemies = new List<GameObject>();
    [SerializeField] private List<GameObject> _legendaryEnemies = new List<GameObject>();

    [Space(20)]

    [Range(0, 100)][SerializeField] private int _commonEnemySpawnPercentage;
    [Range(0, 100)][SerializeField] private int _rareEnemySpawnPercentage;
    [Range(0, 100)][SerializeField] private int _legendaryEnemySpawnPercentage;
    private int _maxPercentage;
    
    private void Awake()
    {
        _maxPercentage = _commonEnemySpawnPercentage + _rareEnemySpawnPercentage + _legendaryEnemySpawnPercentage;
    }

    private void Update()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {

        if (Time.time > _spawnIntervalEnd && _spawnedEnemies.Count < _spawnLimit)
        {
            Vector3 randomSpawnPos = Random.insideUnitSphere * _spawnRange; //spawns enemies inside the sphere            
            randomSpawnPos += transform.position;
            randomSpawnPos.y = transform.position.y;

            GameObject spawnedEnemy = SpawnRandomEnemy(randomSpawnPos);
            spawnedEnemy.GetComponent<Health>().onDeath += OnEnemyDeathHandler; //subscibing to the onDeath event

            _spawnedEnemies.Add(spawnedEnemy);

            _spawnIntervalEnd = Time.time + _spawnInterval;
        }
    }

    //Spawns a specific list depending on percentage, this list spawns random enemy from it
    private GameObject SpawnRandomEnemy(Vector3 spawnPosition)
    {
        int randomPercentage = Random.Range(0, _maxPercentage);       

        GameObject newEnemy = null;

        if (randomPercentage >= 0 && randomPercentage <= _commonEnemySpawnPercentage)
        {
            newEnemy = Instantiate(_commonEnemies.ElementAt(Random.Range(0, _commonEnemies.Count())), spawnPosition, Quaternion.identity);
        }
        else if (randomPercentage > _commonEnemySpawnPercentage
            && randomPercentage <= _maxPercentage)
        {
            newEnemy = Instantiate(_rareEnemies.ElementAt(Random.Range(0, _rareEnemies.Count())), spawnPosition, Quaternion.identity);
        }
        //to add: third list here
        return newEnemy;
    }

    private void OnEnemyDeathHandler(GameObject enemy) //events must have methods
    {
        _spawnedEnemies.Remove(enemy);
        _spawnIntervalEnd = Time.time + _spawnInterval;
    }

    //private void SniperSpawnLimit()
    //{
    //    if (_sniperSpawnLimit == 0) return;

    //    //  _spawnedEnemies.Count(gameObj => gameObj.tag == "Sniper"): a shorter foreach that counts objects with tag "Sniper"
    //    if (_spawnedEnemies.Count(gameObj => gameObj.tag == "Sniper") == _sniperSpawnLimit)
    //    {

    //    }
    //}
}