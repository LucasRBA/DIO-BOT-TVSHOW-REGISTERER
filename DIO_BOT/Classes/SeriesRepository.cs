using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DIO_BOT.Interfaces;
using DIO_BOT.Classes;

namespace DIO_BOT
{
    public class SeriesRepository : IRepository<Series>
    {
        private List<Series> ListSeries = new List<Series>();
		public void Update(int id, Series entity)
		{
			ListSeries[id] = entity;
		}

		public void Delete(int id)
		{
			ListSeries[id].Delete();
		}

		public void Insert(Series entity)
		{
			ListSeries.Add(entity);
		}

		public List<Series> List()
		{
			return ListSeries;
		}

		public int NextId()
		{
			return ListSeries.Count;
		}

		public Series ReturnId(int id)
		{
			return ListSeries[id];
		}
    }
}