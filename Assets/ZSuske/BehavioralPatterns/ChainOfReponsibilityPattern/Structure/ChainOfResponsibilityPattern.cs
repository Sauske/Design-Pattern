using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Suske
{
    public class ChainOfResponsibilityPattern : MonoBehaviour
    {
        void Start()
        {
            CORP_Handler handler1 = new ConcreteHandler1();
            CORP_Handler handler2 = new ConcreteHandler2();
            CORP_Handler handler3 = new ConcreteHandler3();

            handler1.SetSuccessor(handler2);
            handler2.SetSuccessor(handler3);

            handler1.Request(10);
        }
    }

    public abstract class CORP_Handler
    {
        protected CORP_Handler successor;

        public void SetSuccessor(CORP_Handler successor)
        {
            this.successor = successor;
        }

        public abstract void Request(int request);
    }

    public class ConcreteHandler1:CORP_Handler
    {
        public override void Request(int request)
        {
            if(request >= 0 && request < 10)
            {
                Debug.Log(this.GetType().Name + " Handler Request:" + request);
            }
            else if(successor != null)
            {
                successor.Request(request);
            }
        }
    }

    public class ConcreteHandler2:CORP_Handler
    {
        public override void Request(int request)
        {
            if(request >= 10 && request < 20)
            {
                Debug.Log(this.GetType().Name + " Handler Request:" + request);
            }
            else if(successor != null)
            {
                successor.Request(request);
            }
        }
    }

    public class ConcreteHandler3:CORP_Handler
    {
        public override void Request(int request)
        {
            if(request >= 20)
            {
                Debug.Log(GetType().Name + " Handler Request:" + request);
            }
            else if(successor != null)
            {
                successor.Request(request);
            }
        }
    }
}