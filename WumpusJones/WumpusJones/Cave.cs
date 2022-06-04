﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace WumpusJones
{
    public class Cave
    {
        private Room[] rooms;
        public List<int> Explored { get; } = new();

        public Room RoomAt(int roomNumber) => rooms[roomNumber - 1];

        public Cave(int map)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = assembly.GetManifestResourceNames().Single(x => x.EndsWith($"Cave.dat"));
            using var stream = assembly.GetManifestResourceStream(resourceName);
            using StreamReader reader = new(stream);

            rooms = reader.ReadToEnd()
                          .Split('\n')
                          .Select(x => new Room(x.Split(',').Select(int.Parse).ToArray()))
                          .ToArray();

            resourceName = assembly.GetManifestResourceNames().Single(x => x.EndsWith($"Cave{map}.dat"));
            using var stream2 = assembly.GetManifestResourceStream(resourceName);
            using StreamReader reader2 = new(stream2);
            foreach (var room in rooms)
                room.Parse(reader2.ReadLine());
        }

        public void ExploredRoom(int room) =>
            Explored.Add(room);
    }
}