﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManager.Core.Data
{
    public   interface IRepository<T>where T:class
    {
        T GetById(object id);

        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);
        //延迟查询
        IQueryable<T> Table { get;}

    }
}
