using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class TankAgent : Agent
{
    private TankInput _tankInput;

    private TankHealth _tankHealth;
    private TankMovement _tankMovement;
    private TankShooting _tankShooting;

    private SpawnPointProvider[] _spawnPointProviders;

    private float _horizontalInputVelocity;
    private float _verticalInputVelocity;

    private void Awake()
    {
        _tankInput = GetComponent<TankInput>();
        _tankHealth = GetComponent<TankHealth>();
        _tankShooting = GetComponent<TankShooting>();
        _tankMovement = GetComponent<TankMovement>();

        _spawnPointProviders = FindObjectsOfType<SpawnPointProvider>();

        _tankHealth.OnTankDead += OnTankDead;
        _tankShooting.OnHitTargets += OnHitTargets;
    }

    public override void Heuristic(float[] actionsOut)
    {

    }

    private void OnHitTargets(TankHitInfo[] tankHitInfos)
    {
       
    }

    private void SetActiveTankComponents(bool active)
    {
        _tankHealth.enabled = active;
        _tankMovement.enabled = active;
        _tankShooting.enabled = active;
    }

    public override void OnActionReceived(float[] vectorAction)
    {

    }

    private void OnTankDead()
    {
        
    }

    private void FixedUpdate()
    {
        if (!_tankHealth.IsDead && _tankMovement.Fuel <= 0f)
        {
            _tankHealth.Death();
        }
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        
    }

    public override void OnEpisodeBegin()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (_tankHealth.IsDead)
        {
            return;
        }

        var item = other.GetComponent<Item>();
        if (item != null)
        {
            item.Use(gameObject);
        }
    }
}