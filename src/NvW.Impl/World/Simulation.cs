using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NinjaVsWerewolves.Creature;

namespace NinjaVsWerewolves.World
{
    public class Simulation : ISimulation
    {
        private readonly ICreatureFactory _creature_factory;
        private readonly HashSet<ICreature> _creatures = new HashSet<ICreature>();
        private readonly IRandom _random;
        private readonly IWorld _world;

        private StringBuilder _sb = new StringBuilder();
        private int _werewolf_count;

        public Simulation(IRandom random, IWorld world, ICreatureFactory cf)
        {
            _random = random;
            _world = world;
            _creature_factory = cf;

            Name = "Sim_" + _random.Random(100).ToString();

            Init();
        }

        public IWorld World
        {
            get { return _world; }
        }

        public void Step()
        {
            foreach (var c in Shuffle(Creatures))
            {
                var neighbors = Shuffle(_world.FindNeighbors(c));
                var s = c.Encounter(neighbors);
                if (s != "")
                {
                    _sb.AppendLine(s);
                }
            }

            var deaths = new HashSet<ICreature>();
            var turned = new HashSet<ICreature>();
            foreach (var c in Creatures)
            {
                if (c.Health <= 0)
                {
                    _world.RemoveCreature(c);
                    deaths.Add(c);
                    _sb.AppendLine(c.Name + " dies.");
                    continue;
                }
                if (c.Infected && (c is IJogger))
                {
                    if (_random.Random(5) > 1)
                    {
                        continue;
                    }
                    uint pos = c.Position;
                    _world.RemoveCreature(c);
                    deaths.Add(c);

                    var w = _creature_factory.CreateWerewolf();
                    w.Name = w.Name + _werewolf_count++;
                    turned.Add(w);
                    _world.PlaceCreature(w, pos);

                    _sb.AppendLine(c.Name + " turns into " + w.Name);
                    continue;
                }
                // change direction if blocked, or with a small chance.
                if (!_world.MoveCreature(c) || _random.Random(10) == 0)
                {
                    c.Direction = _random.Random(7u);
                }
            }

            foreach (var d in deaths)
            {
                _creatures.Remove(d);
            }
            foreach (var t in turned)
            {
                _creatures.Add(t);
            }
        }

        public void Visualize()
        {
            Console.Write(_world.AsciiVisualization);
            Console.Write(Environment.NewLine);
            Console.Write(Summary);
            Console.Write(Environment.NewLine);
        }

        public string GetAndClearLog()
        {
            var s = _sb.ToString();
            _sb = new StringBuilder();
            return s;
        }

        public string Summary
        {
            get
            {
                var nl = Environment.NewLine;
                return string.Format(
                    "Ninjas:     {0}" + nl +
                    "Werewolves: {1}" + nl +
                    "Joggers:    {2}",
                    Ninjas.Count(), Werewolves.Count(), Joggers.Count());
            }
        }

        public bool ShouldStop()
        {
            var ws = Werewolves.ToArray();
            if (ws.Length == 0)
            {
                return true;
            }

            return ws.Length == _creatures.Count;
        }

        public string Name { get; private set; }

        public IEnumerable<INinja> Ninjas
        {
            get { return _creatures.OfType<INinja>(); }
        }

        public IEnumerable<IWerewolf> Werewolves
        {
            get { return _creatures.OfType<IWerewolf>(); }
        }

        public IEnumerable<IJogger> Joggers
        {
            get { return _creatures.OfType<IJogger>(); }
        }

        public IEnumerable<ICreature> Creatures
        {
            get { return _creatures; }
        }

        public IList<ICreature> Shuffle(IEnumerable<ICreature> cs)
        {
            // based from http://stackoverflow.com/a/1262619/1591992
            var list = cs.ToList();

            var rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                var value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            return list;
        }

        private void Add<T>(int count, Func<T> factory) where T : ICreature
        {
            for (uint i = 0; i < count; ++i)
            {
                var c = factory();
                c.Direction = _random.Random(7u);

                _creatures.Add(c);

                c.Name = c.Name + i;
            }
        }

        private void Init()
        {
            IList<ICreature> cs = new List<ICreature>();

            Add(6, _creature_factory.CreateNinja);
            _werewolf_count = 6;
            Add(_werewolf_count, _creature_factory.CreateWerewolf);
            Add(6, _creature_factory.CreateJogger);

            foreach (var c in Creatures)
            {
                bool ok = _world.PlaceRandomly(c);
                while (!ok)
                {
                    ok = _world.PlaceRandomly(c);
                }
            }
        }
    }
}
