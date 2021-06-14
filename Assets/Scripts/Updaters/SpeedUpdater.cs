using Script.ECS;
using Script.Modules;
using UnityEngine;
using UnityEngine.AI;

namespace Script.Updaters
{
    public class SpeedUpdaterPlayer : IUpdater
    {
        private static SpeedUpdaterPlayer _singleton;
    
        public static SpeedUpdaterPlayer Instance()
        {
            if (_singleton == null)
            {
                _singleton = new SpeedUpdaterPlayer();
                
            }

            return _singleton;
        }
        public void SystemUpdate()
        {
            
            
            var playerAccessor = TAccessor<SpeedModule>.Instance();

            foreach (var module in playerAccessor.GetAllModules())
            {
                var entity = module.gameObject;
                var currentMod = playerAccessor.TryGetModule(entity);
                var newSpeed = currentMod.Speed;
                currentMod.Nav.speed=newSpeed;
                 




            }
        }
        
    }
}