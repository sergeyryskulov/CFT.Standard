using SharepointEmulator.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharepointEmulator.Context
{
	public class SharepointListsContextEmulator
	{

		public ClientContextEmulator ClientContext;

		public SharepointListsContextEmulator()
		{

			ClientContext = new ClientContextEmulator();
			var properties = this.GetType().GetProperties().
				Where(pi => pi.GetSetMethod() != null &&
				pi.PropertyType.GetGenericTypeDefinition() == typeof(SharepointListEmulator<>)
				).ToList();

			foreach(var property in properties)
			{
				SharepointListEmulatorAttribute attr = (SharepointListEmulatorAttribute)property.GetCustomAttributes(true)[0];
				var propertyValue= Activator.CreateInstance(property.PropertyType, attr.ListName, ClientContext);
				property.GetSetMethod().Invoke(this, new[] { propertyValue });
			}

		}

		private void InitProperties()
		{

			
				
			
			;
		}
	}
}
