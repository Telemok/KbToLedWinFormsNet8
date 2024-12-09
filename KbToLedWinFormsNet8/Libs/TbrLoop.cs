

namespace KbToLedWinFormsNet8.Libs
{
	public class TbrLoop
	{
		private Func<Task>? _userFunc;
		private Action? _userAction;
		public DateTime TimestampLastStarted { get; protected set; } = DateTime.MinValue;
		public DateTime TimestampLastStopped { get; protected set; } = DateTime.MinValue;

		private object _locker = new();

		private Task? _taskRunning;

		private CancellationTokenSource? _cancellationToken;
		public CancellationToken? CancellationToken;

		public long CounterLoopsThisOrder = 0;

		public long CounterLoopsSumm = 0;

		public TimeSpan TimeoutLoop = TimeSpan.FromSeconds(1);

		//public event System.EventHandler? EventChange;
		public event Action? EventChange;
		public TbrLoop(Func<Task> userFunc)
		{
			_userFunc = userFunc ?? throw new ArgumentNullException(nameof(userFunc));
		}

		public TbrLoop(Action userAction)
		{
			_userAction = userAction ?? throw new ArgumentNullException(nameof(userAction));
		}



		private bool _orderEnabled = false;
		/// <summary>
		/// Приказ определяющий надо ли крутиться сервису который сохраняет на сервер список открытых документов.
		/// </summary>
		public bool OrderEnabled
		{
			get
			{
				lock (this._locker)
				{
					return _orderEnabled;
				}
			}
			set
			{
				lock (this._locker)
				{
					bool oldOrder = _orderEnabled;
					_orderEnabled = value;
					if (_orderEnabled != oldOrder)
					{
						//Console.WriteLine($"OrderEnabled change to «{_orderEnabled}»");
						if (_orderEnabled == true)
						{
							CounterLoopsThisOrder = 0;
							this.TimestampLastStarted = DateTime.Now;
							_cancellationToken = new();
							CancellationToken = _cancellationToken.Token;
							_taskRunning = Task.Run(async () =>
							{
								while (_orderEnabled)
								{
									if (_cancellationToken?.IsCancellationRequested ?? true)
										return;
									try
									{
										if (this._userFunc is not null)
											await this._userFunc();
										if (this._userAction is not null)
											this._userAction();
									}
									catch (Exception ex)
									{
										Console.WriteLine($"Error CheckingVersionOnServer.OrderEnabled true: «{ex}»!");
									}
									CounterLoopsThisOrder++;
									CounterLoopsSumm++;
									if (_cancellationToken is not null)
										await Task.Delay(TimeoutLoop, _cancellationToken.Token);
								}
							});
							//if (isChanged && this.eventChange != null)
							//	eventChange(null, new EventArgs());
						}
						else
						{
							this.TimestampLastStopped = DateTime.Now;
							this._cancellationToken?.Cancel();
							this._cancellationToken = null;//Пока цикл не работает, не занимаем память ресурсами
							this.CancellationToken = null;
							//_taskRunning?.Dispose();
							this._taskRunning = null;//Пока цикл не работает, не занимаем память ресурсами
						}
						EventChange?.Invoke();
					}
				}
			}
		}

	}
}
