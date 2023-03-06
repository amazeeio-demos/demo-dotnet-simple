# dotnet-core


Simple dotnet app that reads a file in /app/words.txt and displays the output. Otherwise displays a default message.


## Setting the message

If you'd like to override the default message, there are two options.

### From in source control
You can add a file to the git repo in `src/words.txt` - this will end up in `/app/words.txt` on the running container.

### From inside the running container

You can drop a file into `/app/words/words.override.txt` to override both the default message _and_ `src/words.txt`.

One way of doing this would be to set up a custom task to do this.

Assuming you have your environment ID, you can set up the following task

```
mutation addTaskWithArgs {
  addAdvancedTaskDefinition(input: {
    name: "Add Message"
    description: "Adds a new message to display"
    environment: ***YOUR ENVIRONMENT ID GOES HERE***
    type: COMMAND
    service: "dotnet"
    permission: DEVELOPER
    advancedTaskDefinitionArguments: [
      {
        name: "MESSAGE_TEXT",
        displayName: "Message Text",
        type: STRING
      }
    ],
    command: "figlet $MESSAGE_TEXT > /app/words/words.override.txt"
  }) {
    ... on AdvancedTaskDefinitionCommand {
      id
      name
    }
  }
}
```
