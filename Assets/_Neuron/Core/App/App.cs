using System.Dynamic;

namespace _Neuron.Core.App
{
    public abstract class App
    {
        private static App _instance;

        public App()
        {
            
        }
        
        public static App instance()
        {
            return _instance;
        }
        
        public static void launch(App app)
        {
            if (_instance != null)
            {
                _instance.shutdown();
            }
                
            _instance = app;
            app.init();
            app.postInit();
            app.run();
        }

        public virtual void tick(float delta)
        {
            
        }

        protected virtual void init()
        {
            
        }

        protected virtual void postInit()
        {
            
        }
        
        protected virtual void run()
        {
            
        }

        protected virtual void beforeShutdown()
        {
            
        }

        public void shutdown()
        {
            beforeShutdown();
            _instance = null;
        }

    }
    
}