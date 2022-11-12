﻿using BazosBotv2.Bazos;
using BazosBotv2.Configuration;
using BazosBotv2.Utilities;

Utils.Print("Welcome to BazosBot v0.2");
ConfigLoader.LoadConfigs();

var enabledConfigs = ConfigLoader.GetEnabledConfigs();

foreach (var enabledConfig in enabledConfigs)
{
    var bazos = new Bazos(enabledConfig);
    var dueListings = bazos.GetDueListings();
    Utils.Print($"Got {dueListings.Count} due listings! Press any key to continue...",
        location: enabledConfig.BazosLocation);
    Console.ReadKey();

    foreach (var listing in dueListings)
    {
        Utils.Print($"Trying to renew listing: {listing.Name}", location: enabledConfig.BazosLocation);
        listing.Renew();
    }
}

Utils.Exit("Bot finished!");