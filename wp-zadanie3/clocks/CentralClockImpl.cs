using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wp_zadanie3.interfaces;

namespace wp_zadanie3.clocks
{
    public class CentralClockImpl : IClock
    {
        private readonly List<IScreen> _screens;
        private readonly int _interval = 60000;
        private int _timestamp, _clockTaskId;
        private volatile bool _working;
        private Task _clockTask;

        public CentralClockImpl()
        {
            _screens = new List<IScreen>();
        }

        public CentralClockImpl(int interval)
        {
            _interval = interval;
            _screens = new List<IScreen>();
        }

        public void NotifyObservers()
        {
            var currentTime = GetFormattedTime();
            foreach (var screen in _screens) {
                screen.UpdateTime(currentTime);
            }
        }

        public void Subscribe(IScreen screen)
        {
            _screens.Add(screen);
        }

        public void Unsubscribe(IScreen screen)
        {
            try {
                var index = _screens.IndexOf(screen);
                _screens.RemoveAt(index);
            }
            catch (Exception) {
                Console.WriteLine("Cannot remove screen.");
            }
        }

        public void Start()
        {
            if (_working) return;
            _timestamp = GetCurrentTimeStamp();
            _working = true;
            _clockTask = Task.Run(() => TimeLoop(++_clockTaskId));
        }

        public void Stop()
        {
            _working = false;
        }

        private void TimeLoop(int taskId)
        {
            while (_working && taskId == _clockTaskId) {
                NotifyObservers();
                _timestamp += _interval / 1000;
                _clockTask.Wait(_interval);
            }
        }

        /**
         * Returns IScreen type object or null.
         */
        public bool AddOrRemoveSubscriber(IScreen screen)
        {
            var oldScreen = HasSubscriber(screen);
            if (oldScreen != null) {
                Unsubscribe(oldScreen);
                return false;
            }

            Subscribe(screen);
            return true;
        }

        private IScreen HasSubscriber(IScreen screen)
        {
            try {
                if (_screens.Count - 1 < 0) throw new ArgumentNullException();
                return _screens.Last(s => s.Name == screen.Name);
            }
            catch (Exception) {
                return null;
            }
        }

        private int GetCurrentTimeStamp()
        {
            return (int) DateTime.Now.Subtract(
                new DateTime(1970, 1, 1, 0, 0, 0, 0)
            ).TotalSeconds;
        }

        private string GetFormattedTime()
        {
            var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return dtDateTime.AddSeconds(_timestamp).ToString("HH:mm");
        }
    }
}