using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using wp_zadanie3.interfaces;
using wp_zadanie3.screens;

namespace wp_zadanie3.clocks
{
    public class CentralClockImpl : IClock
    {
        private readonly List<IScreen> _screens;
        private readonly int _interval = 60000;
        private int _timestamp;
        private volatile bool _working;

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
                var index = _screens.IndexOf(_screens.Last(s => s.Name == screen.Name));
                _screens.RemoveAt(index);
            }
            catch (Exception e) {
                Console.WriteLine("Cannot remove screen. Sorry.");
            }
        }

        private bool HasSubscriber(IScreen screen)
        {
            try {
                if (_screens.Count - 1 < 0) throw new ArgumentNullException();
                var index = _screens.IndexOf(_screens.Last(s => s.Name == screen.Name));
                return index < _screens.Count;
            }
            catch (Exception) {
                return false;
            }
        }

        /**
         * Returns true when a Subscriber was added or false when it was removed.
         */
        public bool AddOrRemoveSubscriber(IScreen screen)
        {
            if (HasSubscriber(screen)) {
                Unsubscribe(screen);
                return false;
            }

            Subscribe(screen);
            return true;
        }

        public void Start()
        {
            if (_working) return;
            _timestamp = GetCurrentTimeStamp();
            _working = true;
            var thread = new ThreadStart(TimeLoop);
            var backgroundThread = new Thread(thread);
            backgroundThread.Start();
        }

        public void Stop()
        {
            _working = false;
        }

        private void TimeLoop()
        {
            while (_working) {
                Thread.Sleep(_interval);
                _timestamp += _interval / 1000;
                if (_working) {
                    NotifyObservers();
                }
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