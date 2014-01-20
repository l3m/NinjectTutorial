import clr

clr.AddReference("NvW.CompositionRoot")
clr.AddReference("NvW.Interfaces")

import System.Threading;

import NinjaVsWerewolves as nvw

def MakeSim():
    s = sf.CreateSimulation()
    return s;

def Step(s, count = 1):
    for x in range(0, count):
        clear()
        s.Step()
    s.Visualize()
    print "\n" + s.GetAndClearLog()

def Run(s):
    while(True):
        clear()
        s.Step()
        s.Visualize()
        if s.ShouldStop():
            return
        System.Threading.Thread.CurrentThread.Join(75)


def N():
    for n in s.Ninjas:
        return n

def W():
    for w in s.Werewolves:
        return w

def clear():
    import System.Console
    System.Console.Clear()

s = None

def Init():
    global s
    s = MakeSim()

mc = nvw.CompositionRoot.ModuleConfig()
sf = mc.CreateSimulationFactory()
Init()
