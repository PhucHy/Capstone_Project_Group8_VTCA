using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;

public class BattleTeamData
{
    public string TeamName;
    public List<ITurnParticipant> Members = new List<ITurnParticipant>();

    public bool IsDefeated => Members.All(m => !m.IsAlive);

    public BattleTeamData(string name)
    {
        TeamName = name;
    }

    public void AddMember(ITurnParticipant participant)
    {
        Members.Add(participant);
    }

    public ITurnParticipant GetRandomAliveMember()
    {
        var alive = Members.Where(m => m.IsAlive).ToList();
        // không nên dùng random vì là game turn base không thể ngẫu nhiên lượt
        return alive.Count > 0 ? alive[UnityEngine.Random.Range(0, alive.Count)] : null;
    }
}
