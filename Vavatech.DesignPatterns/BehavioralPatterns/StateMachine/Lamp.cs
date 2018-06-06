using Stateless;
using Stateless.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vavatech.DesignPatterns.BehavioralPatterns.StateMachine
{

    class StateMachineTests
    {

        public static void LampTest()
        {
            Lamp lamp = new Lamp();

            lamp.BeginTime = TimeSpan.FromHours(12);
            lamp.EndTime = TimeSpan.FromHours(16);

            Console.WriteLine(lamp.State);

            lamp.Start();

            Console.WriteLine(lamp.State);

            lamp.Stop();

            Console.WriteLine(lamp.State);


            lamp.Stop();

            Console.WriteLine(lamp.State);
        }
    }

    class Lamp
    {
        private StateMachine<LampState, Trigger> machine;

        public TimeSpan BeginTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public LampState State
        {
            get
            {
                return machine.State;
            }
        }

        public Lamp()
        {

            machine = new StateMachine<LampState, Trigger>(LampState.Off);

            machine.Configure(LampState.Off)
                .Permit(Trigger.ClickDown, LampState.On)
                .Permit(Trigger.Voice, LampState.Blinking)
                .Ignore(Trigger.ClickUp)
               //  .IgnoreIf(Trigger.ClickDown, () => DateTime.Now.TimeOfDay >= BeginTime && DateTime.Now.TimeOfDay <= EndTime)
                .OnEntry(() => PowerOn(), "PowerOn")
                ;


            machine.Configure(LampState.On)
                .Permit(Trigger.ClickUp, LampState.Off)
                .Ignore(Trigger.ClickDown)
                .OnEntry(() => Console.WriteLine("Włączono światło!"), "Send");


            string graph = UmlDotGraph.Format(machine.GetInfo());

            Console.WriteLine(graph);
        }


        private void PowerOn()
        {
        }

        private void Send()
        {
        }

        public bool CanStart => machine.CanFire(Trigger.ClickDown);

        public void Start()
        {
            machine.Fire(Trigger.ClickDown);
        }

        public void Stop()
        {
            machine.Fire(Trigger.ClickUp);
        }
    }

    enum LampState
    {
        Off,
        On,
        Blinking
    }

    enum Trigger
    {
        ClickUp,
        ClickDown,
        ElapsedTime,

        Voice
    }


   
}
