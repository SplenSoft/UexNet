using SplenSoft.UexNet;

// Get api key from https://uexcorp.space/account
string uexApiToken = "xxxxxx-xxxxxxx-xxxxxx-xxxxxxx";

// Initialize the client
var client = new UexClient(uexApiToken);

// Get commodities
List<UexTerminalCommodity> commodities;
var commoditiesTask = client.GetCommodities();

await commoditiesTask;

if (commoditiesTask.Result != null && 
    commoditiesTask.Result.Success)
{
    commodities = commoditiesTask.Result.List;

    foreach (var commodity in commodities)
    {
        string? terminal = commodity.TerminalName;

        Console.WriteLine(
            $"{commodity.Name} at terminal {terminal}");
    }
}
else
{
    // Handle failure
    // read commoditiesTask.Result.RequestResult
}

// Get terminals
List<UexTerminal> terminals;
var terminalsTask = client.GetTerminals();

await terminalsTask;

if (terminalsTask.Result != null &&
    terminalsTask.Result.Success)
{
    terminals = terminalsTask.Result.List;

    foreach (var terminal in terminals)
    {
        Console.WriteLine(
            $"{terminal.Name}'s code is {terminal.Code}");
    }
}
else
{
    // Handle failure
    // read terminalsTask.Result.RequestResult
}