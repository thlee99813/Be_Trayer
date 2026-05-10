using UnityEngine;

[CreateAssetMenu(fileName = "CompanionStatsDefinition", menuName = "Game/Stats/Companion Stats Definition")]
public class CompanionStatsDefinition : CommonStatsDefinition, ICompanionStats
{
    [SerializeField] private int greedy;
    [SerializeField] private int fear;

    public int Greedy => greedy;
    public int Fear => fear;
}
