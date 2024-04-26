using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidAndGoF.GoF.Behivor.State
{
    public class TrafficLightController
    {

        public enum State
        {
            Green,
            Yellow,
            Red
        }

        public enum Action
        {
            Stop,
            Caution,
            Continue
        }

        public static Dictionary<State, Dictionary<Action, State>> StateMachine = new Dictionary<State, Dictionary<Action, State>>()
        {
            [State.Green] = new Dictionary<Action, State>()
            {
                [Action.Caution] = State.Yellow,
                [Action.Stop] = State.Red,
            },
            [State.Red] = new Dictionary<Action, State>()
            {
                [Action.Continue] = State.Green
            },
            [State.Yellow] = new Dictionary<Action, State>()
            {
                [Action.Stop] = State.Red
            }
        };



    }
}
