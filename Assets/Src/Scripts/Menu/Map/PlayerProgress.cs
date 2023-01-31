using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class PlayerProgress
{
    private const int MaxFarmLevelInDay = 3;

    private int _completedLevels;
    private DateTime _lastGamedDay;
    private Dictionary<int, int> _levelCompletedInDay;

    public PlayerProgress()
    {
        _lastGamedDay = DateTime.Now;
        _levelCompletedInDay = new Dictionary<int, int>();
    }

    public bool HasRewardFor(int level)
    {
        return _levelCompletedInDay.Keys.Contains(level) == false || _levelCompletedInDay[level] < MaxFarmLevelInDay;
    }

    public void PlayedLevel(int idLevel)
    {
        if (_levelCompletedInDay.Keys.Contains(idLevel))
        {
            _levelCompletedInDay[idLevel]++;
        }
        else
        {
            _levelCompletedInDay.Add(idLevel, 1);
        }

        AddProgress(idLevel);
        VisitGame();
    }

    public void VisitGame()
    {
        if ((DateTime.Now - _lastGamedDay.Date).Days >= 1)
        {
            _lastGamedDay = DateTime.Now;
            _levelCompletedInDay.Clear();
        }
    }

    private void AddProgress(int completedLevel)
    {
        if (_completedLevels < completedLevel)
        {
            _completedLevels = completedLevel;
        }
    }
}
