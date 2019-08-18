using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Suske
{
    public class CommandPattern : MonoBehaviour
    {
        CommandManager cmdMgr = new CommandManager();

        private void Start()
        {
            ICommand cmd = new Command1();
            cmdMgr.AddCommand(cmd);
        }

        private void Update()
        {
            if(cmdMgr != null)
            {
                cmdMgr.Update();
            }
        }
    }

    public interface ICommand
    {
        void Execute();
    }

    public class Command1:ICommand
    {
        public void Execute()
        {
            Debug.Log(GetType().Name + " Execute.");
        }
    }

    public class CommandManager
    {
        List<ICommand> cmdList = new List<ICommand>();

        public void AddCommand(ICommand cmd)
        {
            cmdList.Add(cmd);
        }

        public void Update()
        {
            for (int idx = 0; idx < cmdList.Count; idx++)
            {
                 cmdList[idx].Execute();
            }
            cmdList.Clear();
        }
    }
}