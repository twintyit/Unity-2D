using UnityEngine;

public class SpawerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject pipePrefab;
    [SerializeField]
    private GameObject MobePrefab;
    private float pipeSpawnPeriod = 2.0f;
    private float pipeTimeout;

    void Start()
    {
        pipeTimeout = 0.0f;
    }

    void Update()
    {
        pipeTimeout -= Time.deltaTime;
        if (pipeTimeout <= 0.0f)
        {
            SpawnPipe();
            
            pipeTimeout = pipeSpawnPeriod;
        }
      
    }

    private void SpawnPipe()
    {
        GameObject pipe = GameObject.Instantiate(pipePrefab);
        pipe.transform.position = this.transform.position + 
             Random.Range(-1.5f, 1.5f) * Vector3.up;

        if (Random.Range(1, 20) > 15)
        {
            SpawnMobe(pipe.transform.position);
        }
    }

    private void SpawnMobe(Vector3 position)
    {
        GameObject mobe = GameObject.Instantiate(MobePrefab);
        mobe.transform.position = position +
            Random.Range(0.5f, 3.5f) * Vector3.up;
    }
}
