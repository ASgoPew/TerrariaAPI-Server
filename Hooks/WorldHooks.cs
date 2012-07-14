using System;
using System.ComponentModel;
namespace Hooks
{
	public static class WorldHooks
	{
		public delegate void SaveWorldD(bool resettime, HandledEventArgs e);
        public delegate void StartHardModeD(HandledEventArgs e);
	    public delegate void MeteorDropD(MeteorDropEventArgs e);

		public static event WorldHooks.SaveWorldD SaveWorld;
	    public static event StartHardModeD StartHardMode;
	    public static event MeteorDropD MeteorDrop;

		public static bool OnSaveWorld(bool resettime)
		{
			if (WorldHooks.SaveWorld == null)
			{
				return false;
			}
			HandledEventArgs handledEventArgs = new HandledEventArgs();
			WorldHooks.SaveWorld(resettime, handledEventArgs);
			return handledEventArgs.Handled;
		}
        public static bool OnStartHardMode()
        {
            if (StartHardMode == null)
                return false;
            HandledEventArgs handledEventArgs = new HandledEventArgs();
            WorldHooks.StartHardMode(handledEventArgs);
            return handledEventArgs.Handled;
        }
        public static bool OnMeteorDrop(int x, int y)
        {
            if(MeteorDrop == null)
            {
                return false;
            }

            MeteorDropEventArgs args = new MeteorDropEventArgs
            {
                X = x,
                Y = y
            };

            MeteorDrop(args);
            return args.Handled;
        }
	}
}
