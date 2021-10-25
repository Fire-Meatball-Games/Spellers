using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BattleSettings
{
    protected int teams, playersPerTeam;

    public BattleSettings(int teams, int playersPerTeam)
    {
        this.teams = teams;
        this.playersPerTeam = playersPerTeam;
    }
}

public class SinglePlayerBattleSettings : BattleSettings
{
    public SinglePlayerBattleSettings(int teams, int playersPerTeam) : base(teams, playersPerTeam) { }
}

public class MultiPlayerBattleSettings : BattleSettings
{
    public MultiPlayerBattleSettings(int teams, int playersPerTeam) : base(teams, playersPerTeam) { }
}

public class HistoryModebattleSettings : SinglePlayerBattleSettings
{
    public HistoryModebattleSettings(int teams, int playersPerTeam) : base(teams, playersPerTeam) { }
}
