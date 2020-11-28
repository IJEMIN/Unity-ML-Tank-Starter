using System.Text;
using Unity.MLAgents;
using UnityEngine;
using UnityEngine.UI;

public class InfoUI : MonoBehaviour
{
    private Agent[] _agents;

    public Text text;

    private void Start()
    {
        _agents = FindObjectsOfType<Agent>();
    }

    private void Update()
    {
        
    }
}