using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using neo_culc_for_xamarin.Services;
using neo_culc_for_xamarin.Models;

namespace neo_culc_for_xamarin.ViewModels
{
    /// <summary>
    /// VMで必須の変更通知の実装。 新しくVMを作るときはこのclassを継承すること。
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        string subTitle = string.Empty;
        public string SubTitle
        {
            get { return subTitle; }
            set { SetProperty(ref subTitle, value); }
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        protected bool SetProperty<T>(ref T backingStore, T value,
        [CallerMemberName] string propertyName = "",
        Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
