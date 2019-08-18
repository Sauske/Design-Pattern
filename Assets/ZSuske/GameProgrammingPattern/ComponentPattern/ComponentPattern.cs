using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Suske
{
    public class NewBehaviourScript : MonoBehaviour
    {
        GameEntity entity = new GameEntity();

        private void Start()
        {
            entity.Start();
        }

        private void Update()
        {
            entity.Update();
        }
    }

    /// <summary>
    /// 游戏类
    /// </summary>
    public class GameEntity
    {
        //辅助类对象
        public WorldX worldX = new WorldX();
        public GraphicsX graphicsX = new GraphicsX();

        int componentCount = 0;
        public List<IComponent> componentList = new List<IComponent>();
        GraphicsComponent graphicsComponent = null;
        PhysicsComponent physicsComponent = null;
        InputComponent inputComponent = null;
        public void Start()
        {
            graphicsComponent = new GraphicsComponent();
            physicsComponent = new PhysicsComponent();
            inputComponent = new InputComponent();

            componentList.Add(graphicsComponent);
            componentList.Add(physicsComponent);
            componentList.Add(inputComponent);

            Debug.Log("Game Components Initialization Finish...");
        }

        public void Update()
        {
            componentCount = componentList.Count;
            for (int idx = 0; idx < componentCount; idx++)
            {
                componentList[idx].Update(this);
            }
        }
    }

    #region 组件实体类
    public class GraphicsComponent : IGraphicsComponent
    {
        public void Update(GameEntity entity)
        {
            //TODO:Handle Graphics...
        }
    }
    public class PhysicsComponent : IPhysicsComponent
    {
        public void Update(GameEntity entity)
        {
            //TODO: Handle Physics...
        }
    }

    public class InputComponent : IInputComponent
    {
        public void Update(GameEntity entiy)
        {
            //TODO: Handle Input...
        }
    }
    #endregion

    #region 接口
    public interface IComponent
    {
        void Update(GameEntity entity);
    }

    public interface IGraphicsComponent : IComponent
    {
        new void Update(GameEntity entity);
    }

    public interface IPhysicsComponent : IComponent
    {
        new void Update(GameEntity entity);
    }

    public interface IInputComponent : IComponent
    {
        new void Update(GameEntity entity);
    }
    #endregion

    #region 辅助类
    public class WorldX { }
    public class GraphicsX
    {
        public void Draw(Sprite sprite, float x, float y) { }
    }
    #endregion
}
