# Configuring an ASP.net application for different environments

## Hook

When you create an ASP.net application from the Visual Studio templates, or you look at example scaffolds on the internet, you'll see the following snippet of code.

```
if (env.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
```

Once you get beyond the simple 'Hello, World!' and other learning excerises, this pattern does you a disservice and it's a pattern you should avoid.

## Introduction

Configuring applications during startup 

As developers, we've been ingrained with certain advices, some to a fault.

... that magic strings are wicked
... that dependency injection is rad
... that DRY is the bee's knees
... that my sayings might be out of date
... etc

## The Why

<insert picture of 3 card monty>

At some point, you _have_ to define your environment and your dependency stack. Some things can be injected at runtime, such as environment variables. Others need to be defined in code for various reasons.

The ones in code are often the ones that cause problems. They don't emerge until you deploy to the most 'Production-Like' environment because of how we, as developers, structure our environments.

After all, who wants to run a full blown environment stack while unit testing?
Who wants to pay for the integration environment to run with the same availability as production?
Who wants to debug during development with production-compiled dependencies and stack traces?

## The Implication

At a project level, we will have seperate execution paths for different environments. How do we keep our deployments secure and only deploy what we want to deploy?

## The Stumbling Point

If we make decisions based on the Environment using control statements, it's easy to either code a bug into the system or just plain forget to guard development or production confirguration appropriately. It also makes reasoning about and the tracing control flow interesting while running in different environments. 

When running an ASP.net application via the dotnet runtime, if you don't provide an environment on the command line, it'll default with 'production'. However, in this age of Containers and scripting, I'd be very surprised if your command didn't look something like `dotnet run <project.dll> --environment=$ENVIRONMENT` or something along those lines. 

Which means, you have to ask yourself a question. Did you misspell "production"? Well, did you?

## The Solution

The solution to this mess is to not use control statements when setting up the `Startup.cs` file. Let the system detect and execute what it thinks is the correct resources while at the same time being explict in what environment the code should be running in. This allows you the ability to pattern the code in, what I think is, one of the safer declaration patterns that comes from access control: `deny all; allow specific`

ASP.net supports and allows you to define environment-based startup classes and methods.

### Mid-sized Solution

In a mid-sized application, everything can be crammed into a single `Startup.cs` file and still be understandable.



### The Other Solution

Once you get beyond a certain size, it's probably advantegous to split apart the startup classes.  


## References

* https://docs.microsoft.com/en-us/aspnet/core/fundamentals/environments?view=aspnetcore-5.0
* https://stackoverflow.com/questions/54901609/how-to-set-the-environment-of-dotnet-core-in-docker