using System;
using MessagePipe;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using VContainer;

namespace DBU
{
	public abstract class SetterBase<T> : MonoBehaviour
	{
		[HideInInspector] public string BindField;
		[Inject] private ISubscriber<string, T> _subscriber;
		private IDisposable _disposable;
		
		protected abstract void OnResponse(T value);

		private void OnEnable()
		{
			var builder = DisposableBag.CreateBuilder();
			_subscriber.Subscribe(BindField, OnResponse).AddTo(builder);

			_disposable = builder.Build();
		}

		private void OnDestroy()
		{
			_disposable.Dispose();
		}
	}
}