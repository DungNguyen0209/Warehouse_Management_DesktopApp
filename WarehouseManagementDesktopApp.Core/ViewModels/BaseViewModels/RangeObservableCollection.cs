﻿using System.Collections.Specialized;

namespace WarehouseManagementDesktopApp.Core.ViewModels;

public class RangeObservableCollection<T> : ObservableCollection<T>
{
    private bool _suppressNotification = false;

    protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
    {
        if (!_suppressNotification)
            base.OnCollectionChanged(e);
    }

    public void AddRange(IList<T> list)
    {
        if (list == null)
            throw new ArgumentNullException("list");

        _suppressNotification = true;

        foreach (T item in list)
        {
            Add(item);
        }
        _suppressNotification = false;
        OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
    }
}
