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
                .Select(line => line.Trim().ToCharArray())
                .ToArray();

            this.directionMap = new Dictionary<Direction, Vector>()
            {
                { Direction.None, new Vector() },
                { Direction.N, new Vector(0, -1) },
                { Direction.E, new Vector(1, 0) },
                { Direction.S, new Vector(0, 1) },
                { Direction.W, new Vector(-1, 0) },
                { Direction.NW, new Vector(-1, -1) },
                { Direction.NE, new Vector(1, -1) },
                { Direction.SW, new Vector(-1, 1) },
                { Direction.SE, new Vector(1, 1) },
            };
        }

        private bool SearchCharacterInDirection(Vector origin, Direction direction, char target)
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
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errored vector from {origin} to {newVector}");
            }
            return false;
        }

        private bool SearchCharactersInDirectionRecursive(Vector origin, Direction direction, char[] chars)
        {
            if (chars.Length == 0) return true;
            var target = chars[0];
            var vector = this.directionMap[direction];
            var newVector = new Vector(origin.X + vector.X, origin.Y + vector.Y);
            try
            {
                if (IsValidCoordinate(newVector))
                {
                    var character = this.grid[newVector.Y][newVector.X];
                    if (character == target)
                    {
                        origin = newVector;
                        return SearchCharactersInDirectionRecursive(origin, direction, chars.Skip(1).ToArray());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errored vector from {origin} to {newVector}");
            }
            return false;
        }

        public bool IsValidCoordinate(Vector coordinate)
        {
            if (coordinate.X < 0 || coordinate.Y < 0) return false;
            if (coordinate.Y > grid.Length - 1) return false;
            if (coordinate.X > grid[coordinate.Y].Length -1) return false;
            return true;
        }

        public override string Gold()
        {
            var aCharacterVectors = new List<Vector>();

            for (var y = 0; y < grid.Length; y++)
            {
                for (var x = 0; x < grid[y].Length; x++)
                {
                    if (grid[y][x] == 'A')
                    {
                        aCharacterVectors.Add(new Vector(x, y));
                    }
                }
            }

            var foundXmas = 0;
            var dirs = new List<Direction>()
            {
                Direction.NE,
                Direction.NW,
                Direction.SE,
                Direction.SW
            };
            foreach (var vector in aCharacterVectors)
            {
                // Get letters from each corner
                var corners = new Dictionary<Direction, char>();
                foreach (var dir in dirs)
                {
                    var foundM = SearchCharacterInDirection(vector, dir, 'M');
                    if (foundM) 
                    {
                        corners.Add(dir, 'M');
                    }
                    var foundS = SearchCharacterInDirection(vector, dir, 'S');
                    if (foundS)
                    {
                        corners.Add(dir, 'S');
                    }
                }

                if (!dirs.All(x => corners.ContainsKey(x)))
                {
                    continue;
                }

                // Skip "MAM" or "SAS"
                if (corners[Direction.NE] == corners[Direction.SW] || corners[Direction.NW] == corners[Direction.SE]) {
                    continue;
                }

                foundXmas++;
            }


            return foundXmas.ToString();
        }

        public override string Silver()
        {
            var xCharacterVectors = new List<Vector>();
            
            for (var y = 0; y < grid.Length; y++)
            {
                for (var x = 0; x < grid[y].Length; x++)
                {
                    if (grid[y][x] == 'X')
                    {
                        xCharacterVectors.Add(new Vector(x, y));
                    }
                }
            }

            var foundXmas = 0;
            foreach (var vector in xCharacterVectors)
            {
                foreach (var mapping in this.directionMap)
                {
                    var dir = mapping.Key;
                    var chars = new char[]
                    {
                        'M','A','S'
                    };

                    var found = SearchCharactersInDirectionRecursive(vector, dir, chars);
                    if (found)
                    {
                        foundXmas++;
                    }
                }
            }
            return foundXmas.ToString();
        }

        public struct Vector
        {
            public int X { get; private set; }
            public int Y { get; private set; }
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
