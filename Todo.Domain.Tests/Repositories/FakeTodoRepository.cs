﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Domain.Tests.Repositories
{
    public class FakeTodoRepository : ITodoRepository
    {
        public void Create(TodoItem todo)
        {
        }

        public TodoItem GetById(Guid id, string email)
        {
            return new TodoItem("Titulo", "cristianomorais", DateTime.Now);
        }

        public void Update(TodoItem todo)
        {
        }
    }
}
