using System;
using System.Linq;

namespace DBU
{
	public sealed class InjectorModelAttribute : Attribute
	{
		public Type[] InjectModel;

		public InjectorModelAttribute(params Type[] InjectModel)
		{
			this.InjectModel = InjectModel;
		}
	}
}