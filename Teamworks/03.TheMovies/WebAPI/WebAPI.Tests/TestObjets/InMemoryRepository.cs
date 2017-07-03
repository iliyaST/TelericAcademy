﻿using System;
using System.Collections.Generic;
using System.Linq;
using MovieDb.Data;

namespace WebAPI.Test
{
    public class InMemoryRepository<T> : IRepository<T>
        where T : class
    {
        private readonly List<T> data;

        public InMemoryRepository()
        {
            this.data = new List<T>();
            this.AttachedEntities = new List<T>();
            this.DetachedEntities = new List<T>();
            this.UpdatedEntities = new List<T>();
        }

        public IList<T> AttachedEntities { get; private set; }

        public IList<T> DetachedEntities { get; private set; }

        public bool isDisposed { get; private set; }

        public int NumberOfSavedChanges { get; private set; }

        public IList<T> UpdatedEntities { get; private set; }

        public IQueryable<T> All
        {
            get
            {
                return this.data.AsQueryable();
            }
        }

        public void Add(T entity)
        {
            this.data.Add(entity);
        }

        public T Attach(T entity)
        {
            this.AttachedEntities.Add(entity);
            return entity;
        }

        public void Delete(object id)
        {
            if (this.data.Count == 0)
            {
                throw new InvalidOperationException("No entity to delete");
            }
            this.data.Remove(data[0]);
        }

        public void Delete(T entity)
        {
            if (this.data.Count == 0)
            {
                throw new InvalidOperationException("No entity to delete");
            }

            this.data.Remove(entity);
        }

        public void Detach(T entity)
        {
            this.DetachedEntities.Add(entity);
        }

        public void Dispose()
        {
            this.isDisposed = true;
        }

        public T GetById(object id)
        {
            if (this.data.Count == 0)
            {
                throw new InvalidOperationException("No entity to delete");
            }

            return this.data[0];
        }

        public int SaveChanges()
        {
            this.NumberOfSavedChanges++;
            return 1;
        }

        public void Update(T entity)
        {
            this.UpdatedEntities.Add(entity);
        }
    }
}
