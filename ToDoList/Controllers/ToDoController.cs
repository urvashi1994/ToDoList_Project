using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ToDoList.Models;
using ToDoList_DataLayer;
using static ToDoList_DataLayer.Task;

namespace ToDoList.Controllers
{
    public class ToDoController : Controller
    {
        //GET:Todo
        public ActionResult Index()
        {
            Task dal = new Task();

            var tasks = dal.GetAllTask();

            List<ToDo> tasklist = new List<ToDo>();

            foreach(var task in tasks)
            {
                ToDo task1 = new ToDo();
                task1.id = task.id;
                task1.Task_name = task.Task_name;

                tasklist.Add(task1);
            }
            return View(tasklist);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    TaskDetails tasks = new TaskDetails();
                    tasks.Task_name = collection["Task_name"];

                    Task dal = new Task();

                    dal.InsertTask(tasks);

                    RedirectToAction("Index");

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}