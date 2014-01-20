using System;
using System.Collections.Generic;
using System.Text;
using NinjaVsWerewolves.Creature;

namespace NinjaVsWerewolves.World
{
    public class SimpleWorld : IWorld
    {
        private readonly IList<ICreature> _grid = new List<ICreature>();
        private readonly IRandom _random;

        private readonly int[] _x_neighborhood = {-1, 0, 1, 1, 1, 0, -1, -1};
        private readonly int[] _y_neighborhood = {-1, -1, -1, 0, 1, 1, 1, 0};

        public SimpleWorld(IRandom r)
        {
            _random = r;
            Name = "World_ " + _random.Random(1000).ToString();
            InitGrid();
        }

        public int Width { get; private set; }
        public int Height { get; private set; }

        public void RemoveCreature(ICreature c)
        {
            _grid[(int)c.Position] = null;
        }

        public string Name { get; private set; }

        public string AsciiVisualization
        {
            get
            {
                var sb = new StringBuilder();
                int cell = 1;
                foreach (var c in _grid)
                {
                    sb.Append(c == null ? '.' : c.Sprite);
                    if (cell % Width == 0)
                    {
                        sb.AppendLine();
                    }
                    ++cell;
                }
                sb.AppendLine();
                return sb.ToString();
            }
        }

        public IEnumerable<ICreature> FindNeighbors(ICreature c)
        {
            // yeah yeah I know - quadtree
            // but lets just use a grid for now ;)

            for (uint i = 0; i < 8; ++i)
            {
                int index = MakeIndex(c.Position, i);
                var nb = _grid[index];
                if (nb != null)
                {
                    yield return nb;
                }
            }
        }

        public bool PlaceRandomly(ICreature c)
        {
            uint x = _random.Random((uint)Width);
            uint y = _random.Random((uint)Height);

            int index = Width * (int) y + (int) x;
            if (_grid[index] == null)
            {
                _grid[index] = c;
                c.Position = (uint) index;
                return true;
            }
            return false;
        }

        public bool PlaceCreature(ICreature c, uint pos)
        {
            int index = (int) pos;
            if (_grid[index] != null)
                return false;
            _grid[index] = c;
            c.Position = pos;
            return true;
        }

        private void InitGrid()
        {
            Width = 32;
            Height = 8;

            var s = Width * Height;
            for (int i = 0; i < s; ++i)
            {
                _grid.Add(null);
            }
        }

        public bool MoveCreature(ICreature c)
        {
            int new_pos = MakeIndex(c.Position, c.Direction);

            if (_grid[new_pos] != null)
            {
                return false;
            }

            _grid[(int) c.Position] = null;
            _grid[new_pos] = c;
            c.Position = (uint) new_pos;

            return true;
        }

        private int MakeIndex(uint position, uint direction)
        {
            int d = (int) direction % 8;
            var p = (int) position;

            int new_pos = p + _x_neighborhood[d] + _y_neighborhood[d] * Width;

            int s = _grid.Count;

            if (new_pos < 0)
            {
                new_pos += s;
            }
            if (new_pos >= s)
            {
                new_pos %= s;
            }

            return new_pos;
        }
    }
}
