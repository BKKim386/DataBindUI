using VContainer;
using VContainer.Unity;

namespace DBU
{
	public abstract class UIBaseLifetimeScope : LifetimeScope
	{
		protected override void Configure(IContainerBuilder builder)
		{
			base.Configure(builder);
			RegisterModel(builder);
		}

		
		protected virtual void RegisterModel(IContainerBuilder builder) { }
	}
}