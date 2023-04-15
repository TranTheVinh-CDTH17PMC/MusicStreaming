using Microsoft.EntityFrameworkCore;
using MusicStreaming.Entitis;
using MusicStreaming.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStreaming.Repository
{
    public class RRepository<T> : RInterface<T> where T : class
    {
        public MusicStreamingContext _db { get; set; }
        protected DbSet<T> _table;
        public RRepository()
        {
            _db = new MusicStreamingContext();
            _table = _db.Set<T>();
        }
        public RRepository(MusicStreamingContext db)
        {
            _db = db;
            _table = _db.Set<T>();
        }

        public IEnumerable<T> SelectAll()
        {
            return _table.ToList();
        }

        public T SelectById(object id)
        {
            try
            {
                return _table.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public void Insert(T obj)
        {
            _table.Add(obj);
        }

        public void Update(T obj)
        {
            _table.Attach(obj);
            _db.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            T existing = _table.Find(id);
            _table.Remove(existing);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
