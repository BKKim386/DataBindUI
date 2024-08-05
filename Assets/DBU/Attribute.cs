using System;
using System.Linq;

namespace DBU
{
	public sealed class InjectorModelAttribute : Attribute
	{
		public Type[] InjectModel;

		public InjectorModelAttribute(params Type[] InjectModel)
		{
			// if (InjectModel.Any(type => type.IsAssignableFrom(typeof(IBindModel))) == false)
			// 	throw new Exception();
			
			this.InjectModel = InjectModel;
		}
	}
}