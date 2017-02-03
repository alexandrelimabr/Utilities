using System;
using System.Diagnostics;
using System.Threading;

public class ThrottleHelper
{
    private int _maxLaps;
    private Stopwatch _sw;
    private int _actualLaps;
    private ManualResetEvent _evtTimer = new ManualResetEvent(false);

    public ThrottleHelper(int maxLaps)
    {
        _maxLaps = maxLaps;
        _sw = Stopwatch.StartNew();
        _evtTimer.Reset();
        _actualLaps = 0;
    }

    public long ActualLaps { get { return _actualLaps; } }
    public long ActualMili { get { return _sw.ElapsedMilliseconds; } }
    public long MaxLaps { get { return _maxLaps; } }

    public long Restart()
    {
        _evtTimer.Set();
        _actualLaps = 0;
        _evtTimer.Reset();
        _sw.Restart();
        return _sw.ElapsedMilliseconds;
    }

    public long VerifyLaps()
    {
        long elapsed = 0;

        ++_actualLaps;

        if (_actualLaps >= _maxLaps || _sw.ElapsedMilliseconds >= 1000)
        {
            elapsed = _sw.ElapsedMilliseconds;

            if (_sw.ElapsedMilliseconds < 1000)
            {
                _evtTimer.WaitOne((int)(1000 - _sw.ElapsedMilliseconds));
            }

            Restart();
        }

        return elapsed;
    }
}
