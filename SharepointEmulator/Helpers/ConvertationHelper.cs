using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharepointEmulator
{
	public class ConvertationHelper<T> where T : new()
	{

		int? GetId(ListItemEmulator item)
		{
			int? result=null;
			item.GetAllFields().Where(m => m.ToUpper() == "ID").ToList().ForEach(
				m=>result= (int)item[m]);
			return result;
		}

		public Type GetType(string fieldName)
		{
			return typeof(T).GetProperty(fieldName).PropertyType;
	   
		}
		public T ConvertToObject(ListItemEmulator emul) 
		{
			T result = new T();

			typeof(T).GetProperties().Where(pi => pi.GetSetMethod() != null).ToList().ForEach
				(pi => pi.GetSetMethod().Invoke(result, new[] { emul[pi.Name] }));

			if (emul.Id.HasValue)
			{
				typeof(T).GetProperties().Where(pi => pi.GetSetMethod() != null && pi.Name.ToUpper() == "ID").ToList().ForEach
					(pi => pi.GetSetMethod().Invoke(result, new[] {(object) emul.Id }));				
			}
			return result;
	   
		}

		public ListItemEmulator ConvertToListItem(T obj)
		{
			var result = new ListItemEmulator();

			obj.GetType().GetProperties()
				.Where(pi => pi.GetGetMethod() != null)
				.Select(pi => new {
					Name = pi.Name,
					Value = pi.GetGetMethod().Invoke(obj, null)
				}).ToList().ForEach(x => result[x.Name] = x.Value);

			if (GetId(result).HasValue)
			{
				result.Id = GetId(result);
			}

			return result;
		}
	}



}

