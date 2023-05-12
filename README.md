# About

A library for easy logging through form in `Activity` !

# Advantages

With this library, you can organize your program more structured.

And you can use this library to realize some functions like workflows.

# Usage

## Install

Through cli:

```shell
dotnet add package Common.Activity
```

## Import namespace

```csharp
using Common.Activity;
```

## Use

```csharp
var activity = new Activity()
    {
        Id = 1,
        Name = "Activity_Calculate",
        Author = "Author",
        IconKind = null,
        Title = null,
        Category = null,
    }
    .Open("samples")
    .Assign("samples", "samples")
    .Assign("samples", "computer")
    .RemoveAssign("samples", "samples")
    .Label("samples", "running")
    .AppendTask(
        new ActivityTask()
            {
                Action = controller =>
                {
                    controller.LogContents(0, $"1 + 0 = {1 + 0}");
                    controller.Result = 1 + 0;
                    controller.Progress = new Progress(ProgressType.Tasks)
                    {
                        Value = new Tuple<int, int>(1, 1)
                    };
                },
            }
            .AppendTask(
                new ActivityTask()
                {
                    Action = controller =>
                    {
                        controller.LogContents(0, $"1 + 1 = {1 + 1}");
                        controller.Result = 1 + 1;
                        controller.Progress = new Progress(ProgressType.Tasks)
                        {
                            Value = new Tuple<int, int>(1, 1)
                        };
                    }
                }
            )
            .AppendTask(
                new ActivityTask()
                {
                    Action = controller =>
                    {
                        controller.LogContents(0, $"1 + 2 = {1 + 2}");
                        controller.Result = 1 + 2;
                        controller.Progress = new Progress(ProgressType.Tasks)
                        {
                            Value = new Tuple<int, int>(1, 1)
                        };
                    }
                }
            )
    )
    .ExecuteAllTasks();
```

If you use JsonSerializer in `System.Text.Json` to serialize `activity`,

```csharp
var options = new JsonSerializerOptions()
{
    WriteIndented = true,
    IncludeFields = true,
};

Console.WriteLine(
    JsonSerializer.Serialize(activity, options)
);
```

the output would be like:

```json
{
  "Id": 1,
  "Name": "Activity_Calculate",
  "Author": "Samples",
  "Title": null,
  "Category": null,
  "IconKind": null,
  "Assigners": [
    "computer"
  ],
  "Labels": [
    "running"
  ],
  "Tasks": [
    {
      "Name": null,
      "Progress": {
        "Value": {
          "Item1": 1,
          "Item2": 1
        }
      },
      "IsLoopTask": false,
      "SubTasks": [
        {
          "Name": null,
          "Progress": {
            "Value": {
              "Item1": 1,
              "Item2": 1
            }
          },
          "IsLoopTask": false,
          "SubTasks": [],
          "Contents": {
            "0": "1 \u002B 1 = 2"
          },
          "Warnings": {},
          "Errors": {},
          "Status": 3,
          "Result": 2
        },
        {
          "Name": null,
          "Progress": {
            "Value": {
              "Item1": 1,
              "Item2": 1
            }
          },
          "IsLoopTask": false,
          "SubTasks": [],
          "Contents": {
            "0": "1 \u002B 2 = 3"
          },
          "Warnings": {},
          "Errors": {},
          "Status": 3,
          "Result": 3
        }
      ],
      "Contents": {
        "0": "1 \u002B 0 = 1"
      },
      "Warnings": {},
      "Errors": {},
      "Status": 3,
      "Result": 1
    }
  ],
  "Operations": {
    "OpenAndCloseOperations": [
      {
        "Subject": "samples",
        "ExecuteTime": "2023-05-12T13:52:29.8833534Z",
        "Operation": 0
      }
    ],
    "AssignersRelatedOperations": [
      {
        "Subject": "samples",
        "ExecuteTime": "2023-05-12T13:52:29.8842917Z",
        "Operation": 0,
        "Targets": [
          "samples"
        ]
      },
      {
        "Subject": "samples",
        "ExecuteTime": "2023-05-12T13:52:29.8846075Z",
        "Operation": 0,
        "Targets": [
          "computer"
        ]
      },
      {
        "Subject": "samples",
        "ExecuteTime": "2023-05-12T13:52:29.8849135Z",
        "Operation": 1,
        "Targets": [
          "samples"
        ]
      }
    ],
    "LabelsRelatedOperations": [
      {
        "Subject": "samples",
        "ExecuteTime": "2023-05-12T13:52:29.8854133Z",
        "Operation": 0,
        "Targets": [
          "running"
        ]
      }
    ]
  },
  "Status": 1
}
```


