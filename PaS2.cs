using PaS2.Core.Abstraction.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader;

namespace PaS2
{
    public class PaS2 : Mod
	{
		public static PaS2 Instance => ModContent.GetInstance<PaS2>();

		private List<ILoadable> loadCache;

		public override void Load() => LoadCache();

		public override void Unload() => UnloadCache();

        private void LoadCache()
		{
			loadCache = new List<ILoadable>();

			foreach (Type type in Code.GetTypes())
			{
				if (!type.IsAbstract && type.GetInterfaces().Contains(typeof(ILoadable)))
				{
					loadCache.Add(Activator.CreateInstance(type) as ILoadable);
				}
			}

			loadCache.Sort((x, y) => x.Priority > y.Priority ? 1 : -1);

			for (int i = 0; i < loadCache.Count; ++i)
			{
				if (Main.dedServ && !loadCache[i].LoadOnDedServer)
				{
					continue;
				}

				loadCache[i].Load();
			}
		}

		private void UnloadCache()
		{
			foreach (var loadable in loadCache)
			{
				loadable?.Unload();
			}

			loadCache?.Clear();
		}
	}
}