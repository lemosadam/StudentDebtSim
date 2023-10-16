using System;
using System.Collections.Generic;

public class EventManager
{
    private Dictionary<string, Action<float>> coinCollectListeners = new Dictionary<string, Action<float>>();

    public void AddCoinCollectListener(string listenerName, Action<float> listener)
    {
        coinCollectListeners.Add(listenerName, listener);
    }

    public void RemoveCoinCollectListener(string listenerName)
    {
        coinCollectListeners.Remove(listenerName);
    }

    public void CoinCollected(float shrinkAmount)
    {
        foreach (var listener in coinCollectListeners)
        {
            listener.Value(shrinkAmount);
        }
    }
}
