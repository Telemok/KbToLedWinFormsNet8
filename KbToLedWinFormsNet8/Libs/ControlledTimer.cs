//using System;
//using System.Timers;

namespace KbToLedWinFormsNet8.Libs
{


	public class ControlledTimer
	{
		private System.Timers.Timer _timer;
		private DateTime _lastTriggeredTime;
		private Action _callback;

		public event EventHandler? Triggered;

		public bool Enabled
		{
			get => _timer.Enabled;
			set => _timer.Enabled = value;
		}

		public TimeSpan TimeoutMax { get; set; } = TimeSpan.FromSeconds(1);
		public TimeSpan TimeoutMin { get; set; } = TimeSpan.FromMilliseconds(200);

		public DateTime TimestampПоследнегоСрабатывания => _lastTriggeredTime;

		public ControlledTimer()
		{
			_lastTriggeredTime = DateTime.MinValue;
			_timer = new (TimeoutMax.TotalMilliseconds);
			_timer.Elapsed += (s, e) => TryTrigger();
		}

		public ControlledTimer(Action callback) : this()
		{
			_callback = callback;
		}

		public void SetCallback(Action callback)
		{
			_callback = callback;
		}

		public void TriggerNow()
		{
			var timeSinceLastTrigger = DateTime.Now - _lastTriggeredTime;

			if (timeSinceLastTrigger >= TimeoutMin)
			{
				Trigger();
			}
			else
			{
				// Запланировать срабатывание через оставшееся время до TimeoutMin
				var delay = TimeoutMin - timeSinceLastTrigger;
				_timer.Interval = delay.TotalMilliseconds;
				_timer.Start();
			}
		}

		private void TryTrigger()
		{
			var timeSinceLastTrigger = DateTime.Now - _lastTriggeredTime;

			if (timeSinceLastTrigger >= TimeoutMax)
			{
				Trigger();
			}
		}

		private void Trigger()
		{
			_lastTriggeredTime = DateTime.Now;
			Triggered?.Invoke(this, EventArgs.Empty);
			_callback?.Invoke();

			// Перезапуск таймера на TimeoutMax
			if (Enabled)
			{
				_timer.Interval = TimeoutMax.TotalMilliseconds;
				_timer.Start();
			}
		}
	}

}
