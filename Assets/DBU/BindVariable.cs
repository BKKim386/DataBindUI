using MessagePipe;

namespace DBU
{
	public class BindVariable<T>
	{
		public BindVariable(string name, IPublisher<string, T> pub)
		{
			_name = name;
			_pub = pub;
			Value = default;
		}

		private string _name;
		private IPublisher<string, T> _pub;

		public T Value
		{
			get => Value;
			set
			{
				Value = value;
				_pub?.Publish(_name, Value);
			}
		}
	}
}