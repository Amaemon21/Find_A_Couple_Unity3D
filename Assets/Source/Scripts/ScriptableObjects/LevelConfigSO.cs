using UnityEngine;

[CreateAssetMenu(menuName = "Level Config/ new Level Config")]
public class LevelConfigSO : ScriptableObject
{
    [field: SerializeField] public int MaxCountAnimal { get; private set; }
}