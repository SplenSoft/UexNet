namespace SplenSoft.UexNet;

internal partial class Examples
{
    private async void BasicExample()
    {
        // Get api key from https://uexcorp.space/account
        string uexApiToken = "xxxxxx-xxxxxxx-xxxxxx-xxxxxxx";

        // Initialize the client
        var client = new UexClient(uexApiToken);

        // Get commodities
        List<UexTerminalCommodity> commodities;
        var commoditiesTask = await client.ListRequest<UexTerminalCommodity>();

        if (commoditiesTask != null &&
            commoditiesTask.Success && 
            commoditiesTask.Data != null)
        {
            commodities = commoditiesTask.Data;

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
        var terminalsTask = await client.ListRequest<UexTerminal>();

        if (terminalsTask != null &&
            terminalsTask.Success && 
            terminalsTask.Data != null)
        {
            terminals = terminalsTask.Data;

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
    }
}