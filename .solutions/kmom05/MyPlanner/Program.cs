using MyPlanner.src;

/* Console.WriteLine("\nTesting MyTask, PrivateTask and WorkTask");
MyTask task1 = new MyTask("Privat", "Städa", new DateTime(2025, 12, 12));
Console.WriteLine(task1.GetDescription());

MyTask task2 = new MyTask("Arbete", "Programmera", new DateTime(2025, 12, 12));
Console.WriteLine(task2.GetDescription());

PrivateTask privateTask = new PrivateTask("Hemma", "Städa", "Toalett och handfat", new DateTime(2025, 12, 12));
Console.WriteLine(privateTask.GetDescription());
privateTask.Update("Hemma", "Privat2", "Test PrivateTask", new DateTime(2026, 12, 12));
Console.WriteLine(privateTask.GetDescription());

WorkTask workTask = new WorkTask(2, 40, "Csharp kursen", "Plugga", "Studera teori", new DateTime(2025, 12, 12));
Console.WriteLine(workTask.GetDescription());
workTask.Update(1, 40, 10, "Csharp kursen", "Plugga", "Studera teori & kod", new DateTime(2025, 12, 15));
Console.WriteLine(workTask.GetDescription());
Console.WriteLine($"Progression {workTask.GetProgression()}%"); */

/* Console.WriteLine("\nTesting MyTaskHandler");
MyTaskHandler myTaskHandler = new MyTaskHandler();
Console.WriteLine(myTaskHandler.GetNoOfTasks()); // bör bli 0
myTaskHandler.CreateTask("Hemma", "Städa", "Toalett och handfat", new DateTime(2025, 12, 12));
myTaskHandler.CreateTask(2, 40, "Csharp kursen", "Plugga", "Studera teori", new DateTime(2025, 12, 12));
Console.WriteLine(myTaskHandler.GetNoOfTasks()); // bör bli 2
foreach (MyTask task in myTaskHandler.GetTasks())
{
    Console.WriteLine(task.GetDescription());
}

myTaskHandler.UpdateTask("Hemma", "Städa", "Toalett och handfat och golf", new DateTime(2025, 12, 20));
Console.WriteLine(myTaskHandler.GetDescription("Städa"));
foreach (MyTask task in myTaskHandler.GetTasks())
{
    Console.WriteLine(task.GetDescription());
} */

Planner myPlanner = new Planner();

myPlanner.Run();