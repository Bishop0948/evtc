# GW2Scratch.EVTCAnalytics

A .NET library for parsing and analyzing EVTC logs generated by arcdps, an addon for Guild Wars 2.
Built with integration in other projects in mind. Currently has a very unstable API, changes are to be expected.

The library currently targets `netstandard2.0`.

## Features

- Get raw agent, skill and combat item data from logs
- Get agents and processed events with structured data
- Get encounter results
- Calculate statistics such as DPS, buff uptimes and similar (very work-in-progress)

## Example usage

```cs
string filename = "example.zevtc";

var parser = new EVTCParser();      // Used to read a log file and get raw data out of it
var processor = new LogProcessor(); // Used to process the raw data
var analyser = new LogAnalyser();   // Used to get statistics about the encounter

// The parsed log contains raw data from the EVTC file
ParsedLog parsedLog = parser.ParseLog(filename);

// The log after processing the raw data into structured events and agents
Log log = processor.GetProcessedLog(parsedLog);

// The analyser can be used to get data about the encounter
IEncounter encounter = analyser.GetEncounter(log);

Console.WriteLine($"Encounter name: {encounter.GetName()}");
Console.WriteLine($"Result: {encounter.GetResult()}");

// The processed log allows easy access to data about agents
foreach (var player in log.Agents.OfType<Player>())
{
    Console.WriteLine($"{player.Name} - {player.AccountName} - {player.Profession} - {player.EliteSpecialization}");
}
```