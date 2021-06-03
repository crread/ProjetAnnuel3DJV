using Script.ECS;
using Script.Modules;
using UnityEngine;

namespace Script.Updaters
{
    public class MovementUpdaterPlayer : IUpdater
    {
        private static MovementUpdaterPlayer _singleton;
    
        public static MovementUpdaterPlayer Instance()
        {
            if (_singleton == null)
            {
                _singleton = new MovementUpdaterPlayer();
                
            }

            return _singleton;
        }
        public void SystemUpdate()
        {
            
            
            var playerAccessor = TAccessor<MinionModule>.Instance();

            foreach (var module in playerAccessor.GetAllModules())
            {
                var entity = module.gameObject;
                var currentMod = playerAccessor.TryGetModule(entity);
                var positionToMove = currentMod.ObjectToFollow;
                if (positionToMove != null)
                {
                    if (currentMod.Follow)
                    {
                    
                    
                        if (Vector3.SqrMagnitude(currentMod.Minion.position - positionToMove.position) > 10f)
                        {
                            entity.transform.position = Vector3.MoveTowards(currentMod.Minion.position, positionToMove.position, 0.13f);
                        }
                        else
                        {
                            currentMod.Rb.velocity = Vector3.zero;
                        }
                    }
                }
                
                
                
            }
        }
        
    }
}