﻿using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Data {
    public class PlayerHub :Hub {
        public const string HubUrl = "/player";

        public async Task BroadcastPlayers(string username) {
            await Clients.All.SendAsync("BroadcastPlayers",username);
        }
        public override Task OnConnectedAsync() {
            Console.WriteLine($"{Context.ConnectionId} connected");
            return base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync( Exception e ) {
            Console.WriteLine($"Disconnected {e?.Message} {Context.ConnectionId}");
            await base.OnDisconnectedAsync(e);
        }
    }
}