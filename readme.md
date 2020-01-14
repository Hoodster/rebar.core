# rebar.core
NuGet library to support the CQS pattern-based project with Autofac implementation.

## Note
The library is created for personal purposes but I decided that it can get useful for someone else so feel free to use it.

## NuGet Library 
You can find library [here](https://www.nuget.org/packages/rebar.core/).

# Getting started
The repository is a sample project using **rebar.core**. However, all the process is described below.

## Requirements
- .NET Core 3.0 or newer
- Autofac IoC project

## Configuration
First, configure the project for Autofac using Autofac's getting started [guide](https://autofac.readthedocs.io/en/latest/getting-started/index.html).

We need to register components for commands and queries.

Choose the module you want to use. Especially when you got multiple projects in the solution select module where you want to store commands and queries.

### SampleModule.cs
```
using Autofac;
using Rebar.Core;
using static System.Reflection.Assembly;

public class SampleModule : Module 
{
	protected override Load(ContainerBuilder builder) {
		var assembly = GetExecutingAssembly();

		builder.RegisterAll(assembly); //register commands and queries
		builder.AddRebar(); //register rebar.core
	}
}
```
# Commands
Commands are used to execute instruction without receiving data.

## Classes
Commands have two classes:
- **[_name_]Command** - used to pass data between controller and command handler
- **[_name_]CommandHandler<[_name_]Command>** - used to execute command 

> Remember about the naming convention. Dispatcher checks out class names. If they don't match the following pattern you will get `HandlerNotFoundException` 

## Usage
### SampleController.cs
```
using Rebar.Core.Controller;
using Rebar.Core.Command;

public class SampleController {
    private ICommandDispatcher _dispatcher //declare dispatcher for commands
    
    public SampleController(ICommandDispatcher dispatcher) {
       this._dispatcher = dispatcher;
    }

    [HttpPost]
    public Task<IActionResult> CommandEndpoint() 
    {
       var command = new SampleCommand() //we create new command
       
       return await this.HandleRequest(_dispatcher, command); //command is executed and will return status code for called endpoint
    }
}
```
