using CamlexNET.Interfaces;
using SharepointEmulator.Context;
using SharepointEmulator.Helpers;
using SharepointEmulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SharepointEmulator
{

	public class SharepointListEmulator<T> where T : new()
	{
				
		private ListEmulator _list;

		private ConvertationHelper<T> _convertationHelper =new ConvertationHelper<T>();

		static int idCounter = 1;		

		public SharepointListEmulator(string listName, ClientContextEmulator clientContext)
		{
			if (!clientContext.Lists.ContainsKey(listName))
			{
				clientContext.AddList(listName);
			}

			_list = clientContext.GetListByTitle(listName);
		}

		public int Count()
		{
			return GetAllItems().Count; 
		}		

		public T GetItemById(int id)
		{
			var filtered = _list.Where(m => m.Id == id).FirstOrDefault();
			if (filtered == null)
			{
				throw new Exception("not found");
			}
			return _convertationHelper.ConvertToObject(filtered);
		}		
	
		public List<T> GetItems(IQuery query)
		{															
			var camlHelper = new CamlHelper<T>("" + query);
			var result = new List<T>();
			foreach (var item in _list)
			{
				if (camlHelper.CheckWhere(item))
				{
					result.Add(_convertationHelper.ConvertToObject(item));
				}
			}
			return result;
		}

		public List<T> GetAllItems()
		{
			return _list.ConvertAll(m => _convertationHelper.ConvertToObject(m));
		}

		public void UpdateItem(T item) {

			var inputItem = _convertationHelper.ConvertToListItem(item);
			if (!inputItem.Id.HasValue)
			{
				throw new Exception("item key not exists");
			}			

			if (!_list.Where(m => m.Id == inputItem.Id).Any())
			{
				throw new Exception("item not found");
			}

			var itemToUpdate= _list.Where(m => m.Id == inputItem.Id).FirstOrDefault();
			foreach (var fieldName in inputItem.GetAllFields().Where(m=>m.ToUpper()!="ID"))
			{
				if (fieldName.ToUpper() == BaseListFields.Author.ToUpper()
				    && inputItem[fieldName]==null)
				{
					continue;					
				}

				if (fieldName.ToUpper() == BaseListFields.Created.ToUpper())
				{
					continue;
				}
				itemToUpdate[fieldName] = inputItem[fieldName];
			}
			_list.ItemUpdating(itemToUpdate);
		}

		public int AddItem(T item)
		{
			var newItem = _convertationHelper.ConvertToListItem(item);			
			newItem.Id = idCounter++;
			_list.Add(newItem);
			_list.ItemAdding(newItem);
			return newItem.Id.Value;
		}

		public void DeleteItem(int id)
		{
			if (!_list.Where(m => m.Id == id).Any())
			{
				throw new Exception("item not found");
			}
			_list.RemoveAll(m => m.Id == id);
		}
	}
}
