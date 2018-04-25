using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq.Expressions;
using System.Linq;
using System.IO;

namespace Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected JsonSerializer serializer;
        protected List<TEntity> entityList;

        public Repository(string FileSource)
        {
            serializer = new JsonSerializer();
            entityList = JArray.Parse(File.ReadAllText(FileSource)).ToObject<List<TEntity>>();
        }

        public TEntity Get(int id)
        {
            return entityList[id-1];

        }

        public List<TEntity> GetAll()
        {
            return entityList;
        }

        public List<TEntity> Find(Predicate<TEntity> predicate)
        {
            return entityList.FindAll(predicate);
        }

        public void Add(TEntity entity)
        {
            entityList.Add(entity);
        }


        public void Remove(TEntity entity)
        {
            entityList.Remove(entity);
        }

        public void RemoveRange(int indexAt, int number)
        {
            entityList.RemoveRange(indexAt, number);
        }
    }
}
