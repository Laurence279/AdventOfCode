using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.CLI.Days
{
    public class Day4 : Puzzle
    {
        private readonly char[][] grid;
        private readonly Dictionary<Direction, Vector> directionMap;
        public Day4(string input)
        {
            this.grid = input
                .Replace("\r", "")
                .Split("\n")
                .Select(line => line.ToCharArray())
                .ToArray();

            // x: [1, 0], [-1, 0]
            // y: [0, 1], [0, -1]
            // d1: [1, 1], [-1, -1]
            // d2: [-1, 1], [1, -1]
            this.directionMap = new Dictionary<Direction, Vector>()
            {
                { Direction.None, new Vector() },
                { Direction.N, new Vector(0, 1) },
                { Direction.E, new Vector(1, 0) },
                { Direction.S, new Vector(0, -1) },
                { Direction.W, new Vector(-1, 0) },
                { Direction.NW, new Vector(1, 1) },
                { Direction.NE, new Vector(-1, 1) },
                { Direction.SW, new Vector(-1, -1) },
                { Direction.SE, new Vector(1, -1) },

            };
        }

        private bool SearchSurroundingCharacters(Vector origin, char target, out Vector foundAt, out Direction direction)
        {
            foreach (var mapping in this.directionMap)
            {
                direction = mapping.Key;
                var vector = mapping.Value;
                // If my origin is [0, 7], then the following will become:
                    // [1, 7]
                    // [-1, 7]
                    // [0, 8]
                    // etc...
                var newVector = new Vector(origin.X + vector.X, origin.Y + vector.Y);
                if (IsValidCoordinate(newVector))
                {
                    var character = this.grid[newVector.Y][newVector.X];
                    if (character == target)
                    {
                        foundAt = newVector;
                        return true;
                    }
                }
            }
            foundAt = new Vector();
            direction = Direction.None;
            return false;
        }

        private bool SearchCharacterInDirection(Vector origin, char target, Direction direction, out Vector foundAt)
        {
            var vector = this.directionMap[direction];
            var newVector = new Vector(origin.X + vector.X, origin.Y + vector.Y);
            try
            {
                if (IsValidCoordinate(newVector))
                {
                    var character = this.grid[newVector.Y][newVector.X];
                    if (character == target)
                    {
                        foundAt = newVector;

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errored vector {newVector}");
            }
            foundAt = new Vector();
            return false;
        }

        public bool IsValidCoordinate(Vector coordinate)
        {
            if (coordinate.X < 0 || coordinate.Y < 0) return false; // Negative indices
            if (coordinate.Y > grid.Length -1) return false; // Row out of bounds
            if (coordinate.X > grid[coordinate.Y].Length -1) return false; // Column out of bounds
            return true;
        }

        public override string Gold()
        {
            return string.Empty;
        }

        public override string Silver()
        {
            // We only need to search from a position if it starts with an X
            // Once we find an x we need to look in all possible directions for the word
            // Search in each direction up to 3 times, to see if the word makes "xmas"

            var xCharacterVectors = new List<Vector>();
            
            for (var y = 0; y < grid.Length; y++)
            {
                for (var x = 0; x < grid[y].Length; x++)
                {
                    if (grid[y][x] == 'X')
                    {
                        xCharacterVectors.Add(new Vector(x, y));
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.Write(grid[y][x]);
                }
                Console.WriteLine("");
            }

            var foundXmas = 0;
            foreach (var vector in xCharacterVectors)
            {
                Console.WriteLine($"searching {vector.ToString()}");

                Vector foundAt;
                Direction dir;
                var foundM = SearchSurroundingCharacters(vector, 'M', out foundAt, out dir);
                if (foundM)
                {
                    var foundA = SearchCharacterInDirection(foundAt, 'A', dir, out foundAt);
                    if (foundA)
                    {
                        if (SearchCharacterInDirection(foundAt, 'S', dir, out _))
                        {
                            foundXmas++;
                        }
                    }
                }
            }
            return foundXmas.ToString();
        }

        public struct Vector
        {
            public int X { get; set; }
            public int Y { get; set; }
            public Vector(int x, int y)
            {
                X = x;
                Y = y;
            }

            public override string ToString()
            {
                return $"({X}, {Y})";
            }
        }

        public enum Direction
        {
            None,
            N,
            E,
            S,
            W,
            NE,
            NW,
            SE,
            SW
        }
    }
}
