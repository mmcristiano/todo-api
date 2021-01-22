using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.QueryTests
{
    [TestClass]
    public class TodoQueriesTests
    {
        private List<TodoItem> _items;

        public TodoQueriesTests()
        {
            _items = new List<TodoItem>();
            _items.Add(new TodoItem("Tarefa 1", "usuarioA", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 2", "usuarioB", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 3", "cristianomorais", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 4", "usuarioC", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 5", "cristianomorais", DateTime.Now));
        }

        [TestMethod]
        public void Dada_a_consulta_deve_retornar_tarefas_apenas_do_usuario_cristianomorais ()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAll("cristianomorais"));
            Assert.AreEqual(2, result.Count());
        }

    }
}
